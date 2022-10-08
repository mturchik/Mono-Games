namespace EyesOfTheDragon.GameScreens;
public abstract partial class BaseGameState : GameState
{
    #region Fields and Properties

    protected readonly Game1 GameRef;

    #endregion

    #region Constructor

    protected BaseGameState(Game game, GameStateManager stateManager) : base(game, stateManager)
    {
        GameRef = (Game1)game;
    }

    #endregion
}
