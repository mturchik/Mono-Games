namespace MGRpgLibrary.Controls;
public class ListBox : Control
{
    #region Event Region

    public event EventHandler? SelectionChanged;
    public event EventHandler? Enter;
    public event EventHandler? Leave;

    #endregion

    #region Fields and Properties

    private readonly int _lineCount;
    private readonly Texture2D _image;
    private readonly Texture2D _cursor;
    private int _startItem;

    private int _selectedItem;
    public int SelectedIndex
    {
        get { return _selectedItem; }
        set { _selectedItem = (int)MathHelper.Clamp(value, 0f, Items.Count); }
    }

    public List<string> Items { get; } = new();
    public string SelectedItem => Items[_selectedItem];
    public Color SelectedColor { get; set; } = Color.Red;

    public override bool HasFocus
    {
        get { return _hasFocus; }
        set
        {
            _hasFocus = value;
            if (_hasFocus)
                OnEnter(EventArgs.Empty);
            else
                OnLeave(EventArgs.Empty);
        }
    }

    #endregion

    #region Constructor

    public ListBox(Texture2D background, Texture2D cursor) : base()
    {
        _hasFocus = false;
        _tabStop = false;
        _image = background;
        _cursor = cursor;
        Size = new Vector2(_image.Width, _image.Height);

        _lineCount = _image.Height / SpriteFont.LineSpacing;
        _startItem = 0;
        Color = Color.Black;
    }

    #endregion

    #region Abstract Method Region

    public override void Update(GameTime gameTime)
    {
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_image, Position, Color.White);

        for (int i = 0; i < _lineCount; i++)
        {
            if (_startItem + i >= Items.Count) break;

            if (_startItem + i == _selectedItem)
            {
                spriteBatch.DrawString(
                    SpriteFont,
                    Items[_startItem + i],
                    new Vector2(Position.X, Position.Y + i * SpriteFont.LineSpacing),
                    SelectedColor
                );
                spriteBatch.Draw(
                    _cursor,
                    new Vector2(
                        Position.X - (_cursor.Width + 2),
                        Position.Y + i * SpriteFont.LineSpacing + 5
                    ),
                    Color.White
                );
            }
            else
                spriteBatch.DrawString(
                SpriteFont,
                Items[_startItem + i],
                new Vector2(Position.X, 2 + Position.Y + i * SpriteFont.LineSpacing),
                Color);
        }
    }

    public override void HandleInput(PlayerIndex playerIndex)
    {
        if (!HasFocus) return;

        if (InputHandler.KeyReleased(Keys.Down) || InputHandler.ButtonReleased(Buttons.LeftThumbstickDown, playerIndex))
        {
            if (_selectedItem < Items.Count - 1)
            {
                _selectedItem++;

                if (_selectedItem >= _startItem + _lineCount)
                    _startItem = _selectedItem - _lineCount + 1;

                OnSelectionChanged(EventArgs.Empty);
            }
        }
        else if (InputHandler.KeyReleased(Keys.Up) || InputHandler.ButtonReleased(Buttons.LeftThumbstickUp, playerIndex))
        {
            if (_selectedItem > 0)
            {
                _selectedItem--;
                if (_selectedItem < _startItem)
                    _startItem = _selectedItem;
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        if (InputHandler.KeyReleased(Keys.Enter) || InputHandler.ButtonReleased(Buttons.A, playerIndex))
        {
            HasFocus = false;
            OnSelected(EventArgs.Empty);
        }
        if (InputHandler.KeyReleased(Keys.Escape) || InputHandler.ButtonReleased(Buttons.B, playerIndex))
        {
            HasFocus = false;
        }
    }

    #endregion

    #region Method Region

    protected virtual void OnSelectionChanged(EventArgs e) => SelectionChanged?.Invoke(this, e);

    protected virtual void OnEnter(EventArgs e) => Enter?.Invoke(this, e);

    protected virtual void OnLeave(EventArgs e) => Leave?.Invoke(this, e);

    #endregion
}
