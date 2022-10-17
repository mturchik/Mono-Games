namespace RpgEditor.Helpers;
public class GameDataManager
{
    #region Events

    public event EventHandler? GameLoaded;

    #endregion

    #region Fields and Properties

    public RolePlayingGame? LoadedGame { get; private set; }

    public GameDataSet<RolePlayingGame> Games { get; private set; }

    // Entities
    public GameDataSet<ClassData> Classes { get; private set; } = default!;
    // Items
    public GameDataSet<ArmorData> Armors { get; private set; } = default!;
    public GameDataSet<ChestData> Chests { get; private set; } = default!;
    public GameDataSet<KeyData> Keys { get; private set; } = default!;
    public GameDataSet<ReagentData> Reagents { get; private set; } = default!;
    public GameDataSet<ShieldData> Shields { get; private set; } = default!;
    public GameDataSet<WeaponData> Weapons { get; private set; } = default!;
    // Skills
    public GameDataSet<SkillData> Skills { get; private set; } = default!;
    public GameDataSet<Recipe> Recipes { get; private set; } = default!;
    // Spells
    public GameDataSet<SpellData> Spells { get; private set; } = default!;
    // Talents
    public GameDataSet<TalentData> Talents { get; private set; } = default!;

    #endregion

    #region Constructor

    public GameDataManager()
    {
        Games = new GameDataSet<RolePlayingGame>(
            GetOrCreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RpgEditor\\Games")
        );
        _ = Games.Queryable();
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
        // Classes
        Classes = new GameDataSet<ClassData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Entities\\Classes")
        );
        // Items
        Armors = new GameDataSet<ArmorData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Armors")
        );
        Chests = new GameDataSet<ChestData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Chests")
        );
        Keys = new GameDataSet<KeyData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Keys")
        );
        Reagents = new GameDataSet<ReagentData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Reagents")
        );
        Shields = new GameDataSet<ShieldData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Shields")
        );
        Weapons = new GameDataSet<WeaponData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Items\\Weapons")
        );
        // Skills
        Skills = new GameDataSet<SkillData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Abilities\\Skills")
        );
        Recipes = new GameDataSet<Recipe>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Abilities\\Recipes")
        );
        // Spells
        Spells = new GameDataSet<SpellData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Abilities\\Spells")
        );
        // Talents
        Talents = new GameDataSet<TalentData>(
            GetOrCreateDirectory(Games.DirectoryPath() + $"\\{rpg.Id}\\Abilities\\Talents")
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
