namespace RpgLibrary.ItemClasses;
public class ChestData : BaseData
{
    public string Name { get; set; } = "";
    public string TextureName { get; set; } = "";
    public bool IsTrapped { get; set; }
    public bool IsLocked { get; set; }
    public string TrapName { get; set; } = "";
    public string KeyName { get; set; } = "";
    public int MinGold { get; set; }
    public int MaxGold { get; set; }
    public Dictionary<string, string> ItemCollection { get; set; } = new();
    public override ChestData Clone()
    {
        var items = new Dictionary<string, string>();
        foreach (var kv in ItemCollection) items.Add(kv.Key, kv.Value);
        return new()
        {
            Id = Id,
            Name = Name,
            TextureName = TextureName,
            IsTrapped = IsTrapped,
            IsLocked = IsLocked,
            TrapName = TrapName,
            KeyName = KeyName,
            MinGold = MinGold,
            MaxGold = MaxGold,
            ItemCollection = items
        };
    }
}
