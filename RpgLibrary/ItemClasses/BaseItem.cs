namespace RpgLibrary.ItemClasses;
public abstract class BaseItem
{
    #region Fields and Properties

    public List<string> AllowableClasses { get; protected set; } = new();
    public string Type { get; protected set; }
    public string Name { get; protected set; }
    public int Price { get; protected set; }
    public float Weight { get; protected set; }
    public bool IsEquipped { get; protected set; }

    #endregion

    #region Constructor

    public BaseItem(string name, string type, int price, float weight, params string[] allowableClasses)
    {
        AllowableClasses.AddRange(allowableClasses);
        Name = name;
        Type = type;
        Price = price;
        Weight = weight;
    }

    #endregion

    #region Abstract Methods

    public abstract object Clone();

    public virtual bool CanEquip(string characterType) => AllowableClasses.Contains(characterType);

    public override string ToString() => $"{Name}, {Type}, {Price}, {Weight}";

    #endregion
}
