namespace EyesOfTheDragon.GameScreens;
internal class GamePlayScreen : BaseGameState
{
    #region Fields and Properties

    private readonly Engine _engine = new(32, 32);
    private readonly World _world;
    private Player _player = default!;

    #endregion

    #region Constructor

    public GamePlayScreen(Game game, GameStateManager stateManager) : base(game, stateManager)
    {
        _world = new(game, GameRef.ScreenRectangle);
    }

    #endregion

    #region XNA Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        #region Player
        var spriteSheet = Game.Content.Load<Texture2D>(
            @"PlayerSprites\" +
            GameRef.CharacterGeneratorScreen.SelectedGender +
            GameRef.CharacterGeneratorScreen.SelectedClass
        );
        var animations = new Dictionary<AnimationKey, Animation>
        {
            { AnimationKey.Down,  new Animation(3, 32, 32, 0, 0) },
            { AnimationKey.Left,  new Animation(3, 32, 32, 0, 32) },
            { AnimationKey.Right, new Animation(3, 32, 32, 0, 64) },
            { AnimationKey.Up,    new Animation(3, 32, 32, 0, 96) },
        };
        var sprite = new AnimatedSprite(spriteSheet, animations);
        _player = new Player(GameRef, sprite);
        #endregion
        base.LoadContent();
        #region Tilesets
        var tileset1 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset1"), 8, 8, 32, 32);
        var tileset2 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset2"), 8, 8, 32, 32);
        var tilesets = new List<Tileset>() { tileset1, tileset2 };
        #endregion
        #region Layers
        var world = new MapLayer(100, 100);
        for (int y = 0; y < world.Height; y++)
            for (int x = 0; x < world.Width; x++)
                world.SetTile(x, y, new(0, 0));

        var splatter = new MapLayer(100, 100);
        var random = new Random();
        for (int i = 0; i < 100; i++)
        {
            int x = random.Next(0, 100);
            int y = random.Next(0, 100);
            int index = random.Next(2, 14);
            splatter.SetTile(x, y, new(index, 0));
        }
        splatter.SetTile(1, 0, new(0, 1));
        splatter.SetTile(2, 0, new(2, 1));
        splatter.SetTile(3, 0, new(0, 1));
        var layers = new List<MapLayer>() { world, splatter };
        #endregion
        _world.Levels.Add(new Level(new TileMap(tilesets, layers)));
        _world.CurrentLevel = 0;
    }

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: _player.Camera.Transformation);

        _world.DrawLevel(GameRef.SpriteBatch, _player.Camera);
        _player.Draw(gameTime, GameRef.SpriteBatch);
        base.Draw(gameTime);

        GameRef.SpriteBatch.End();
    }

    #endregion

    #region Abstract Methods

    #endregion
}
