namespace EyesOfTheDragon.GameScreens;
internal class CharacterGeneratorScreen : BaseGameState
{
    #region Fields and Properties

    private LeftRightSelector _nameSelector = null!;
    private LeftRightSelector _genderSelector = null!;
    private LeftRightSelector _classSelector = null!;
    private PictureBox _backgroundImage = null!;
    private readonly string[] _genderItems = { "Male", "Female", "Non-Binary" };
    private readonly string[] _classItems = { "Fighter", "Wizard", "Rogue", "Priest" };
    private readonly string[] _maleName = { "Balthazar", "Logan", "Alfred", "Johnson" };
    private readonly string[] _femaleName = { "Lucinda", "Cynthia", "Ezmarelda", "Millicent" };
    private readonly string[] _nbName = { "Jaime", "Kelly", "Jordan", "Pat" };

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

        _genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _genderSelector.SetItems(_genderItems, 125);
        _genderSelector.Position = new Vector2(label.Position.X, 200);
        _genderSelector.SelectionChanged += OnGenderSelectionChanged;
        ControlManager.Add(_genderSelector);

        _nameSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _nameSelector.SetItems(_maleName, 125);
        _nameSelector.Position = new Vector2(label.Position.X, 250);
        ControlManager.Add(_nameSelector);

        _classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
        _classSelector.SetItems(_classItems, 125);
        _classSelector.Position = new Vector2(label.Position.X, 300);
        ControlManager.Add(_classSelector);

        var linkLabel = new LinkLabel()
        {
            Text = "Accept this character.",
            Position = new Vector2(label.Position.X, 350)
        };
        linkLabel.Selected += OnLinkLabelSelected;
        ControlManager.Add(linkLabel);

        ControlManager.NextControl();
    }

    private void OnGenderSelectionChanged(object? sender, EventArgs e)
    {
        if (_genderSelector.SelectedIndex == 0)
            _nameSelector.SetItems(_maleName, 125);
        else if (_genderSelector.SelectedIndex == 1)
            _nameSelector.SetItems(_femaleName, 125);
        else
            _nameSelector.SetItems(_nbName, 125);
    }

    private void OnLinkLabelSelected(object? sender, EventArgs e)
    {
        InputHandler.Flush();
        StateManager.PopState();
        StateManager.PushState(GameRef.GamePlayScreen);
    }

    #endregion
}
