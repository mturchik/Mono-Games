namespace RpgLibrary.ItemClasses;
public class WeaponData : BaseData
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = "";
    [Required, StringLength(100, MinimumLength = 3)]
    public string Type { get; set; } = "";
    [Required]
    public int Price { get; set; }
    [Required]
    public float Weight { get; set; }
    [Required]
    public WeaponHands WeaponHands { get; set; }
    [Required]
    public int AttackValue { get; set; }
    [Required]
    public int AttackModifier { get; set; }
    [Required]
    public int DamageValue { get; set; }
    [Required]
    public int DamageModifier { get; set; }
    [Required]
    public string[] AllowableClasses { get; set; } = Array.Empty<string>();
    public override WeaponData Clone()
    {
        var classes = new List<string>();
        foreach (var ac in AllowableClasses) classes.Add(ac);
        return new()
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Price = Price,
            Weight = Weight,
            WeaponHands = WeaponHands,
            AttackValue = AttackValue,
            AttackModifier = AttackModifier,
            DamageValue = DamageValue,
            DamageModifier = DamageModifier,
            AllowableClasses = classes.ToArray(),
        };
    }
}
