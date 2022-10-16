namespace RpgLibrary.SpellClasses;
public class SpellData : BaseData
{
    public override SpellData Clone()
    {
        return new()
        {
            Id = Id
        };
    }
}
