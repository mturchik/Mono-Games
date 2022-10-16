using MGRpgLibrary.SpriteClasses;
using RpgLibrary.ItemClasses;

namespace MGRpgLibrary.ItemClasses;
public class ItemSprite
{
    #region Fields and Properties

    public BaseSprite Sprite { get; }
    public BaseItem Item { get; }

    #endregion

    #region Constructor Region

    public ItemSprite(BaseItem item, BaseSprite sprite)
    {
        Item = item;
        Sprite = sprite;
    }

    #endregion

    #region Method Region
    #endregion

    #region Virtual Method region

    public virtual void Update(GameTime gameTime)
    {
        Sprite.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Sprite.Draw(gameTime, spriteBatch);
    }

    #endregion
}
