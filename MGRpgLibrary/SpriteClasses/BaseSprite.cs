using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.SpriteClasses;
public class BaseSprite
{
    #region Fields and Properties

    protected Texture2D _texture;

    protected Rectangle _sourceRectangle;
    public int Width => _sourceRectangle.Width;
    public int Height => _sourceRectangle.Height;

    protected Vector2 _position;
    public Vector2 Position
    {
        get { return _position; }
        set
        {
            _position = value;
        }
    }
    public Rectangle Rectangle => new((int)_position.X, (int)_position.Y, Width, Height);

    protected float _speed = 2.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = MathHelper.Clamp(_speed, 1.0f, 16.0f); }
    }

    protected Vector2 _velocity;
    public Vector2 Velocity
    {
        get { return _velocity; }
        set
        {
            _velocity = value;
            if (_velocity != Vector2.Zero)
                _velocity.Normalize();
        }
    }

    #endregion

    #region Constructor Region

    public BaseSprite(Texture2D image, Rectangle? sourceRectangle)
    {
        _texture = image;
        _sourceRectangle = sourceRectangle ?? new Rectangle(0, 0, image.Width, image.Height);
        _position = Vector2.Zero;
        _velocity = Vector2.Zero;
    }

    public BaseSprite(Texture2D image, Rectangle? sourceRectangle, Point tile) : this(image, sourceRectangle)
    {
        _position = new Vector2(
            tile.X * Engine.TileWidth,
            tile.Y * Engine.TileHeight
        );
    }

    #endregion

    #region Method Region
    #endregion

    #region Virtual Method region

    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, _sourceRectangle, Color.White);
    }

    #endregion
}
