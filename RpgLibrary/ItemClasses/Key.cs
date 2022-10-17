namespace RpgLibrary.ItemClasses;
public class Key : BaseItem
{
    #region Fields and Properties
    #endregion

    #region Constructor

    public Key(string name, string type) : base(name, type, 0, 0)
    {

    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override Key Clone() => new(Name, Type);

    #endregion
}
