namespace RpgLibrary.WorldClasses;
public class LevelData
{
    public string LevelName { get; set; } = "";
    public string MapName { get; set; } = "";
    public int MapWidth { get; set; }
    public int MapHeight { get; set; }
    public string[] CharacterNames { get; set; } = Array.Empty<string>();
    public string[] ChestNames { get; set; } = Array.Empty<string>();
    public string[] TrapNames { get; set; } = Array.Empty<string>();

    private LevelData() { }

    public LevelData(string levelName, string mapName, int mapWidth, int mapHeight,
        List<string> characterNames, List<string> chestNames, List<string> trapNames)
    {
        LevelName = levelName;
        MapName = mapName;
        MapWidth = mapWidth;
        MapHeight = mapHeight;
        CharacterNames = characterNames.ToArray();
        ChestNames = chestNames.ToArray();
        TrapNames = trapNames.ToArray();
    }
}
