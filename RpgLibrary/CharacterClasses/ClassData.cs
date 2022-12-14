namespace RpgLibrary.CharacterClasses;
public class ClassData : BaseData
{
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
    public override ClassData Clone()
    {
        return new()
        {
            Id = Id,
            Name = Name,
            Strength = Strength,
            Dexterity = Dexterity,
            Cunning = Cunning,
            Willpower = Willpower,
            Magic = Magic,
            Constitution = Constitution,
            HealthFormula = HealthFormula,
            StaminaFormula = StaminaFormula,
            ManaFormula = ManaFormula,
        };
    }
}
