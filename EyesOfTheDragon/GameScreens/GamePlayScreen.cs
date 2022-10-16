namespace EyesOfTheDragon.GameScreens;
internal class GamePlayScreen : BaseGameState
{
    #region Fields and Properties

    private readonly Engine _engine = new(32, 32);
    public static Player Player { get; set; } = default!;
    public static World World { get; set; } = default!;

    #endregion

    #region Constructor

    public GamePlayScreen(Game game, GameStateManager stateManager) : base(game, stateManager)
    {
    }

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
        World.Update(gameTime);
        Player.Update(gameTime);
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: Player.Camera.Transformation);

        World.DrawLevel(gameTime, GameRef.SpriteBatch, Player.Camera);
        Player.Draw(gameTime, GameRef.SpriteBatch);
        base.Draw(gameTime);

        GameRef.SpriteBatch.End();
    }

    #endregion

    #region Abstract Methods

    #endregion
}
