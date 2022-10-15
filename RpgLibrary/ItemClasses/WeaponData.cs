namespace RpgLibrary.ItemClasses;
public class WeaponData : BaseData
{
    public string Name = "";
    public string Type = "";
    public int Price;
    public float Weight;
    public bool Equipped;
    public WeaponHands WeaponHands;
    public int AttackValue;
    public int AttackModifier;
    public int DamageValue;
    public int DamageModifier;
    public string[] AllowableClasses = Array.Empty<string>();
    public override WeaponData Clone() => (WeaponData)MemberwiseClone();
}
