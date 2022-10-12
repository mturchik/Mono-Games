using MGRpgLibrary.SpriteClasses;

namespace MGRpgLibrary.TileEngine;
public enum CameraMode { Free, Follow }
public class Camera
{
    #region Fields and Properties

    private Rectangle _viewportRectangle;

    private Vector2 _position;
    public Vector2 Position => _position;

    private float _speed;
    public float Speed
    {
        get => _speed;
        set => _speed = MathHelper.Clamp(_speed, 1f, 16f);
    }

    public float Zoom { get; private set; }
    public CameraMode CameraMode { get; private set; }

    #endregion

    #region Constructor

    public Camera(Rectangle viewportRect)
    {
        _speed = 4f;
        Zoom = 1f;
        _viewportRectangle = viewportRect;
        CameraMode = CameraMode.Follow;
    }

    public Camera(Rectangle viewportRect, Vector2 position)
    {
        _speed = 4f;
        Zoom = 1f;
        _viewportRectangle = viewportRect;
        _position = position;
        CameraMode = CameraMode.Follow;
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
        if (CameraMode == CameraMode.Follow) return;

        var motion = Vector2.Zero;

        if (InputHandler.KeyDown(Keys.Left) || InputHandler.ButtonDown(Buttons.RightThumbstickLeft, PlayerIndex.One))
            motion.X = -_speed;
        else if (InputHandler.KeyDown(Keys.Right) || InputHandler.ButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
            motion.X = _speed;

        if (InputHandler.KeyDown(Keys.Up) || InputHandler.ButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
            motion.Y = -_speed;
        else if (InputHandler.KeyDown(Keys.Down) || InputHandler.ButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
            motion.Y = _speed;

        if (motion != Vector2.Zero)
        {
            motion.Normalize();
            _position += motion * _speed;
            LockCamera();
        }
    }

    private void LockCamera()
    {
        _position.X = MathHelper.Clamp(_position.X, 0, TileMap.WidthInPixels - _viewportRectangle.Width);
        _position.Y = MathHelper.Clamp(_position.Y, 0, TileMap.HeightInPixels - _viewportRectangle.Height);
    }

    public void LockToSprite(AnimatedSprite sprite)
    {
        _position.X = sprite.Position.X + sprite.Width / 2 - (_viewportRectangle.Width / 2);
        _position.Y = sprite.Position.Y + sprite.Height / 2 - (_viewportRectangle.Height / 2);
        LockCamera();
    }

    public void ToggleCameraMode() => CameraMode = CameraMode switch
    {
        CameraMode.Follow => CameraMode.Free,
        CameraMode.Free => CameraMode.Follow,
        _ => throw new NotImplementedException(),
    };

    #endregion
}
