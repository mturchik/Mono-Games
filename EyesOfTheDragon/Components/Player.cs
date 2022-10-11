namespace EyesOfTheDragon.Components;
internal class Player
{
    #region Fields and Properties

    private readonly Game1 _gameRef;
    public Camera Camera { get; set; }

    #endregion

    #region Constructor Region

    public Player(Game game)
    {
        _gameRef = (Game1)game;
        Camera = new Camera(_gameRef.ScreenRectangle);
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
        Camera.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }

    #endregion
}
