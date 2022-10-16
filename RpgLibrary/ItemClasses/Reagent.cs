namespace RpgLibrary.ItemClasses;
public class Reagent : BaseItem
{
    #region Fields and Properties
    #endregion

    #region Constructor Region

    public Reagent(string reagentName, string reagentType, int price, float weight)
        : base(reagentName, reagentType, price, weight, null)
    {
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override object Clone() => MemberwiseClone();

    #endregion
}
