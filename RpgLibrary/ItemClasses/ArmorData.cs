namespace RpgLibrary.ItemClasses;
public class ArmorData : BaseData
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
    public ArmorLocation ArmorLocation;
    [Required]
    public int DefenseValue;
    [Required]
    public int DefenseModifier;
    [Required]
    public string[] AllowableClasses = Array.Empty<string>();
    public override ArmorData Clone() => (ArmorData)MemberwiseClone();
}
