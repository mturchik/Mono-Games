namespace RpgLibrary.ItemClasses;
public class ReagentData : BaseData
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public int Price { get; set; }
    public float Weight { get; set; }
    public override ReagentData Clone() => (ReagentData)MemberwiseClone();
}
