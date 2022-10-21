namespace EyesOfTheDragon;
internal class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameStateManager _gameStateManager;
    public SpriteBatch SpriteBatch { get; private set; } = null!;
    public TitleScreen TitleScreen { get; private set; }
    public StartMenuScreen StartMenuScreen { get; private set; }
    public GamePlayScreen GamePlayScreen { get; private set; }
    public CharacterGeneratorScreen CharacterGeneratorScreen { get; private set; }
    public SkillScreen SkillScreen { get; private set; }
    public LoadGameScreen LoadGameScreen { get; private set; }

    public const int ScreenWidth = 1280;
    public const int ScreenHeight = 720;
    public readonly Rectangle ScreenRectangle = new(0, 0, ScreenWidth, ScreenHeight);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Components.Add(new InputHandler(this));

        _gameStateManager = new GameStateManager(this);
        Components.Add(_gameStateManager);

        TitleScreen = new TitleScreen(this, _gameStateManager);
        StartMenuScreen = new StartMenuScreen(this, _gameStateManager);
        GamePlayScreen = new GamePlayScreen(this, _gameStateManager);
        CharacterGeneratorScreen = new CharacterGeneratorScreen(this, _gameStateManager);
        SkillScreen = new SkillScreen(this, _gameStateManager);
        LoadGameScreen = new LoadGameScreen(this, _gameStateManager);

        _gameStateManager.ChangeState(TitleScreen);
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = ScreenWidth;
        _graphics.PreferredBackBufferHeight = ScreenHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        DataManager.Load(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        base.Draw(gameTime);
    }
}
