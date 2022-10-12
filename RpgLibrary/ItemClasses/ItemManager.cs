namespace RpgLibrary.ItemClasses;
public class ItemManager
{
    #region Fields and Properties

    private readonly Dictionary<string, Weapon> _weapons = new();
    public Dictionary<string, Weapon>.KeyCollection WeaponKeys => _weapons.Keys;

    private readonly Dictionary<string, Armor> _armors = new();
    public Dictionary<string, Armor>.KeyCollection ArmorKeys => _armors.Keys;

    private readonly Dictionary<string, Shield> _shields = new();
    public Dictionary<string, Shield>.KeyCollection ShieldKeys => _shields.Keys;


    #endregion
    #region Constructor Region

    public ItemManager() { }

    #endregion

    #region Weapon Methods

    public void AddWeapon(Weapon weapon) => _weapons.TryAdd(weapon.Name, weapon);

    public Weapon? GetWeapon(string name) => (Weapon?)_weapons.GetValueOrDefault(name)?.Clone();

    public bool ContainsWeapon(string name) => _weapons.ContainsKey(name);

    #endregion

    #region Armor Methods

    public void AddArmor(Armor armor) => _armors.TryAdd(armor.Name, armor);

    public Armor? GetArmor(string name) => (Armor?)_armors.GetValueOrDefault(name)?.Clone();

    public bool ContainsArmor(string name) => _armors.ContainsKey(name);

    #endregion

    #region Shield Methods

    public void AddShield(Shield shield) => _shields.TryAdd(shield.Name, shield);

    public Shield? GetShield(string name) => (Shield?)_shields.GetValueOrDefault(name)?.Clone();

    public bool ContainsShield(string name) => _shields.ContainsKey(name);

    #endregion
}
