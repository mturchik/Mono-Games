namespace RpgLibrary.ItemClasses;
public class WeaponData : BaseData
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Name = "";
    [Required, StringLength(100, MinimumLength = 3)]
    public string Type = "";
    [Required]
    public int Price;
    [Required]
    public float Weight;
    [Required]
    public WeaponHands WeaponHands;
    [Required]
    public int AttackValue;
    [Required]
    public int AttackModifier;
    [Required]
    public int DamageValue;
    [Required]
    public int DamageModifier;
    [Required]
    public string[] AllowableClasses = Array.Empty<string>();
    public override WeaponData Clone() => (WeaponData)MemberwiseClone();
}
