namespace RpgLibrary.ItemClasses;
public class KeyData : BaseData
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public override KeyData Clone()
    {
        return new()
        {
            Id = Id,
            Name = Name,
            Type = Type,
        };
    }
}
