using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.WorldClasses;
using GDIBitmap = System.Drawing.Bitmap;
using GDIGraphics = System.Drawing.Graphics;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;
//using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIRectangle = System.Drawing.Rectangle;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MGLevelEditor.Forms;

public partial class FormMain : Form
{
    #region Field Region
    public static Camera camera;
    private Engine engine;
    private LevelData levelData;
    private Point mouse = new Point();
    private bool isMouseDown = false;
    private bool trackMouse = false;
    public static TileMap map;
    public static List<Tileset> tileSets = new List<Tileset>();
    public static List<MapLayer> layers = new List<MapLayer>();
    private readonly List<GDIImage> tileSetImages = new List<GDIImage>();
    #endregion
    #region Property Region
    public GraphicsDevice GraphicsDevice
    {
        get { return mapDisplay.GraphicsDevice; }
    }
    #endregion
    #region Constructor Region
    public FormMain()
    {
        InitializeComponent();
        this.Load += new EventHandler(FormMain_Load);
        this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
        tilesetToolStripMenuItem.Enabled = false;
        mapLayerToolStripMenuItem.Enabled = false;
        charactersToolStripMenuItem.Enabled = false;
        chestsToolStripMenuItem.Enabled = false;
        keysToolStripMenuItem.Enabled = false;
        newLevelToolStripMenuItem.Click +=
        new EventHandler(newLevelToolStripMenuItem_Click);
        newTilesetToolStripMenuItem.Click += new
        EventHandler(newTilesetToolStripMenuItem_Click);
        newLayerToolStripMenuItem.Click += new
        EventHandler(newLayerToolStripMenuItem_Click);
        mapDisplay.MouseEnter += new EventHandler(mapDisplay_MouseEnter);
        mapDisplay.MouseLeave += new EventHandler(mapDisplay_MouseLeave);

        mapDisplay.MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
        mapDisplay.MouseDown += new MouseEventHandler(mapDisplay_MouseDown);
        mapDisplay.MouseUp += new MouseEventHandler(mapDisplay_MouseUp);
    }
    #endregion
    #region Form Event Handler Region
    private void FormMain_Load(object sender, EventArgs e)
    {
        lbTileset.SelectedIndexChanged += new EventHandler(lbTileset_SelectedIndexChanged);
        nudCurrentTile.ValueChanged += new EventHandler(nudCurrentTile_ValueChanged);

        var viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
        camera = new Camera(viewPort);
        engine = new Engine(32, 32);

        controlTimer.Tick += new EventHandler(controlTimer_Tick);
        controlTimer.Enabled = true;
        controlTimer.Interval = 200;
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void controlTimer_Tick(object sender, EventArgs e)
    {
        mapDisplay.Invalidate();
        Logic();
    }

    private void Logic()
    {
        if (layers.Count == 0)
            return;
        Vector2 position = camera.Position;
        if (trackMouse)
        {
            if (mouse.X < Engine.TileWidth)
                position.X -= Engine.TileWidth;
            if (mouse.X > mapDisplay.Width - Engine.TileWidth)
                position.X += Engine.TileWidth;
            if (mouse.Y < Engine.TileHeight)
                position.Y -= Engine.TileHeight;
            if (mouse.Y > mapDisplay.Height - Engine.TileHeight)
                position.Y += Engine.TileHeight;
            camera.Position = position;
            camera.LockCamera();
            position.X = mouse.X + camera.Position.X;
            position.Y = mouse.Y + camera.Position.Y;
            Point tile = Engine.VectorToCell(position);
            if (isMouseDown)
            {
                if (rbDraw.Checked)
                {
                    layers[clbLayers.SelectedIndex].SetTile(
                    tile.X,
                    tile.Y,
                    (int)nudCurrentTile.Value,
                    lbTileset.SelectedIndex);
                }
                if (rbErase.Checked)
                {
                    layers[clbLayers.SelectedIndex].SetTile(
                    tile.X,
                    tile.Y,
                    -1,
                    -1);
                }
            }
        }
    }

    private void lbTileset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lbTileset.SelectedItem != null)
        {
            nudCurrentTile.Value = 0;
            nudCurrentTile.Maximum = tileSets[lbTileset.SelectedIndex].SourceRectangles.Length - 1;
            FillPreviews();
        }
    }

    private void nudCurrentTile_ValueChanged(object sender, EventArgs e)
    {
        if (lbTileset.SelectedItem != null)
        {
            FillPreviews();
        }
    }

    private void FillPreviews()
    {
        int selected = lbTileset.SelectedIndex;
        int tile = (int)nudCurrentTile.Value;
        GDIImage preview = new GDIBitmap(pbTilePreview.Width, pbTilePreview.Height);
        GDIRectangle dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
        GDIRectangle source = new GDIRectangle(
        tileSets[selected].SourceRectangles[tile].X,
        tileSets[selected].SourceRectangles[tile].Y,
        tileSets[selected].SourceRectangles[tile].Width,
        tileSets[selected].SourceRectangles[tile].Height);
        GDIGraphics g = GDIGraphics.FromImage(preview);
        g.DrawImage(tileSetImages[selected], dest, source, GDIGraphicsUnit.Pixel);
        pbTilesetPreview.Image = tileSetImages[selected];
        pbTilePreview.Image = preview;
    }
    #endregion
    #region New Menu Item Event Handler Region
    private void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (FormNewLevel frmNewLevel = new FormNewLevel())
        {
            frmNewLevel.ShowDialog();
            if (frmNewLevel.OKPressed)
            {
                levelData = frmNewLevel.LevelData;
                tilesetToolStripMenuItem.Enabled = true;
            }
        }
    }

    private void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (FormNewTileset frmNewTileset = new FormNewTileset())
        {
            frmNewTileset.ShowDialog();

            if (frmNewTileset.OKPressed)
            {
                TilesetData data = frmNewTileset.TilesetData;
                try
                {
                    GDIImage image = GDIBitmap.FromFile(data.TilesetImageName);
                    tileSetImages.Add(image);
                    Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                    FileAccess.Read);
                    Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                    Tileset tileset = new Tileset(
                    texture,
                    data.TilesWide,
                    data.TilesHigh,
                    data.TileWidthInPixels,
                    data.TileHeightInPixels);
                    tileSets.Add(tileset);
                    if (map != null)
                        map.AddTileset(tileset);
                    stream.Close();
                    stream.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file.\n" + ex.Message, "Error reading image");
                    return;
                }
                lbTileset.Items.Add(data.TilesetName);
                if (lbTileset.SelectedItem == null)
                    lbTileset.SelectedIndex = 0;
                mapLayerToolStripMenuItem.Enabled = true;
            }
        }
    }

    private void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth, levelData.MapHeight))
        {

            frmNewLayer.ShowDialog();
            if (frmNewLayer.OKPressed)
            {
                MapLayerData data = frmNewLayer.MapLayerData;
                if (clbLayers.Items.Contains(data.MapLayerName))
                {
                    MessageBox.Show("Layer with name " + data.MapLayerName + " exists.", "Existing layer");
                    return;
                }
                MapLayer layer = MapLayer.FromMapLayerData(data);
                clbLayers.Items.Add(data.MapLayerName, true);
                clbLayers.SelectedIndex = clbLayers.Items.Count - 1;
                layers.Add(layer);
                if (map == null)
                    map = new TileMap(tileSets, layers);
                charactersToolStripMenuItem.Enabled = true;
                chestsToolStripMenuItem.Enabled = true;
                keysToolStripMenuItem.Enabled = true;
            }
        }
    }
    #endregion
    #region Map Display Event Handler Region
    private void mapDisplay_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            isMouseDown = false;
    }

    private void mapDisplay_MouseDown(object sender, MouseEventArgs e)

    {
        if (e.Button == MouseButtons.Left)
            isMouseDown = true;
    }

    private void mapDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        mouse.X = e.X;
        mouse.Y = e.Y;
    }

    private void mapDisplay_MouseLeave(object sender, EventArgs e)
    {
        trackMouse = false;
    }

    private void mapDisplay_MouseEnter(object sender, EventArgs e)
    {
        trackMouse = true;
    }
    #endregion
}
