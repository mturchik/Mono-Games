using Microsoft.Xna.Framework.Content;
using RpgLibrary.SkillClasses;

namespace EyesOfTheDragon.GameScreens;
internal class SkillScreen : BaseGameState
{
    #region Fields and Properties

    private PictureBox _backgroundImage = default!;
    private Label _pointsRemaining = default!;
    private LinkLabel _acceptLabel = default!;

    private int _skillPoints;
    private int _unassignedPoints;
    public int SkillPoints
    {
        get { return _skillPoints; }
        set
        {
            _skillPoints = value;
            _unassignedPoints = value;
        }
    }

    #endregion

    #region Constructor

    public SkillScreen(Game game, GameStateManager manager) : base(game, manager)
    {
    }

    #endregion

    #region MGMethods

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        ContentManager Content = GameRef.Content;
        CreateControls(Content);
    }

    private void CreateControls(ContentManager Content)
    {
        // Load background onto screen
        _backgroundImage = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"), GameRef.ScreenRectangle);
        ControlManager.Add(_backgroundImage);

        // Create the remaining points label
        var nextControlPosition = new Vector2(300, 150);
        _pointsRemaining = new Label
        {
            Text = "Skill Points: " + _unassignedPoints.ToString(),
            Position = nextControlPosition
        };
        ControlManager.Add(_pointsRemaining);

        // Load data for skill selectors
        var leftArrow = Content.Load<Texture2D>(@"GUI\leftarrowUp");
        var rightArrow = Content.Load<Texture2D>(@"GUI\rightarrowUp");
        var stopBar = Content.Load<Texture2D>(@"GUI\StopBar");
        var skillData = Directory.GetFiles(Content.RootDirectory + @"\Data\Abilities\Skills\", "*.xnb")
            .Select(f => Content.Load<SkillData>(@"Data\Abilities\Skills\" + Path.GetFileNameWithoutExtension(f)));
        foreach (var data in skillData)
        {
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            // Add label for Skill Name
            var label = new Label
            {
                Text = data.Name,
                Position = nextControlPosition
            };
            ControlManager.Add(label);

            // Add spin box for tabstop
            var selector = new IncrementalSelector(leftArrow, rightArrow, stopBar)
            {
                MaximumValue = _unassignedPoints,
                TabStop = true,
                Position = new Vector2(nextControlPosition.X + 450, nextControlPosition.Y)
            };
            selector.Increase += OnSkillIncrease;
            selector.Decrease += OnSkillDecrease;
            ControlManager.Add(selector);
        }

        nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 20f;
        _acceptLabel = new LinkLabel
        {
            Text = "Accept Changes",
            Position = nextControlPosition,
            TabStop = true,
            Enabled = false
        };
        _acceptLabel.Selected += OnSelectAcceptLabel;
        ControlManager.Add(_acceptLabel);

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

    #region Event Handlers

    void OnSelectAcceptLabel(object? sender, EventArgs e)
    {
        StateManager.ChangeState(GameRef.GamePlayScreen);
    }

    void OnSkillIncrease(object? sender, EventArgs e)
    {
        if (sender is not IncrementalSelector selector) return;

        _unassignedPoints += selector.Increment;
        _pointsRemaining.Text = "Skill Points: " + _unassignedPoints.ToString();

        _acceptLabel.Enabled = _unassignedPoints == 0;
    }

    void OnSkillDecrease(object? sender, EventArgs e)
    {
        if (sender is not IncrementalSelector selector) return;

        _unassignedPoints -= selector.Increment;
        _pointsRemaining.Text = "Skill Points: " + _unassignedPoints.ToString();

        _acceptLabel.Enabled = _unassignedPoints == 0;
    }

    #endregion

}
