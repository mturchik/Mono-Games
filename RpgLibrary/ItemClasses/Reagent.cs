namespace RpgLibrary.ItemClasses;
public class Reagent : BaseItem
{
    #region Fields and Properties
    #endregion

    #region Constructor Region

    public Reagent(string reagentName, string reagentType, int price, float weight)
        : base(reagentName, reagentType, price, weight, Array.Empty<string>())
    {
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override Reagent Clone()
    {
        return new(Name, Type, Price, Weight);
    }

    #endregion
}
