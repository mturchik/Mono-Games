using MGRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens;
public abstract partial class BaseGameState : GameState
{
    #region Fields and Properties

    protected Game1 GameRef;
    protected ControlManager ControlManager;
    protected PlayerIndex PlayerIndexInControl;

    #endregion

    #region Constructor

    protected BaseGameState(Game game, GameStateManager stateManager) : base(game, stateManager)
    {
        GameRef = (Game1)game;
        PlayerIndexInControl = PlayerIndex.One;
    }

    #endregion

    #region XNA Methods

    protected override void LoadContent()
    {
        var menuFont = Game.Content.Load<SpriteFont>(@"Fonts\ControlFont");
        ControlManager = new(menuFont);
        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }

    #endregion
}
