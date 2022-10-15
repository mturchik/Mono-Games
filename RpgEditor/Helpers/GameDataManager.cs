﻿namespace RpgEditor.Helpers;
public class GameDataManager
{
    #region Events

    public event EventHandler? GameLoaded;

    #endregion

    #region Fields and Properties

    public RolePlayingGame? LoadedGame { get; private set; }

    public GameDataSet<RolePlayingGame> Games { get; private set; }

    public GameDataSet<EntityData> Entities { get; private set; } = default!;
    public GameDataSet<ArmorData> Armors { get; private set; } = default!;
    public GameDataSet<ShieldData> Shields { get; private set; } = default!;
    public GameDataSet<WeaponData> Weapons { get; private set; } = default!;

    #endregion

    #region Constructor

    public GameDataManager()
    {
        Games = new GameDataSet<RolePlayingGame>(
            GetOrCreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RpgEditor\\Games")
        );
    }

    #endregion

    #region Game Manager

    public void LoadGame(RolePlayingGame? rpg)
    {
        LoadedGame = rpg;
        if (rpg != null) InitializeSubDirectories(rpg);
        GameLoaded?.Invoke(this, EventArgs.Empty);
    }

    private void InitializeSubDirectories(RolePlayingGame rpg)
    {
        Entities = new GameDataSet<EntityData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Entities")
        );
        Armors = new GameDataSet<ArmorData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Armors")
        );
        Shields = new GameDataSet<ShieldData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Shields")
        );
        Weapons = new GameDataSet<WeaponData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Weapons")
        );
    }

    #endregion

    #region Static Helpers

    private static DirectoryInfo GetOrCreateDirectory(string path)
    {
        var directory = new DirectoryInfo(path);
        if (!directory.Exists) directory.Create();
        return directory;
    }

    #endregion
}
