namespace MGRpgLibrary;
public abstract partial class GameState : DrawableGameComponent
{
    #region Fields and Properties

    public List<GameComponent> Components { get; }
    public GameState Tag { get; }
    protected GameStateManager StateManager;

    #endregion

    #region Constructor

    public GameState(Game game, GameStateManager stateManager) : base(game)
    {
        StateManager = stateManager;
        Components = new();
        Tag = this;
    }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        Components.ForEach(c =>
        {
            if (c.Enabled)
                c.Update(gameTime);
        });
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        Components.ForEach(c =>
        {
            if (c is DrawableGameComponent component && component.Visible)
                component.Draw(gameTime);
        });
        base.Draw(gameTime);
    }

    #endregion

    #region GameState Methods

    internal protected virtual void StateChange(object? sender, EventArgs e)
    {
        if (StateManager.CurrentState == Tag)
            Show();
        else
            Hide();
    }

    protected virtual void Show()
    {
        Visible = true;
        Enabled = true;
        Components.ForEach(c =>
        {
            c.Enabled = true;
            if (c is DrawableGameComponent component)
                component.Visible = true;
        });
    }

    protected virtual void Hide()
    {
        Visible = false;
        Enabled = false;
        Components.ForEach(c =>
        {
            c.Enabled = false;
            if (c is DrawableGameComponent component)
                component.Visible = false;
        });
    }

    #endregion
}
