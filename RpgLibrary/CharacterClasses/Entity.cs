namespace RpgLibrary.CharacterClasses;
public abstract class Entity
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

    #region Constructor Region

    private Entity()
    {
        _strength = 0;
        _dexterity = 0;
        _cunning = 0;
        _willpower = 0;
        _magic = 0;
        _constitution = 0;
        Health = AttributePair.Zero;
        Stamina = AttributePair.Zero;
        Mana = AttributePair.Zero;
    }

    public Entity(string name, EntityData entityData)
    {
        EntityName = name;
        EntityClass = entityData.Name;
        Gender = entityData.Gender;
        EntityType = entityData.EntityType;
        _strength = entityData.Strength;
        _dexterity = entityData.Dexterity;
        _cunning = entityData.Cunning;
        _willpower = entityData.Willpower;
        _magic = entityData.Magic;
        _cunning = entityData.Constitution;
        Health = AttributePair.Zero;
        Stamina = AttributePair.Zero;
        Mana = AttributePair.Zero;
    }

    #endregion
}
