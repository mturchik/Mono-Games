namespace MGRpgLibrary.TileEngine;
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

    #endregion

    #region Constructor

    public Camera(Rectangle viewportRect)
    {
        _speed = 4f;
        Zoom = 1f;
        _viewportRectangle = viewportRect;
    }

    public Camera(Rectangle viewportRect, Vector2 position)
    {
        _speed = 4f;
        Zoom = 1f;
        _viewportRectangle = viewportRect;
        _position = position;
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
        var motion = Vector2.Zero;

        if (InputHandler.KeyDown(Keys.Left))
            motion.X = -_speed;
        else if (InputHandler.KeyDown(Keys.Right))
            motion.X = _speed;

        if (InputHandler.KeyDown(Keys.Up))
            motion.Y = -_speed;
        else if (InputHandler.KeyDown(Keys.Down))
            motion.Y = _speed;

        if (motion != Vector2.Zero) motion.Normalize();

        _position += motion * _speed;

        LockCamera();
    }

    private void LockCamera()
    {
        _position.X = MathHelper.Clamp(_position.X, 0, TileMap.WidthInPixels - _viewportRectangle.Width);
        _position.Y = MathHelper.Clamp(_position.Y, 0, TileMap.HeightInPixels - _viewportRectangle.Height);
    }

    #endregion
}
