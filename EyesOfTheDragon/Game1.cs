namespace EyesOfTheDragon;
public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameStateManager _gameStateManager;
    public SpriteBatch SpriteBatch { get; private set; }
    public TitleScreen TitleScreen { get; private set; }
    public StartMenuScreen StartMenuScreen { get; private set; }

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
