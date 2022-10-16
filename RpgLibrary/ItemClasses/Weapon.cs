namespace RpgLibrary.ItemClasses;
public class Weapon : BaseItem
{
    #region Fields and Properties

    public WeaponHands NumberHands { get; protected set; }
    public int AttackValue { get; protected set; }
    public int AttackModifier { get; protected set; }
    public int DamageValue { get; protected set; }
    public int DamageModifier { get; protected set; }

    #endregion

    #region Constructor

    public Weapon(string weaponName, string weaponType, int price, float weight,
        WeaponHands hands, int attackValue, int attackModifier, int damageValue, int damageModifier,
        params string[] allowableClasses)
        : base(weaponName, weaponType, price, weight, allowableClasses)
    {
        NumberHands = hands;
        AttackValue = attackValue;
        AttackModifier = attackModifier;
        DamageValue = damageValue;
        DamageModifier = damageModifier;
    }

    #endregion

    #region Abstract Methods

    public override object Clone()
    {
        var classes = new List<string>();
        foreach (var ac in AllowableClasses) classes.Add(ac);
        return new Weapon(Name, Type, Price, Weight,
        NumberHands, AttackValue, AttackModifier, DamageValue, DamageModifier,
        classes.ToArray());
    }

    public override string ToString()
    {
        var weaponString = $"{base.ToString()}, {NumberHands}, {AttackValue}, {AttackModifier}, {DamageValue}, {DamageModifier}";
        if (AllowableClasses.Count > 0)
            weaponString += ", " + string.Join(", ", AllowableClasses);
        return weaponString;
    }

    #endregion
}
