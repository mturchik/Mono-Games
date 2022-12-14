using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ItemClasses;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace EyesOfTheDragon.GameScreens;
internal class CharacterGeneratorScreen : BaseGameState
{
    #region Fields and Properties

    private LeftRightSelector _nameSelector = default!;
    private LeftRightSelector _genderSelector = default!;
    private LeftRightSelector _classSelector = default!;
    private PictureBox _backgroundImage = default!;
    private PictureBox _characterImage = default!;
    private Texture2D[,] _characterImages = default!;
    private Texture2D _containers = default!;
    private readonly string[] _genderItems = { "Male", "Female", "Non-Binary" };
    private string[] _classItems = Array.Empty<string>();
    private readonly string[] _maleName = { "Balthazar", "Logan", "Alfred", "Johnson" };
    private readonly string[] _femaleName = { "Lucinda", "Cynthia", "Ezmarelda", "Millicent" };
    private readonly string[] _nbName = { "Jaime", "Kelly", "Jordan", "Pat" };

    public string SelectedGender => _genderSelector.SelectedIndex < 2 ? _genderSelector.SelectedItem : _genderItems[1];
    public string SelectedClass => _classSelector.SelectedItem;

    #endregion

    #region Constructor

    public CharacterGeneratorScreen(Game game, GameStateManager stateManager) : base(game, stateManager) { }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        _classItems = DataManager.ClassData.Keys.Select(k => DataManager.ClassData[k].Name).ToArray();

        LoadImages();
        CreateControls();
        _containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
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

    #region Methods

    private void CreateControls()
    {
        Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
        Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
        Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

        _backgroundImage = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"), GameRef.ScreenRectangle);
        ControlManager.Add(_backgroundImage);

        var label = new Label() { Text = "Who will search for the Eyes of the Dragon?" };
        label.Size = label.SpriteFont.MeasureString(label.Text);
        label.Position = new Vector2((GameRef.Window.ClientBounds.Width - label.Size.X) / 2, 150);
        ControlManager.Add(label);

        _nameSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _nameSelector.SetItems(_maleName, 125);
        _nameSelector.Position = new Vector2(label.Position.X, 200);
        ControlManager.Add(_nameSelector);

        _genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _genderSelector.SetItems(_genderItems, 125);
        _genderSelector.Position = new Vector2(label.Position.X, 250);
        _genderSelector.SelectionChanged += OnGenderSelectionChanged;
        ControlManager.Add(_genderSelector);

        _classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _classSelector.SetItems(_classItems, 125);
        _classSelector.Position = new Vector2(label.Position.X, 300);
        _classSelector.SelectionChanged += OnClassSelectionChanged;
        ControlManager.Add(_classSelector);

        var linkLabel = new LinkLabel()
        {
            Text = "Accept this character.",
            Position = new Vector2(label.Position.X, 350)
        };
        linkLabel.Selected += OnLinkLabelSelected;
        ControlManager.Add(linkLabel);

        _characterImage = new PictureBox(_characterImages[0, 0], new Rectangle(600, 200, 96, 96), new Rectangle(0, 0, 32, 32));
        ControlManager.Add(_characterImage);

        ControlManager.NextControl();
    }

    private void LoadImages()
    {
        _characterImages = new Texture2D[_genderItems.Length, _classItems.Length];
        for (int i = 0; i < _genderItems.Length - 1; i++)
            for (int j = 0; j < _classItems.Length; j++)
                _characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\" + _genderItems[i] + _classItems[j]);
    }

    private void OnClassSelectionChanged(object? sender, EventArgs e)
    {
        if (_genderSelector.SelectedIndex != 2)
            _characterImage.Image = _characterImages[_genderSelector.SelectedIndex, _classSelector.SelectedIndex];
        else
            _characterImage.Image = _characterImages[1, _classSelector.SelectedIndex];
    }

    private void OnGenderSelectionChanged(object? sender, EventArgs e)
    {
        if (_genderSelector.SelectedIndex == 0)
            _nameSelector.SetItems(_maleName, 125);
        else if (_genderSelector.SelectedIndex == 1)
            _nameSelector.SetItems(_femaleName, 125);
        else
            _nameSelector.SetItems(_nbName, 125);

        OnClassSelectionChanged(sender, e);
    }

    private void OnLinkLabelSelected(object? sender, EventArgs e)
    {
        InputHandler.Flush();

        CreatePlayer();
        CreateWorld();

        GameRef.SkillScreen.SkillPoints = 25;
        StateManager.ChangeState(GameRef.SkillScreen);
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
        var genderStr = _genderSelector.SelectedIndex < 2 ? _genderSelector.SelectedIndex : 1;
        var sprite = new AnimatedSprite(_characterImages[genderStr, _classSelector.SelectedIndex], animations);

        var gender = _genderSelector.SelectedIndex switch
        {
            0 => EntityGender.Male,
            1 => EntityGender.Female,
            2 => EntityGender.NonBinary,
            _ => EntityGender.Unknown
        };
        var entity = new Entity(_nameSelector.SelectedItem, DataManager.ClassData[_classSelector.SelectedItem], gender, EntityType.Character);

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
        #region Level
        var level = new Level(new TileMap(tilesets, layers));
        var chest = new Chest(new ChestData
        {
            Name = "Some Chest",
            MinGold = 10,
            MaxGold = 101
        });
        var chestSprite = new BaseSprite(_containers, new Rectangle(0, 0, 32, 32), new Point(10, 10));
        level.Chests.Add(new ItemSprite(chest, chestSprite));
        #endregion
        var world = new World(GameRef, GameRef.ScreenRectangle);
        world.Levels.Add(level);
        world.CurrentLevel = 0;
        GamePlayScreen.World = world;
    }

    #endregion
}
