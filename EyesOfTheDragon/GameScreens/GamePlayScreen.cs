
namespace EyesOfTheDragon.GameScreens;
internal class GamePlayScreen : BaseGameState
{
    #region Fields and Properties

    private readonly Engine _engine = new(32, 32);
    private readonly Player _player;
    private TileMap _map = null!;

    #endregion

    #region Constructor

    public GamePlayScreen(Game game, GameStateManager stateManager) : base(game, stateManager)
    {
        _player = new(game);
    }

    #endregion

    #region XNA Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        var tileset1 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset1"), 8, 8, 32, 32);
        var tileset2 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset2"), 8, 8, 32, 32);
        var tilesets = new List<Tileset>() { tileset1, tileset2 };

        var world = new MapLayer(40, 40);
        for (int y = 0; y < world.Height; y++)
            for (int x = 0; x < world.Width; x++)
                world.SetTile(x, y, new(1, 0));

        var splatter = new MapLayer(40, 40);
        var random = new Random();
        for (int i = 0; i < 80; i++)
        {
            int x = random.Next(0, 40);
            int y = random.Next(0, 40);
            int index = random.Next(2, 14);
            splatter.SetTile(x, y, new(index, 0));
        }
        splatter.SetTile(1, 0, new(0, 1));
        splatter.SetTile(2, 0, new(2, 1));
        splatter.SetTile(3, 0, new(0, 1));

        var layers = new List<MapLayer>() { world, splatter };

        _map = new(tilesets, layers);
    }

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: Matrix.Identity);

        _map.Draw(GameRef.SpriteBatch, _player.Camera);
        base.Draw(gameTime);

        GameRef.SpriteBatch.End();
    }

    #endregion

    #region Abstract Methods

    #endregion
}
