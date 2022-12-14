namespace RpgLibrary.ItemClasses;
public class Shield : BaseItem
{
    #region Fields and Properties

    public int DefenseValue { get; protected set; }
    public int DefenseModifier { get; protected set; }

    #endregion

    #region Constructor

    public Shield(string shieldName, string shieldType, int price, float weight,
        int defenseValue, int defenseModifier,
        params string[] allowableClasses)
        : base(shieldName, shieldType, price, weight, allowableClasses)
    {
        DefenseValue = defenseValue;
        DefenseModifier = defenseModifier;
    }

    #endregion

    #region Abstract Methods

    public override object Clone()
    {
        var classes = new List<string>();
        foreach (var ac in AllowableClasses) classes.Add(ac);
        return new Shield(Name, Type, Price, Weight,
            DefenseValue, DefenseModifier,
            classes.ToArray());
    }

    public override string ToString()
    {
        var weaponString = $"{base.ToString()}, {DefenseValue}, {DefenseModifier}";
        if (AllowableClasses.Count > 0)
            weaponString += ", " + string.Join(", ", AllowableClasses);
        return weaponString;
    }

    #endregion
}
