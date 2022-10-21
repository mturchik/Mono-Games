using MGRpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.Components;
internal class Player
{
    #region Fields and Properties

    private readonly Game1 _gameRef;
    public Character Character { get; }
    public AnimatedSprite Sprite => Character.Sprite;
    public Camera Camera { get; set; }

    #endregion

    #region Constructor Region

    public Player(Game game, Character character)
    {
        _gameRef = (Game1)game;
        Camera = new Camera(_gameRef.ScreenRectangle);
        Character = character;
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
        Camera.Update(gameTime);
        Sprite.Update(gameTime);
        #region Camera Input
        if (InputHandler.KeyReleased(Keys.PageUp) || InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
        {
            Camera.ZoomIn();
            if (Camera.CameraMode == CameraMode.Follow)
                Camera.LockToSprite(Sprite);
        }
        else if (InputHandler.KeyReleased(Keys.PageDown) || InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
        {
            Camera.ZoomOut();
            if (Camera.CameraMode == CameraMode.Follow)
                Camera.LockToSprite(Sprite);
        }
        #endregion
        #region Movement Input
        var motion = new Vector2();
        if (InputHandler.KeyDown(Keys.W) || InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
        {
            Sprite.CurrentAnimation = AnimationKey.Up;
            motion.Y = -1;
        }
        else if (InputHandler.KeyDown(Keys.S) || InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
        {
            Sprite.CurrentAnimation = AnimationKey.Down;
            motion.Y = 1;
        }

        if (InputHandler.KeyDown(Keys.A) || InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
        {
            Sprite.CurrentAnimation = AnimationKey.Left;
            motion.X = -1;
        }
        else if (InputHandler.KeyDown(Keys.D) || InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
        {
            Sprite.CurrentAnimation = AnimationKey.Right;
            motion.X = 1;
        }

        if (motion != Vector2.Zero)
        {
            Sprite.IsAnimating = true;
            motion.Normalize();
            Sprite.Position += motion * Sprite.Speed;
            Sprite.LockToMap();

            if (Camera.CameraMode == CameraMode.Follow)
                Camera.LockToSprite(Sprite);
        }
        else
        {
            Sprite.IsAnimating = false;
        }
        #endregion
        #region Camera Manipulation Toggles
        if (InputHandler.KeyReleased(Keys.F) || InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
        {
            Camera.ToggleCameraMode();
            if (Camera.CameraMode == CameraMode.Follow)
                Camera.LockToSprite(Sprite);
        }

        if (Camera.CameraMode != CameraMode.Follow)
        {
            if (InputHandler.KeyReleased(Keys.C) || InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
            {
                Camera.LockToSprite(Sprite);
            }
        }
        #endregion
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Character.Draw(gameTime, spriteBatch);
    }

    #endregion
}
