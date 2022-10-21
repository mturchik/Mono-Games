using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;

namespace MGRpgLibrary.CharacterClasses;
public class Character
{
    #region Fields and Properties

    public Entity Entity { get; protected set; }
    public AnimatedSprite Sprite { get; protected set; }
    // Armor
    public GameItem? Head { get; protected set; }
    public GameItem? Body { get; protected set; }
    public GameItem? Hands { get; protected set; }
    public GameItem? Feet { get; protected set; }
    // Weapons
    public GameItem? MainHand { get; protected set; }
    public GameItem? OffHand { get; protected set; }
    public int HandsFree { get; protected set; } = 2;

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

    public virtual bool Equip(GameItem gameItem)
    {
        bool success = false;
        return success;
    }

    public virtual bool Unequip(GameItem gameItem)
    {
        bool success = false;
        return success;
    }

    #endregion
}
