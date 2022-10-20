namespace RpgLibrary.SkillClasses;
public class SkillData : BaseData
{
    public string PrimaryAttribute { get; set; } = "";
    public Dictionary<string, int> ClassModifiers { get; set; } = new();

    public override SkillData Clone()
    {
        var modifiers = new Dictionary<string, int>();
        foreach (var kv in ClassModifiers) modifiers.TryAdd(kv.Key, kv.Value);
        return new()
        {
            Id = Id,
            Name = Name,
            PrimaryAttribute = PrimaryAttribute,
            ClassModifiers = modifiers
        };
    }
}
