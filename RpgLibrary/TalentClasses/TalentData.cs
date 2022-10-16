namespace RpgLibrary.TalentClasses;
public class TalentData : BaseData
{
    public override TalentData Clone()
    {
        return new()
        {
            Id = Id
        };
    }
}
