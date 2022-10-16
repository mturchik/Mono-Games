using MGRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;

namespace MGRpgLibrary.CharacterClasses;
public class Character
{
    #region Fields and Properties

    public Entity Entity { get; protected set; }
    public AnimatedSprite Sprite { get; protected set; }

    #endregion

    #region Constructor

    public Character(Entity entity, AnimatedSprite sprite)
    {
        Entity = entity;
        Sprite = sprite;
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public virtual void Update(GameTime gameTime)
    {
        Entity.Update(gameTime.ElapsedGameTime);
        Sprite.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Sprite.Draw(gameTime, spriteBatch);
    }

    #endregion
}
