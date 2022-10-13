namespace RpgLibrary.CharacterClasses;
public enum EntityGender { Male, Female, NonBinary, Unknown }
public abstract class Entity
{
    #region Vital Field and Property Region

    protected string _entityName;
    public string EntityName => _entityName;

    protected string _entityType;
    public string EntityType => _entityType;

    public EntityGender Gender { get; protected set; }

    #endregion

    #region Basic Attribute and Property Region

    protected int _strength;
    protected int _strengthModifier;
    public int Strength => _strength + _strengthModifier;

    protected int _dexterity;
    protected int _dexterityModifier;
    public int Dexterity => _dexterity + _dexterityModifier;

    protected int _cunning;
    protected int _cunningModifier;
    public int Cunning => _cunning + _cunningModifier;

    protected int _willpower;
    protected int _willpowerModifier;
    public int Willpower => _willpower + _willpowerModifier;

    protected int _magic;
    protected int _magicModifier;
    public int Magic => _magic + _magicModifier;

    protected int _constitution;
    protected int _constitutionModifier;
    public int Constitution => _constitution + _constitutionModifier;

    #endregion

    #region Calculated Attribute Field and Property Region

    protected AttributePair _health;
    public AttributePair Health => _health;

    protected AttributePair _stamina;
    public AttributePair Stamina => _stamina;

    protected AttributePair _mana;
    public AttributePair Mana => _mana;

    protected int _attack;
    protected int _damage;
    protected int _defense;

    #endregion

    #region Level Field and Property Region

    protected int _level;
    public int Level => _level;

    protected long _experience;
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

    public Entity(EntityData entityData)
    {
        _entityType = entityData.ClassName;
        _strength = entityData.Strength;
        _dexterity = entityData.Dexterity;
        _cunning = entityData.Cunning;
        _willpower = entityData.Willpower;
        _magic = entityData.Magic;
        _cunning = entityData.Constitution;
        _health = new AttributePair(0);
        _stamina = new AttributePair(0);
        _mana = new AttributePair(0);
    }

    #endregion
}
