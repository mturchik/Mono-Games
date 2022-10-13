namespace RpgLibrary.CharacterClasses;
public enum EntityGender { Male, Female, NonBinary, Unknown }
public enum EntityType { Character, NPC, Monster, Creature }
public abstract class Entity
{
    #region Vital Field and Property Region

    private string _entityName;
    public string EntityName => _entityName;

    private string _entityClass;
    public string EntityClass => _entityClass;

    private EntityType _entityType;
    public EntityType EntityType => _entityType;

    private EntityGender _entityGender;
    public EntityGender Gender => _entityGender;

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

    private AttributePair _health;
    public AttributePair Health => _health;

    private AttributePair _stamina;
    public AttributePair Stamina => _stamina;

    private AttributePair _mana;
    public AttributePair Mana => _mana;

    private int _attack;
    private int _damage;
    private int _defense;

    #endregion

    #region Level Field and Property Region

    private int _level;
    public int Level => _level;

    private long _experience;
    public long Experience => _experience;

    #endregion

    #region Constructor Region

    private Entity()
    {
        _strength = 0;
        _dexterity = 0;
        _cunning = 0;
        _willpower = 0;
        _magic = 0;
        _constitution = 0;
        _health = AttributePair.Zero;
        _stamina = AttributePair.Zero;
        _mana = AttributePair.Zero;
    }

    public Entity(string name, EntityData entityData, EntityGender gender, EntityType type)
    {
        _entityName = name;
        _entityClass = entityData.EntityName;
        _entityGender = gender;
        _entityType = type;
        _strength = entityData.Strength;
        _dexterity = entityData.Dexterity;
        _cunning = entityData.Cunning;
        _willpower = entityData.Willpower;
        _magic = entityData.Magic;
        _cunning = entityData.Constitution;
        _health = AttributePair.Zero;
        _stamina = AttributePair.Zero;
        _mana = AttributePair.Zero;
    }

    #endregion
}
