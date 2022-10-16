using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.WorldClasses;
public class Level
{
    #region Fields and Properties

    public TileMap Map { get; }
    public List<Character> Characters { get; }

    #endregion

    #region Constructor

    public Level(TileMap tileMap)
    {
        Map = tileMap;
        Characters = new List<Character>();
    }

    #endregion

    #region Method Region

    public void Update(GameTime gameTime)
    {
        Characters.ForEach(c => c.Update(gameTime));
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
    {
        Map.Draw(spriteBatch, camera);
        Characters.ForEach(c => c.Draw(gameTime, spriteBatch));
    }

    #endregion
}
