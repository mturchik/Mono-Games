namespace RpgLibrary;
public class Mechanics
{
    #region Fields and Properties

    private static readonly Random _random = new();

    #endregion

    #region Constructor
    #endregion

    #region Methods

    public static int RollDie(DieType die) => _random.Next(0, (int)die) + 1;

    #endregion

    #region Virtual Methods
    #endregion
}
