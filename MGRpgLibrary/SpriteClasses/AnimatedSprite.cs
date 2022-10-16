using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.SpriteClasses;
public class AnimatedSprite
{
    #region Fields and Properties

    public Vector2 Position;

    private readonly Texture2D _texture;
    private readonly Dictionary<AnimationKey, Animation> _animations;
    public AnimationKey CurrentAnimation { get; set; }
    public int Width => _animations[CurrentAnimation].FrameWidth;
    public int Height => _animations[CurrentAnimation].FrameHeight;
    public bool IsAnimating { get; set; }

    private float _speed = 2.0f;
    public float Speed
    {
        get => _speed;
        set => _speed = MathHelper.Clamp(_speed, 1.0f, 16.0f);
    }

    private Vector2 _velocity;
    public Vector2 Velocity
    {
        get => _velocity;
        set
        {
            _velocity = value;
            if (_velocity != Vector2.Zero)
                _velocity.Normalize();
        }
    }

    #endregion

    #region Constructor

    public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
    {
        _texture = sprite;
        _animations = new Dictionary<AnimationKey, Animation>();
        foreach (AnimationKey key in animation.Keys)
            _animations.Add(key, (Animation)animation[key].Clone());
    }

    #endregion

    #region Methods

    public void Update(GameTime gameTime)
    {
        if (IsAnimating)
            _animations[CurrentAnimation].Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            Position,
            _animations[CurrentAnimation].CurrentFrameRect,
            Color.White
        );
    }

    public void LockToMap()
    {
        Position.X = MathHelper.Clamp(Position.X, 0, TileMap.WidthInPixels - Width);
        Position.Y = MathHelper.Clamp(Position.Y, 0, TileMap.HeightInPixels - Height);
    }

    #endregion
}
