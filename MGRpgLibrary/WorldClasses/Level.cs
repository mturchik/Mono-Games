using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.WorldClasses;
public class Level
{
    #region Fields and Properties

    public TileMap Map { get; }

    #endregion

    #region Constructor

    public Level(TileMap tileMap)
    {
        Map = tileMap;
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spiteBatch, Camera camera)
    {
        Map.Draw(spiteBatch, camera);
    }

    #endregion
}
