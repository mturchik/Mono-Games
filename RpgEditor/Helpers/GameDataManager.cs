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
            GetOrCreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RpgEditor")
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
            GetOrCreateDirectory($"{rpg.LocalPath}\\Entities\\Classes")
        );
        // Items
        Armors = new GameDataSet<ArmorData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Armors")
        );
        Chests = new GameDataSet<ChestData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Chests")
        );
        Keys = new GameDataSet<KeyData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Keys")
        );
        Reagents = new GameDataSet<ReagentData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Reagents")
        );
        Shields = new GameDataSet<ShieldData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Shields")
        );
        Weapons = new GameDataSet<WeaponData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Items\\Weapons")
        );
        // Skills
        Skills = new GameDataSet<SkillData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Abilities\\Skills")
        );
        Recipes = new GameDataSet<Recipe>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Abilities\\Recipes")
        );
        // Spells
        Spells = new GameDataSet<SpellData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Abilities\\Spells")
        );
        // Talents
        Talents = new GameDataSet<TalentData>(
            GetOrCreateDirectory($"{rpg.LocalPath}\\Abilities\\Talents")
        );
    }

    #endregion

    #region Public Helpers

    public GameDataSet<T> GetDataSet<T>() where T : BaseData
    {
        var dataSetProperty = GetType().GetProperties().FirstOrDefault(p => p.PropertyType == typeof(GameDataSet<T>));
        var dataSet = dataSetProperty?.GetValue(this);
        if (dataSet is null) throw new NullReferenceException("Called GetDataSet with BaseData that is not set up correctly");
        return (GameDataSet<T>)dataSet;
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
