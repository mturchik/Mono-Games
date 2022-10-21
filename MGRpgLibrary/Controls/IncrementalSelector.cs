namespace MGRpgLibrary.Controls;
public class IncrementalSelector : Control
{
    #region Events

    public event EventHandler? Increase;
    protected virtual void OnIncrease() => Increase?.Invoke(this, EventArgs.Empty);

    public event EventHandler? Decrease;
    protected virtual void OnDecrease() => Decrease?.Invoke(this, EventArgs.Empty);

    #endregion

    #region Fields and Properties

    private readonly Texture2D _leftTexture;
    private readonly Texture2D _rightTexture;
    private readonly Texture2D _stopTexture;
    public int Increment { get; set; }
    public int Width { get; set; }
    private Color SelectedColor { get; set; } = Color.Red;
    public new int Value { get; private set; }

    private int _minValue;
    public int MinimumValue
    {
        get { return _minValue; }
        set
        {
            if (value > _maxValue)
                _minValue = _maxValue;
            else
                _minValue = value;
        }
    }

    private int _maxValue;
    public int MaximumValue
    {
        get { return _maxValue; }
        set
        {
            if (value < _minValue)
                _maxValue = _minValue;
            else
                _maxValue = value;
        }
    }

    #endregion

    #region Constructor

    public IncrementalSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
    {
        _minValue = 0;
        _maxValue = 100;
        Increment = 1;
        Width = 50;
        _leftTexture = leftArrow;
        _rightTexture = rightArrow;
        _stopTexture = stop;
        TabStop = true;
        Color = Color.White;
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override void Update(GameTime gameTime)
    {
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // Left Texture
        Vector2 drawTo = _position;
        if (Value != _minValue)
            spriteBatch.Draw(_leftTexture, drawTo, Color.White);
        else
            spriteBatch.Draw(_stopTexture, drawTo, Color.White);

        drawTo.X += _leftTexture.Width + 5f;
        // Value Texture
        string currentValue = Value.ToString();
        float itemWidth = _spriteFont.MeasureString(currentValue).X;
        float offset = (Width - itemWidth) / 2;
        drawTo.X += offset;
        if (_hasFocus)
            spriteBatch.DrawString(_spriteFont, currentValue, drawTo, SelectedColor);
        else
            spriteBatch.DrawString(_spriteFont, currentValue, drawTo, Color);

        drawTo.X += -1 * offset + Width + 5f;
        // Right Texture
        if (Value != _maxValue)
            spriteBatch.Draw(_rightTexture, drawTo, Color.White);
        else
            spriteBatch.Draw(_stopTexture, drawTo, Color.White);
    }

    public override void HandleInput(PlayerIndex playerIndex)
    {
        if (Value != _minValue)
        {
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex)
                || InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex)
                || InputHandler.KeyReleased(Keys.Left))
            {
                Value -= Increment;
                OnIncrease();
            }
        }

        if (Value != _maxValue)
        {
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex)
                || InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex)
                || InputHandler.KeyReleased(Keys.Right))
            {
                Value += Increment;
                OnDecrease();
            }
        }
    }

    #endregion
}
