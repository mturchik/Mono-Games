using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;

namespace RpgLibrary.CharacterClasses;
public class Entity
{
    #region Vital Field and Property Region

    public string EntityName { get; }

    public string EntityClass { get; }

    public EntityType EntityType { get; }

    public EntityGender Gender { get; }

    #endregion

    #region Basic Attribute and Property Region

    private int _strength;
    private int _strengthModifier;
    public int Strength => _strength + _strengthModifier;

    private int _dexterity;
    private int _dexterityModifier;
    public int Dexterity => _dexterity + _dexterityModifier;

    private int _cunning;
    private int _cunningModifier;
    public int Cunning => _cunning + _cunningModifier;

    private int _willpower;
    private int _willpowerModifier;
    public int Willpower => _willpower + _willpowerModifier;

    private int _magic;
    private int _magicModifier;
    public int Magic => _magic + _magicModifier;

    private int _constitution;
    private int _constitutionModifier;
    public int Constitution => _constitution + _constitutionModifier;

    #endregion

    #region Calculated Attribute Field and Property Region

    public AttributePair Health { get; }

    public AttributePair Stamina { get; }

    public AttributePair Mana { get; }

    private int _attack;
    private int _damage;
    private int _defense;

    #endregion

    #region Level Field and Property Region

    public int Level { get; }

    public long Experience { get; }

    #endregion

    #region Skill Field and Property Region

    public Dictionary<string, Skill> Skills { get; }
    public List<Modifier> SkillModifiers { get; }

    #endregion

    #region Spell Field and Property Region

    public Dictionary<string, Spell> Spells { get; }
    public List<Modifier> SpellModifiers { get; }

    #endregion

    #region Talent Field and Property Region

    public Dictionary<string, Talent> Talents { get; }
    public List<Modifier> TalentModifiers { get; }

    #endregion

    #region Constructor Region

    private Entity()
    {
        EntityName = "";
        EntityClass = "";
        Gender = EntityGender.Unknown;
        EntityType = EntityType.Character;
        _strength = 10;
        _dexterity = 10;
        _cunning = 10;
        _willpower = 10;
        _magic = 10;
        _constitution = 10;
        Health = AttributePair.Zero;
        Stamina = AttributePair.Zero;
        Mana = AttributePair.Zero;
        Skills = new();
        Spells = new();
        Talents = new();
        SkillModifiers = new();
        SpellModifiers = new();
        TalentModifiers = new();
    }

    public Entity(string name, ClassData classData, EntityGender gender, EntityType entityType) : this()
    {
        EntityName = name;
        EntityClass = classData.Name;
        Gender = gender;
        EntityType = entityType;
        _strength = classData.Strength;
        _dexterity = classData.Dexterity;
        _cunning = classData.Cunning;
        _willpower = classData.Willpower;
        _magic = classData.Magic;
        _cunning = classData.Constitution;
    }

    #endregion

    #region Method Region

    public void Update(TimeSpan elapsedTime)
    {
        SkillModifiers.ForEach(m => m.Update(elapsedTime));
        SpellModifiers.ForEach(m => m.Update(elapsedTime));
        TalentModifiers.ForEach(m => m.Update(elapsedTime));
    }

    #endregion
}
