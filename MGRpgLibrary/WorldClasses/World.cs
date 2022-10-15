using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.WorldClasses;
public class World : DrawableGameComponent
{
    #region Graphic Field and Property Region

    private Rectangle _screenRect;
    public Rectangle ScreenRectangle => _screenRect;

    #endregion

    #region Item Field and Property Region
    #endregion

    #region Level Field and Property Region

    public List<Level> Levels { get; } = new();

    private int _currentLevel = -1;
    public int CurrentLevel
    {
        get { return _currentLevel; }
        set
        {
            if (value < 0 || value >= Levels.Count)
                throw new IndexOutOfRangeException();
            if (Levels[value] == null)
                throw new NullReferenceException();
            _currentLevel = value;
        }
    }

    #endregion

    #region Constructor Region

    public World(Game game, Rectangle screenRectangle) : base(game)
    {
        _screenRect = screenRectangle;
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }

    public void DrawLevel(SpriteBatch spriteBatch, Camera camera)
    {
        Levels[_currentLevel].Draw(spriteBatch, camera);
    }

    #endregion
}
