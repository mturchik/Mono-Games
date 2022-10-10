namespace EyesOfTheDragon.GameScreens;
internal class TitleScreen : BaseGameState
{
    #region Fields and Properties

    private Texture2D? _backgroundImage;
    private LinkLabel? _startLabel;

    #endregion

    #region Constructor

    public TitleScreen(Game game, GameStateManager stateManager) : base(game, stateManager) { }

    #endregion

    #region MG Methods

    protected override void LoadContent()
    {
        _backgroundImage = GameRef.Content.Load<Texture2D>(@"Backgrounds\titlescreen");
        base.LoadContent();

        _startLabel = new LinkLabel
        {
            Position = new Vector2(350, 600),
            Text = "Press ENTER to begin",
            Color = Color.White,
            TabStop = true,
            HasFocus = true
        };
        _startLabel.Selected += new EventHandler(OnStarLabelSelected);

        ControlManager.Add(_startLabel);
    }

    public override void Update(GameTime gameTime)
    {
        ControlManager.Update(gameTime, PlayerIndex.One);
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

        ControlManager.Draw(GameRef.SpriteBatch);

        GameRef.SpriteBatch.End();
    }

    #endregion

    #region TitleScreen Methods

    private void OnStarLabelSelected(object? sender, EventArgs e) => StateManager.PushState(GameRef.StartMenuScreen);

    #endregion
}
