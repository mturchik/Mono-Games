namespace RpgLibrary.CharacterClasses;
public class AttributePair
{
    #region Fields and Properties

    public int CurrentValue { get; private set; }
    public int MaximumValue { get; private set; }

    #endregion

    #region Constructor

    public static AttributePair Zero => new(0);

    public AttributePair(int maxValue)
    {
        CurrentValue = maxValue;
        MaximumValue = maxValue;
    }

    #endregion

    #region Methods

    public void Heal(ushort value)
    {
        CurrentValue += value;
        if (CurrentValue > MaximumValue)
            CurrentValue = MaximumValue;
    }

    public void Damage(ushort value)
    {
        CurrentValue -= value;
        if (CurrentValue < 0)
            CurrentValue = 0;
    }

    public void SetCurrent(int value)
    {
        CurrentValue = value;
        if (CurrentValue > MaximumValue)
            CurrentValue = MaximumValue;
    }

    public void SetMaximum(int value)
    {
        MaximumValue = value;
        if (CurrentValue > MaximumValue)
            CurrentValue = MaximumValue;
    }

    #endregion
}
