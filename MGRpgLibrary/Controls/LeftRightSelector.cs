namespace MGRpgLibrary.Controls;
public class LeftRightSelector : Control
{
    #region Events

    public event EventHandler? SelectionChanged;

    #endregion

    #region Fields and Properties

    private readonly Texture2D _leftTexture;
    private readonly Texture2D _rightTexture;
    private readonly Texture2D _stopTexture;
    private int _maxItemWidth;

    private Color _selectedColor = Color.Red;
    public Color SelectedColor
    {
        get => _selectedColor;
        set => _selectedColor = value;
    }

    private int _selectedItem;
    public string SelectedItem => Items[_selectedItem];
    public int SelectedIndex
    {
        get => _selectedItem;
        set => _selectedItem = (int)MathHelper.Clamp(value, 0f, Items.Count);
    }

    public List<string> Items { get; } = new();

    #endregion

    #region Constructor

    public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
    {
        _leftTexture = leftArrow;
        _rightTexture = rightArrow;
        _stopTexture = stop;
        _tabStop = true;
        _color = Color.White;
    }

    #endregion

    #region Methods

    public void SetItems(string[] items, int maxWidth)
    {
        Items.Clear();
        Items.AddRange(items);
        _maxItemWidth = maxWidth;
    }

    protected void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

    #endregion

    #region Abstract Methods

    public override void Update(GameTime gameTime) { }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Vector2 drawTo = _position;
        if (_selectedItem != 0)
            spriteBatch.Draw(_leftTexture, drawTo, Color.White);
        else
            spriteBatch.Draw(_stopTexture, drawTo, Color.White);


        float itemWidth = _spriteFont.MeasureString(Items[_selectedItem]).X;
        float offset = (_maxItemWidth - itemWidth) / 2;
        drawTo.X += _leftTexture.Width + 5f + offset;
        if (_hasFocus)
            spriteBatch.DrawString(_spriteFont, Items[_selectedItem], drawTo, _selectedColor);
        else
            spriteBatch.DrawString(_spriteFont, Items[_selectedItem], drawTo, _color);

        drawTo.X += -1 * offset + _maxItemWidth + 5f;
        if (_selectedItem != Items.Count - 1)
            spriteBatch.Draw(_rightTexture, drawTo, Color.White);
        else
            spriteBatch.Draw(_stopTexture, drawTo, Color.White);
    }

    public override void HandleInput(PlayerIndex playerIndex)
    {
        if (Items.Count == 0) return;

        if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex)
            || InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex)
            || InputHandler.KeyReleased(Keys.Left))
        {
            _selectedItem--;
            if (_selectedItem < 0)
                _selectedItem = 0;
            OnSelectionChanged();
        }

        if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex)
            || InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex)
            || InputHandler.KeyReleased(Keys.Right))
        {
            _selectedItem++;
            if (_selectedItem >= Items.Count)
                _selectedItem = Items.Count - 1;
            OnSelectionChanged();
        }
    }

    #endregion
}
