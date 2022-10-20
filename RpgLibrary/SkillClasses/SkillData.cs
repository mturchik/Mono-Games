namespace RpgLibrary.SkillClasses;
public class SkillData : BaseData
{
    public string PrimaryAttribute { get; set; } = "";
    public Dictionary<string, int> ClassModifiers { get; } = new();

    public override SkillData Clone()
    {
        return new()
        {
            Id = Id,
        };
    }
}
