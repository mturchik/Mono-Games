using RpgLibrary.ItemClasses;

namespace MGRpgLibrary.WorldClasses;
public class World
{
    #region Graphic Field and Property Region

    private Rectangle _screenRect;
    public Rectangle ScreenRectangle => _screenRect;

    #endregion

    #region Item Field and Property Region

    ItemManager itemManager = new ItemManager();

    #endregion

    #region Level Field and Property Region
    #endregion

    #region Constructor Region

    public World(Rectangle screenRectangle)
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

    #endregion
}
