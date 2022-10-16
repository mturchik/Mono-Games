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

    public override object Clone()
    {
        var classes = new List<string>();
        foreach (var ac in AllowableClasses) classes.Add(ac);
        return new Armor(Name, Type, Price, Weight,
            Location, DefenseValue, DefenseModifier,
            classes.ToArray());
    }

    public override string ToString()
    {
        var weaponString = $"{base.ToString()}, {Location}, {DefenseValue}, {DefenseModifier}";
        if (AllowableClasses.Count > 0)
            weaponString += ", " + string.Join(", ", AllowableClasses);
        return weaponString;
    }

    #endregion
}
