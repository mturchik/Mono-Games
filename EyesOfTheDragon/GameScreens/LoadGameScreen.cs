using MGRpgLibrary.CharacterClasses;
using RpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.GameScreens;
internal class LoadGameScreen : BaseGameState
{
    #region Fields and Properties

    private PictureBox _backgroundImage = default!;
    private ListBox _loadListBox = default!;
    private LinkLabel _loadLinkLabel = default!;
    private LinkLabel _exitLinkLabel = default!;

    #endregion

    #region Constructor Region

    public LoadGameScreen(Game game, GameStateManager manager)
    : base(game, manager)
    {
    }

    #endregion

    #region Method Region

    protected override void LoadContent()
    {
        base.LoadContent();

        _backgroundImage = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"), GameRef.ScreenRectangle);
        ControlManager.Add(_backgroundImage);

        _loadLinkLabel = new LinkLabel
        {
            Text = "Select game",
            Position = new Vector2(50, 200)
        };
        _loadLinkLabel.Selected += OnLoadLinkLabelSelected;
        ControlManager.Add(_loadLinkLabel);

        _exitLinkLabel = new LinkLabel
        {
            Text = "Back"
        };
        _exitLinkLabel.Position = new Vector2(50, 200 + _exitLinkLabel.SpriteFont.LineSpacing);
        _exitLinkLabel.Selected += OnExitLinkLabelSelected;
        ControlManager.Add(_exitLinkLabel);

        _loadListBox = new ListBox(
            Game.Content.Load<Texture2D>(@"GUI\listBoxImage"),
            Game.Content.Load<Texture2D>(@"GUI\rightarrowUp")
        )
        {
            Position = new Vector2(400, 100)
        };
        _loadListBox.Selected += OnLoadListBoxSelected;
        _loadListBox.Leave += OnLoadListBoxLeave;
        for (int i = 0; i < 5; i++)
            _loadListBox.Items.Add("Game number: " + i.ToString());
        ControlManager.Add(_loadListBox);

        ControlManager.NextControl();
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
        ControlManager.Draw(GameRef.SpriteBatch);
        GameRef.SpriteBatch.End();
    }

    #endregion

    #region Method Region

    void OnLoadLinkLabelSelected(object? sender, EventArgs e)
    {
        ControlManager.AcceptInput = false;
        _loadLinkLabel.HasFocus = false;
        _loadListBox.HasFocus = true;
    }

    void OnExitLinkLabelSelected(object? sender, EventArgs e)
    {
        StateManager.PopState();
    }

    void OnLoadListBoxLeave(object? sender, EventArgs e)
    {
        ControlManager.AcceptInput = true;
    }

    void OnLoadListBoxSelected(object? sender, EventArgs e)
    {
        _loadLinkLabel.HasFocus = true;
        _loadListBox.HasFocus = false;
        ControlManager.AcceptInput = true;
        StateManager.ChangeState(GameRef.GamePlayScreen);
        CreatePlayer();
        CreateWorld();
    }

    private void CreatePlayer()
    {
        var animations = new Dictionary<AnimationKey, Animation>
        {
            { AnimationKey.Down,  new Animation(3, 32, 32, 0, 0) },
            { AnimationKey.Left,  new Animation(3, 32, 32, 0, 32) },
            { AnimationKey.Right, new Animation(3, 32, 32, 0, 64) },
            { AnimationKey.Up,    new Animation(3, 32, 32, 0, 96) },
        };
        var sprite = new AnimatedSprite(GameRef.Content.Load<Texture2D>(@"PlayerSprites\malefighter"), animations);
        var entity = new Entity("Incel", DataManager.ClassData["Fighter"], RpgLibrary.EntityGender.Male, RpgLibrary.EntityType.Character);
        var character = new Character(entity, sprite);
        GamePlayScreen.Player = new Player(GameRef, character);
    }

    private void CreateWorld()
    {
        #region Tilesets
        var tileset1 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset1"), 8, 8, 32, 32);
        var tileset2 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset2"), 8, 8, 32, 32);
        var tilesets = new List<Tileset>() { tileset1, tileset2 };
        #endregion
        #region Layers
        var layer = new MapLayer(100, 100);
        for (int y = 0; y < layer.Height; y++)
            for (int x = 0; x < layer.Width; x++)
                layer.SetTile(x, y, new(0, 0));

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
        var layers = new List<MapLayer>() { layer, splatter };
        #endregion
        var world = new World(GameRef, GameRef.ScreenRectangle);
        world.Levels.Add(new Level(new TileMap(tilesets, layers)));
        world.CurrentLevel = 0;
        GamePlayScreen.World = world;
    }

    #endregion
}
