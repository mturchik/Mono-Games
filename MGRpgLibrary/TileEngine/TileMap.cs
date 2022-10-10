namespace MGRpgLibrary.TileEngine;
public class TileMap
{

    #region Fields and Properties

    private List<Tileset> _tilesets;
    private List<MapLayer> _layers;

    #endregion

    #region Constructor

    public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
    {
        _tilesets = tilesets;
        _layers = layers;
    }

    public TileMap(Tileset tileset, MapLayer layer)
    {
        _tilesets = new() { tileset };
        _layers = new() { layer };
    }

    #endregion

    #region Methods

    public void Draw(SpriteBatch spriteBatch)
    {
        var destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
        Tile tile;
        foreach (var layer in _layers)
        {
            for (int y = 0; y < layer.Height; y++)
            {
                destination.Y = y * Engine.TileHeight;
                for (int x = 0; x < layer.Width; x++)

                {
                    tile = layer.GetTile(x, y);
                    destination.X = x * Engine.TileWidth;

                    spriteBatch.Draw(
                        _tilesets[tile.Tileset].Texture,
                        destination,
                        _tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                        Color.White);
                }
            }
        }
    }

    #endregion
}
