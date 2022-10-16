using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.TileEngine;

namespace MGRpgLibrary.WorldClasses;
public class Level
{
    #region Fields and Properties

    public TileMap Map { get; }
    public List<Character> Characters { get; } = new();
    public List<ItemSprite> Chests { get; } = new();

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
        Characters.ForEach(c => c.Update(gameTime));
        Chests.ForEach(s => s.Update(gameTime));
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
    {
        Map.Draw(spriteBatch, camera);
        Characters.ForEach(c => c.Draw(gameTime, spriteBatch));
        Chests.ForEach(s => s.Draw(gameTime, spriteBatch));
    }

    #endregion
}
