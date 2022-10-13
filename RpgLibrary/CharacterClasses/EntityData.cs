namespace RpgLibrary.CharacterClasses;
public class EntityData
{
    #region Fields

    public string EntityName;

    public int Strength;
    public int Dexterity;
    public int Cunning;
    public int Willpower;
    public int Magic;
    public int Constitution;

    public string HealthFormula;
    public string StaminaFormula;
    public string MagicFormula;

    #endregion

    #region Constructor

    private EntityData() { }

    public EntityData(
        string entityName,
        int strength,
        int dexterity,
        int cunning,
        int willpower,
        int magic,
        int constitution,
        string health,
        string stamina,
        string mana)
    {
        EntityName = entityName;
        Strength = strength;
        Dexterity = dexterity;
        Cunning = cunning;
        Willpower = willpower;
        Cunning = cunning;
        Willpower = willpower;
        Magic = magic;
        Constitution = constitution;
        HealthFormula = health;
        StaminaFormula = stamina;
        MagicFormula = mana;
    }

    #endregion

    #region Static Methods

    public override string ToString()
        => $"Name = {EntityName}, "
         + $"Strength = {Strength}, "
         + $"Dexterity = {Dexterity}, "
         + $"Cunning = {Cunning}, "
         + $"Willpower = {Willpower}, "
         + $"Magic = {Magic}, "
         + $"Constitution = {Constitution}, "
         + $"Health Formula = {HealthFormula}, "
         + $"Stamina Formula = {StaminaFormula}, "
         + $"Magic Formula = {MagicFormula}";

    public object Clone() => new EntityData
    {
        EntityName = EntityName,
        Strength = Strength,
        Dexterity = Dexterity,
        Cunning = Cunning,
        Willpower = Willpower,
        Magic = Magic,
        Constitution = Constitution,
        HealthFormula = HealthFormula,
        StaminaFormula = StaminaFormula,
        MagicFormula = MagicFormula
    };

    #endregion
}
