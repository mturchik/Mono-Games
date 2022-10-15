namespace RpgLibrary.ItemClasses;
public class ArmorData : BaseData
{
    public string Name = "";
    public string Type = "";
    public int Price;
    public float Weight;
    public bool Equipped;
    public ArmorLocation ArmorLocation;
    public int DefenseValue;
    public int DefenseModifier;
    public string[] AllowableClasses = Array.Empty<string>();
    public override ArmorData Clone() => (ArmorData)MemberwiseClone();
}
