namespace RpgLibrary.ItemClasses;
public class ItemDataManager
{
    #region Fields and Properties

    public Dictionary<string, ArmorData> ArmorData { get; set; } = new();
    public Dictionary<string, ShieldData> ShieldData { get; set; } = new();
    public Dictionary<string, WeaponData> WeaponData { get; set; } = new();

    #endregion

    #region Constructor Region

    #endregion
}
