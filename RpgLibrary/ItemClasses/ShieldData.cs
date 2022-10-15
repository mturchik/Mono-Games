namespace RpgLibrary.ItemClasses;
public class ShieldData : BaseData
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
    public int DefenseValue;
    [Required]
    public int DefenseModifier;
    [Required]
    public string[] AllowableClasses = Array.Empty<string>();
    public override ShieldData Clone() => (ShieldData)MemberwiseClone();
}
