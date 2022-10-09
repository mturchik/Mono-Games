namespace EyesOfTheDragon.GameScreens;
public class StartMenuScreen : BaseGameState
{
    #region Fields and Properties

    #endregion

    #region Constructor

    public StartMenuScreen(Game game, GameStateManager stateManager) : base(game, stateManager) { }

    #endregion

    #region XNA Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        if (InputHandler.KeyReleased(Keys.Escape)) Game.Exit();

        base.Draw(gameTime);
    }

    #endregion

    #region GameState Methods

    #endregion
}
