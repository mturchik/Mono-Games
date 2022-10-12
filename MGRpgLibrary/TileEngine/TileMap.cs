namespace MGRpgLibrary.TileEngine;
public class TileMap
{

    #region Fields and Properties

    private readonly List<Tileset> _tilesets;
    private readonly List<MapLayer> _layers;

    private static int _mapWidth;
    public static int WidthInPixels => _mapWidth * Engine.TileWidth;

    private static int _mapHeight;
    public static int HeightInPixels => _mapHeight * Engine.TileHeight;

    #endregion

    #region Constructor

    public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
    {
        _tilesets = tilesets;
        _layers = layers;
        _mapWidth = _layers[0].Width;
        _mapHeight = _layers[0].Height;
        for (int i = 0; i < layers.Count; i++)
            if (_mapWidth != _layers[i].Width || _mapHeight != _layers[i].Height)
                throw new Exception("Map laayer size exception");
    }

    public TileMap(Tileset tileset, MapLayer layer)
    {
        _tilesets = new() { tileset };
        _layers = new() { layer };
        _mapWidth = layer.Width;
        _mapHeight = layer.Height;
    }

    #endregion

    #region Methods

    public void Draw(SpriteBatch spriteBatch, Camera camera)
    {
        var destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
        Tile tile;
        foreach (var layer in _layers)
            for (int y = 0; y < layer.Height; y++)
            {
                destination.Y = y * Engine.TileHeight;
                for (int x = 0; x < layer.Width; x++)
                {
                    tile = layer.GetTile(x, y);
                    if (tile.TileIndex == -1 || tile.Tileset == -1) continue;

                    destination.X = x * Engine.TileWidth;
                    spriteBatch.Draw(
                        _tilesets[tile.Tileset].Texture,
                        destination,
                        _tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                        Color.White);
                }
            }
    }

    public void AddLayer(MapLayer layer)
    {
        if (layer.Width != _mapWidth || layer.Height != _mapHeight)
            throw new Exception("Map layer size exception");
        _layers.Add(layer);
    }

    #endregion
}
