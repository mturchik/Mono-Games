namespace MGRpgLibrary.Controls;
public abstract class Control
{
    #region Events

    public event EventHandler? Selected;

    #endregion

    #region Fields and Properties

    protected string? _name;
    public string? Name
    {
        get { return _name; }
        set { _name = value; }
    }

    protected string? _text;
    public string? Text
    {
        get { return _text; }
        set { _text = value; }
    }

    protected Vector2 _size;
    public Vector2 Size
    {
        get { return _size; }
        set { _size = value; }
    }

    protected Vector2 _position;
    public Vector2 Position
    {
        get { return _position; }
        set
        {
            _position = value;
            _position.Y = (int)_position.Y;
        }
    }

    protected object? _value;
    public object? Value
    {
        get { return _value; }
        set { _value = value; }

    }

    protected bool _hasFocus;
    public virtual bool HasFocus
    {
        get { return _hasFocus; }
        set { _hasFocus = value; }
    }

    protected bool _enabled;
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    protected bool _visible;
    public bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    protected bool _tabStop;
    public bool TabStop
    {
        get { return _tabStop; }
        set { _tabStop = value; }
    }

    protected SpriteFont _spriteFont;
    public SpriteFont SpriteFont
    {
        get { return _spriteFont; }
        set { _spriteFont = value; }
    }

    protected Color _color;
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }

    protected string? _type;
    public string? Type
    {
        get { return _type; }
        set { _type = value; }
    }

    #endregion

    #region Constructor

    public Control()
    {
        _color = Color.White;
        _enabled = true;
        _visible = true;
        _spriteFont = ControlManager.SpriteFont;
    }

    #endregion

    #region Abstract Methods

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
    public abstract void HandleInput(PlayerIndex playerIndex);

    #endregion

    #region Virtual Methods

    protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

    #endregion
}
