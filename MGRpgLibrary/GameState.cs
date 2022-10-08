using Microsoft.Xna.Framework;

namespace MGRpgLibrary;
public abstract partial class GameState : DrawableGameComponent
{
    #region Fields and Properties

    private List<GameComponent> _childComponents;
    public List<GameComponent> Components => _childComponents;

    private GameState _tag;
    public GameState Tag => _tag;

    protected GameStateManager StateManager;

    #endregion

    #region Constructor

    public GameState(Game game, GameStateManager stateManager) : base(game)
    {
        StateManager = stateManager;
        _childComponents = new();
        _tag = this;
    }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        _childComponents.ForEach(c =>
        {
            if (c.Enabled) c.Update(gameTime);
        });
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        DrawableGameComponent drawComponent;

        _childComponents.ForEach(c =>
        {
            if (c is DrawableGameComponent)
            {
                drawComponent = c as DrawableGameComponent;
                if (drawComponent.Visible) drawComponent.Draw(gameTime);
            }
        });
        base.Draw(gameTime);
    }

    #endregion

}
