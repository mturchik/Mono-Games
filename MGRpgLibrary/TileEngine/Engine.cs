namespace MGRpgLibrary.TileEngine;
public class Engine
{
    #region Fields and Properties

    public static int TileWidth { get; private set; }
    public static int TileHeight { get; private set; }

    #endregion

    #region Constructor

    public Engine(int tileWidth, int tileHeight)
    {
        TileWidth = tileWidth;
        TileHeight = tileHeight;
    }

    #endregion

    #region Methods
    public static Point VectorToCell(Vector2 position) => new((int)position.X / TileWidth, (int)position.Y / TileHeight);

    #endregion
}
