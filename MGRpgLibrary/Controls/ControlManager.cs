namespace MGRpgLibrary.Controls;
public class ControlManager : List<Control>
{
    #region Events

    public event EventHandler? FocusChanged;

    #endregion

    #region Fields and Properties

    private int _selectedControl = 0;
    public static SpriteFont SpriteFont { get; private set; } = null!;

    #endregion

    #region Constructors

    public ControlManager(SpriteFont spriteFont) : base()
    {
        SpriteFont = spriteFont;
    }

    public ControlManager(SpriteFont spriteFont, int capacity) : base(capacity)
    {
        SpriteFont = spriteFont;
    }

    public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection) : base(collection)
    {
        SpriteFont = spriteFont;
    }

    #endregion

    #region ControlManager Methods

    public void Update(GameTime gameTime, PlayerIndex playerIndex)
    {
        if (Count == 0) return;

        ForEach(c =>
        {
            if (c.Enabled) c.Update(gameTime);
            if (c.HasFocus) c.HandleInput(playerIndex);
        });

        if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex)
            || InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex)
            || InputHandler.KeyPressed(Keys.Up))
            PreviousControl();

        if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex)
            || InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex)
            || InputHandler.KeyPressed(Keys.Down))
            NextControl();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        ForEach(c =>
        {
            if (c.Visible) c.Draw(spriteBatch);
        });
    }

    public void NextControl()
    {
        if (Count == 0) return;

        int currentControl = _selectedControl;
        this[_selectedControl].HasFocus = false;

        do
        {
            _selectedControl++;

            if (_selectedControl == Count)
                _selectedControl = 0;

            if (this[_selectedControl].TabStop && this[_selectedControl].Enabled)
            {
                FocusChanged?.Invoke(this[_selectedControl], EventArgs.Empty);
                break;
            }
        } while (currentControl != _selectedControl);

        this[_selectedControl].HasFocus = true;
    }

    public void PreviousControl()
    {
        if (Count == 0) return;

        int currentControl = _selectedControl;
        this[_selectedControl].HasFocus = false;

        do
        {
            _selectedControl--;

            if (_selectedControl < 0)
                _selectedControl = Count - 1;

            if (this[_selectedControl].TabStop && this[_selectedControl].Enabled)
            {
                FocusChanged?.Invoke(this[_selectedControl], EventArgs.Empty);
                break;
            }
        } while (currentControl != _selectedControl);

        this[_selectedControl].HasFocus = true;
    }

    #endregion
}
