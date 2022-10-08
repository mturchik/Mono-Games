namespace EyesOfTheDragon.GameScreens;
public class TitleScreen : BaseGameState
{
    #region Fields and Properties

    private Texture2D? _backgroundImage;

    #endregion

    #region Constructor

    public TitleScreen(Game game, GameStateManager stateManager) : base(game, stateManager) { }

    #endregion

    #region MG Methods

    protected override void LoadContent()
    {
        _backgroundImage = GameRef.Content.Load<Texture2D>(@"Backgrounds\titlescreen");
        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin();
        base.Draw(gameTime);

        GameRef.SpriteBatch.Draw(
            _backgroundImage,
            GameRef.ScreenRectangle,
            Color.White
        );

        GameRef.SpriteBatch.End();
    }

    #endregion
}
