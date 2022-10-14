namespace RpgLibrary.ItemClasses;
public class ShieldData
{
    public string Name = "";
    public string Type = "";
    public int Price;
    public float Weight;
    public bool Equipped;
    public int DefenseValue;
    public int DefenseModifier;
    public string[] AllowableClasses = Array.Empty<string>();
}
