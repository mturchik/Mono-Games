using Microsoft.Xna.Framework.Content;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;

namespace EyesOfTheDragon.Components;
internal class DataSet<T> : Dictionary<string, T> where T : BaseData
{
    public DataSet() { }
    public DataSet(ContentManager content, string contentPath) => Load(content, contentPath);
    public void Load(ContentManager content, string contentPath)
    {
        Clear();
        string[] filenames = Directory.GetFiles(@"Content\" + contentPath, "*.xnb");
        foreach (string name in filenames)
        {
            string filename = contentPath + Path.GetFileNameWithoutExtension(name);
            var data = content.Load<T>(filename);
            _ = TryAdd(data.Name, data);
        }
    }
}
internal class DataManager
{
    #region Fields and Properties

    // Entities
    public static DataSet<ClassData> ClassData { get; } = new();
    // Items
    public static DataSet<ArmorData> ArmorData { get; } = new();
    public static DataSet<ChestData> ChestData { get; } = new();
    public static DataSet<KeyData> KeyData { get; } = new();
    public static DataSet<ShieldData> ShieldData { get; } = new();
    public static DataSet<WeaponData> WeaponData { get; } = new();
    // Abilities
    public static DataSet<SkillData> SkillData { get; } = new();

    #endregion

    #region Constructor Region
    #endregion

    #region Method Region

    public static void Load(ContentManager content)
    {
        ClassData.Load(content, @"Data\Entities\Classes\");
        ArmorData.Load(content, @"Data\Items\Armors\");
        WeaponData.Load(content, @"Data\Items\Weapons\");
        ShieldData.Load(content, @"Data\Items\Shields\");
        ChestData.Load(content, @"Data\Items\Chests\");
        KeyData.Load(content, @"Data\Items\Keys\");
        SkillData.Load(content, @"Data\Abilities\Skills\");
    }

    #endregion

    #region Virtual Method region
    #endregion
}
