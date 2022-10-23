namespace RpgLibrary.WorldClasses;
public class MapData
{
    public string MapName { get; set; } = "";
    public MapLayerData[] Layers { get; set; } = Array.Empty<MapLayerData>();
    public TilesetData[] Tilesets { get; set; } = Array.Empty<TilesetData>();

    private MapData() { }

    public MapData(string mapName, List<TilesetData> tilesets, List<MapLayerData> layers)
    {
        MapName = mapName;
        Tilesets = tilesets.ToArray();
        Layers = layers.ToArray();
    }
}
