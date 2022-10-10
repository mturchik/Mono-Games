namespace MGRpgLibrary.TileEngine;
public class Tile
{
    #region Fields and Properties

    public int TileIndex { get; private set; }
    public int Tileset { get; private set; }

    #endregion

    #region Constructor

    public Tile(int tileIndex, int tileset)
    {
        TileIndex = tileIndex;
        Tileset = tileset;
    }

    #endregion
}
