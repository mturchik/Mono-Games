namespace RpgLibrary.ItemClasses;
public class ShieldData : BaseData
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Type { get; set; } = "";
    [Required]
    public int Price { get; set; }
    [Required]
    public float Weight { get; set; }
    [Required]
    public int DefenseValue { get; set; }
    [Required]
    public int DefenseModifier { get; set; }
    [Required]
    public string[] AllowableClasses { get; set; } = Array.Empty<string>();
    public override ShieldData Clone()
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
            DefenseValue = DefenseValue,
            DefenseModifier = DefenseModifier,
            AllowableClasses = classes.ToArray(),
        };
    }
}
