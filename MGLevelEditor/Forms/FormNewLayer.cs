using RpgLibrary.WorldClasses;

namespace MGLevelEditor.Forms;
public partial class FormNewLayer : Form
{
    #region Field Region
    private readonly int LayerWidth;
    private readonly int LayerHeight;
    #endregion
    #region Property Region
    public bool OKPressed { get; private set; }
    public MapLayerData MapLayerData { get; private set; }
    #endregion
    #region Constructor Region
    public FormNewLayer(int width, int height)
    {
        InitializeComponent();
        LayerWidth = width;
        LayerHeight = height;
        btnOK.Click += new EventHandler(btnOK_Click);
        btnCancel.Click += new EventHandler(btnCancel_Click);
    }
    #endregion
    #region Button Event Handler Region
    private void btnOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbLayerName.Text))
        {
            MessageBox.Show("You must enter a name for the layer.", "Missing Layer Name");
            return;
        }
        if (cbFill.Checked)
        {
            MapLayerData = new MapLayerData(
            tbLayerName.Text,
            LayerWidth,
            LayerHeight,
            (int)nudTile.Value,
            (int)nudTileset.Value);
        }
        else
        {
            MapLayerData = new MapLayerData(
            tbLayerName.Text,
            LayerWidth,
            LayerHeight);
        }

        OKPressed = true;
        this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        OKPressed = false;
        this.Close();
    }
    #endregion
}
