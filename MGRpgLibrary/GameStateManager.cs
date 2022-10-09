namespace MGRpgLibrary;
public class GameStateManager : GameComponent
{
    #region Events

    public event EventHandler? OnStateChange;

    #endregion

    #region Fields and Properties

    private readonly Stack<GameState> _gameStates = new();
    private const int _startDrawOrder = 5000;
    private const int _drawOrderInc = 100;
    private int _drawOrder;

    public GameState CurrentState => _gameStates.Peek();

    #endregion

    #region Constructor

    public GameStateManager(Game game) : base(game)
    {
        _drawOrder = _startDrawOrder;
    }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    #endregion

    #region StateManager Methods

    public void PopState()
    {
        if (_gameStates.Count == 0) return;

        RemoveState();
        _drawOrder -= _drawOrderInc;

        OnStateChange?.Invoke(this, EventArgs.Empty);
    }

    private void RemoveState()
    {
        var state = _gameStates.Peek();
        OnStateChange -= state.StateChange;
        Game.Components.Remove(state);
        _gameStates.Pop();

    }

    public void PushState(GameState newState)
    {
        _drawOrder += _drawOrderInc;
        newState.DrawOrder = _drawOrder;
        AddState(newState);

        OnStateChange?.Invoke(this, EventArgs.Empty);
    }

    private void AddState(GameState newState)
    {
        _gameStates.Push(newState);
        Game.Components.Add(newState);
        OnStateChange += newState.StateChange;
    }

    public void ChangeState(GameState newState)
    {
        while (_gameStates.Count > 0) RemoveState();

        newState.DrawOrder = _startDrawOrder;
        _drawOrder = _startDrawOrder;
        AddState(newState);

        OnStateChange?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
