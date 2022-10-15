namespace RpgLibrary.CharacterClasses;
public class EntityData : BaseData
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = "";
    [Required]
    public EntityType EntityType { get; }
    [Required]
    public EntityGender Gender { get; }
    [Required]
    public int Strength { get; set; }
    [Required]
    public int Dexterity { get; set; }
    [Required]
    public int Cunning { get; set; }
    [Required]
    public int Willpower { get; set; }
    [Required]
    public int Magic { get; set; }
    [Required]
    public int Constitution { get; set; }
    [Required, StringLength(100)]
    public string HealthFormula { get; set; } = "";
    [Required, StringLength(100)]
    public string StaminaFormula { get; set; } = "";
    [Required, StringLength(100)]
    public string ManaFormula { get; set; } = "";
    public override EntityData Clone() => (EntityData)MemberwiseClone();
}
