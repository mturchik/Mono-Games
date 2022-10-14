namespace RpgEditor.Helpers;
public class GameDataManagerOptions
{
    public string GameDirectoryPath { get; set; } = "";
}
public class GameDataManager
{
    public event EventHandler? GameLoaded;

    private readonly DirectoryInfo _gamesDirectory;
    private readonly Dictionary<string, RolePlayingGame> _gameData = new();

    public RolePlayingGame? LoadedGame { get; private set; }

    #region Constructor

    public GameDataManager(GameDataManagerOptions opts)
    {
        _gamesDirectory = GetOrCreateDirectory(opts.GameDirectoryPath);
        foreach (var gameDir in _gamesDirectory.EnumerateDirectories())
        {
            var rpg = XnaSerializer.Deserialize<RolePlayingGame>(gameDir.FullName + "/Game.xml");
            _gameData.Add(rpg.Id, rpg);
            CreateSubGameDirectories(gameDir);
        }
    }

    private static DirectoryInfo GetOrCreateDirectory(string path)
    {
        var directory = new DirectoryInfo(path);
        if (!directory.Exists) directory.Create();
        return directory;
    }

    private static void CreateSubGameDirectories(DirectoryInfo gameDir)
    {
        _ = GetOrCreateDirectory(gameDir.FullName + "\\Classes");
        var itemsDir = GetOrCreateDirectory(gameDir.FullName + "\\Items");
        _ = GetOrCreateDirectory(itemsDir.FullName + "\\Armors");
        _ = GetOrCreateDirectory(itemsDir.FullName + "\\Shields");
        _ = GetOrCreateDirectory(itemsDir.FullName + "\\Weapons");
    }

    #endregion

    public void LoadGame(RolePlayingGame? rpg)
    {
        LoadedGame = rpg;
        GameLoaded?.Invoke(this, EventArgs.Empty);
    }

    public List<RolePlayingGame> GetGames() => _gameData.Values.ToList();

    public RolePlayingGame? GetGame(string id) => _gameData.GetValueOrDefault(id);

    public void UpsertGame(RolePlayingGame rpg)
    {
        var gameDir = GetOrCreateDirectory(_gamesDirectory.FullName + "\\" + rpg.Id);
        XnaSerializer.Serialize(gameDir.FullName + "/Game.xml", rpg);
        _gameData.TryAdd(rpg.Id, rpg);
        CreateSubGameDirectories(gameDir);
    }

    public void DeleteGame(RolePlayingGame rpg)
    {
        var gameDir = GetOrCreateDirectory(_gamesDirectory.FullName + "\\" + rpg.Id);
        gameDir.Delete();
        _gameData.Remove(rpg.Id);
    }
}