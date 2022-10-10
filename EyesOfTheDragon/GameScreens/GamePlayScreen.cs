using MGRpgLibrary.TileEngine;

namespace EyesOfTheDragon.GameScreens;
internal class GamePlayScreen : BaseGameState
{
    #region Fields and Properties

    private readonly Engine _engine = new(32, 32);
    private Tileset _tileset = null!;
    private TileMap _map = null!;

    #endregion

    #region Constructor

    public GamePlayScreen(Game game, GameStateManager stateManager) : base(game, stateManager) { }

    #endregion

    #region XNA Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");

        _tileset = new Tileset(tilesetTexture, 8, 8, 32, 32);

        var layer = new MapLayer(8, 8);
        for (int y = 0; y < layer.Height; y++)
            for (int x = 0; x < layer.Width; x++)
                layer.SetTile(x, y, new Tile(1, 0));
        _map = new(_tileset, layer);

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: Matrix.Identity);

        _map.Draw(GameRef.SpriteBatch);
        base.Draw(gameTime);

        GameRef.SpriteBatch.End();
    }

    #endregion

    #region Abstract Methods

    #endregion
}
