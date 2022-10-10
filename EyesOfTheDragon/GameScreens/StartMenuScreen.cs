namespace EyesOfTheDragon.GameScreens;
internal class StartMenuScreen : BaseGameState
{
    #region Fields and Properties

    private PictureBox _backgroundImage = null!;
    private PictureBox _arrowImage = null!;
    private LinkLabel _startGame = null!;
    private LinkLabel _loadGame = null!;
    private LinkLabel _exitGame = null!;
    private float _maxItemWidth = 0f;

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

        var content = Game.Content;

        _backgroundImage = new PictureBox(content.Load<Texture2D>(@"Backgrounds\titlescreen"), GameRef.ScreenRectangle);
        ControlManager.Add(_backgroundImage);

        var arrowTexture = content.Load<Texture2D>(@"GUI\leftarrowUp");
        _arrowImage = new PictureBox(arrowTexture, new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));
        ControlManager.Add(_arrowImage);

        _startGame = new() { Text = "The story begins" };
        _startGame.Size = _startGame.SpriteFont.MeasureString(_startGame.Text);
        _startGame.Selected += OnMenuItemSelected;
        ControlManager.Add(_startGame);

        _loadGame = new() { Text = "The story continues" };
        _loadGame.Size = _loadGame.SpriteFont.MeasureString(_loadGame.Text);
        _loadGame.Selected += OnMenuItemSelected;
        ControlManager.Add(_loadGame);

        _exitGame = new() { Text = "The story ends" };
        _exitGame.Size = _loadGame.SpriteFont.MeasureString(_exitGame.Text);
        _exitGame.Selected += OnMenuItemSelected;
        ControlManager.Add(_exitGame);

        ControlManager.NextControl();
        ControlManager.FocusChanged += OnControlManagerFocusChanged;

        var position = new Vector2(350, 500);
        foreach (Control c in ControlManager)
        {
            if (c is LinkLabel)
            {
                if (c.Size.X > _maxItemWidth) _maxItemWidth = c.Size.X;

                c.Position = position;
                position.Y += c.Size.Y + 5f;
            }
        }

        OnControlManagerFocusChanged(_startGame, EventArgs.Empty);
    }

    public override void Update(GameTime gameTime)
    {
        ControlManager.Update(gameTime, PlayerIndexInControl);
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin();
        base.Draw(gameTime);
        ControlManager.Draw(GameRef.SpriteBatch);
        GameRef.SpriteBatch.End();
    }

    #endregion

    #region GameState Methods

    private void OnMenuItemSelected(object? sender, EventArgs e)
    {
        if (sender == _startGame) StateManager.PushState(GameRef.GamePlayScreen);

        if (sender == _loadGame) StateManager.PushState(GameRef.GamePlayScreen);

        if (sender == _exitGame) GameRef.Exit();
    }

    private void OnControlManagerFocusChanged(object? sender, EventArgs e)
    {
        if (sender is not Control control) return;
        var position = new Vector2(control.Position.X + _maxItemWidth + 10f, control.Position.Y);
        _arrowImage.SetPosition(position);
    }

    #endregion
}
