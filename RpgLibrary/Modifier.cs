namespace RpgLibrary;
public struct Modifier
{
    #region Fields

    public int Amount;
    public int Duration;
    public TimeSpan TimeLeft;

    #endregion

    #region Constructor

    public Modifier(int amount)
    {
        Amount = amount;
        Duration = -1;
        TimeLeft = TimeSpan.Zero;
    }

    public Modifier(int amount, int duration)
    {
        Amount = amount;
        Duration = duration;
        TimeLeft = TimeSpan.FromSeconds(duration);
    }

    #endregion

    #region Methods

    public void Update(TimeSpan elapsedTime)
    {
        if (Duration == -1) return;

        TimeLeft -= elapsedTime;
        if (TimeLeft.TotalMilliseconds < 0)
        {
            TimeLeft = TimeSpan.Zero;
            Amount = 0;
        }
    }

    #endregion

    #region Virtual Methods
    #endregion
}
