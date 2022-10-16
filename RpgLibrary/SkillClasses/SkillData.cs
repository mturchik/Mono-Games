namespace RpgLibrary.SkillClasses;
public class SkillData : BaseData
{
    public override SkillData Clone()
    {
        return new()
        {
            Id = Id,
        };
    }
}
