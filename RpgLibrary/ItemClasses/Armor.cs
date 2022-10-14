namespace RpgLibrary.ItemClasses;
public class Armor : BaseItem
{
    #region Fields and Properties

    public ArmorLocation Location { get; protected set; }
    public int DefenseValue { get; protected set; }
    public int DefenseModifier { get; protected set; }

    #endregion

    #region Constructor

    public Armor(string armorName, string armorType, int price, float weight,
        ArmorLocation location, int defenseValue, int defenseModifier,
        params string[] allowableClasses)
        : base(armorName, armorType, price, weight, allowableClasses)
    {
        Location = location;
        DefenseValue = defenseValue;
        DefenseModifier = defenseModifier;
    }

    #endregion

    #region Abstract Methods

    public override object Clone() => new Armor(Name, Type, Price, Weight,
            Location, DefenseValue, DefenseModifier,
            AllowableClasses.ToArray());

    public override string ToString()
    {
        var weaponString = $"{base.ToString()}, {Location}, {DefenseValue}, {DefenseModifier}";
        if (AllowableClasses.Count > 0)
            weaponString += ", " + string.Join(", ", AllowableClasses);
        return weaponString;
    }

    #endregion
}
