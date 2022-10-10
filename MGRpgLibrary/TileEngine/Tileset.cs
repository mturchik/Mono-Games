namespace MGRpgLibrary.TileEngine;
public class Tileset
{
    #region Fields and Properties

    public Texture2D Texture { get; private set; }
    public int TilesWide { get; private set; }
    public int TilesHigh { get; private set; }
    public int TileWidth { get; private set; }
    public int TileHeight { get; private set; }

    private Rectangle[] _sourceRectangles;
    public Rectangle[] SourceRectangles => (Rectangle[])_sourceRectangles.Clone();

    #endregion

    #region Constructor

    public Tileset(Texture2D image, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
    {
        Texture = image;
        TilesWide = tilesWide;
        TilesHigh = tilesHigh;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        _sourceRectangles = new Rectangle[tilesWide * tilesHigh];

        int tile = 0;
        for (int y = 0; y < tilesHigh; y++)
            for (int x = 0; x < tilesWide; x++)
            {
                _sourceRectangles[tile] = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                tile++;
            }
    }

    #endregion

    #region Methods
    #endregion
}
