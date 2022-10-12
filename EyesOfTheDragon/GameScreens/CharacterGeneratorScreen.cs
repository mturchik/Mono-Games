namespace EyesOfTheDragon.GameScreens;
internal class CharacterGeneratorScreen : BaseGameState
{
    #region Fields and Properties

    private LeftRightSelector _nameSelector = null!;
    private LeftRightSelector _genderSelector = null!;
    private LeftRightSelector _classSelector = null!;
    private PictureBox _backgroundImage = null!;
    private PictureBox _characterImage = null!;
    private Texture2D[,] _characterImages = null!;
    private readonly string[] _genderItems = { "Male", "Female", "Non-Binary" };
    private readonly string[] _classItems = { "Fighter", "Wizard", "Rogue", "Priest" };
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
        LoadImages();
        CreateControls();
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
        StateManager.PopState();
        StateManager.PushState(GameRef.GamePlayScreen);
    }

    #endregion
}
