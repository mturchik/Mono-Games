namespace RpgLibrary.ItemClasses;
public class Chest : BaseItem
{
    #region Fields and Properties

    private static readonly Random _random = new();
    private readonly ChestData _chestData;

    public bool IsLocked => _chestData.IsLocked;
    public bool IsTrapped => _chestData.IsTrapped;

    public int Gold
    {
        get
        {
            if (_chestData.MinGold == 0 && _chestData.MaxGold == 0)
                return 0;
            int gold = _random.Next(_chestData.MinGold, _chestData.MaxGold);
            _chestData.MinGold = 0;
            _chestData.MaxGold = 0;
            return gold;
        }
    }

    #endregion

    #region Constructor Region

    public Chest(ChestData data) : base(data.Name, "", 0, 0)
    {
        _chestData = data;
    }

    #endregion

    #region Method Region
    #endregion

    #region Virtual Method region

    public override object Clone()
    {
        return new Chest(_chestData.Clone());
    }

    #endregion
}
