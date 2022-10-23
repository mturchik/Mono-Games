using RpgLibrary.WorldClasses;

namespace MGRpgLibrary.TileEngine;
public class MapLayer
{
    #region Fields and Properties

    private readonly Tile[,] _map;

    public int Width => _map.GetLength(1);
    public int Height => _map.GetLength(0);

    #endregion

    #region Constructor

    public MapLayer(Tile[,] map)
    {
        _map = (Tile[,])map.Clone();
    }

    public MapLayer(int width, int height)
    {
        _map = new Tile[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _map[y, x] = new Tile(0, 0);
            }
        }
    }

    #endregion

    #region Methods

    public Tile GetTile(int x, int y) => _map[y, x];

    public void SetTile(int x, int y, Tile tile) => _map[y, x] = tile;

    public void SetTile(int x, int y, int tileIndex, int tileset) => _map[y, x] = new Tile(tileIndex, tileset);

    public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
    {
        Point cameraPoint = Engine.VectorToCell(camera.Position * (1 / camera.Zoom));
        Point viewPoint = Engine.VectorToCell(new Vector2(
            (camera.Position.X + camera.ViewportRectangle.Width) * (1 / camera.Zoom),
            (camera.Position.Y + camera.ViewportRectangle.Height) * (1 / camera.Zoom)
        ));

        Point min = new()
        {
            X = Math.Max(0, cameraPoint.X - 1),
            Y = Math.Max(0, cameraPoint.Y - 1)
        };

        Point max = new()
        {
            X = Math.Min(viewPoint.X + 1, Width),
            Y = Math.Min(viewPoint.Y + 1, Height)
        };

        Rectangle destination = new(0, 0, Engine.TileWidth, Engine.TileHeight);
        Tile tile;
        for (int y = min.Y; y < max.Y; y++)
        {
            destination.Y = y * Engine.TileHeight;
            for (int x = min.X; x < max.X; x++)
            {
                tile = GetTile(x, y);
                if (tile.TileIndex == -1 || tile.Tileset == -1)
                    continue;
                destination.X = x * Engine.TileWidth;
                spriteBatch.Draw(
                tilesets[tile.Tileset].Texture,
                destination,
                tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                Color.White);
            }
        }
    }

    public static MapLayer FromMapLayerData(MapLayerData data)
    {
        var layer = new MapLayer(data.Width, data.Height);
        for (int y = 0; y < data.Height; y++)
            for (int x = 0; x < data.Width; x++)
                layer.SetTile(x, y, data.GetTile(x, y).TileIndex, data.GetTile(x, y).TileSetIndex);
        return layer;
    }

    #endregion
}
