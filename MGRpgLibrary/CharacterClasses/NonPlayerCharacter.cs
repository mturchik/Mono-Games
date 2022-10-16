using MGRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ConversationClasses;
using RpgLibrary.QuestClasses;

namespace MGRpgLibrary.CharacterClasses;
public class NonPlayerCharacter : Character
{
    #region Fields and Properties

    public List<Conversation> Conversations { get; }
    public bool HasConversation => Conversations.Count > 0;

    public List<Quest> Quests { get; }
    public bool HasQuest => Quests.Count > 0;

    #endregion

    #region Constructor Region

    public NonPlayerCharacter(Entity entity, AnimatedSprite sprite)
    : base(entity, sprite)
    {
        Conversations = new List<Conversation>();
        Quests = new List<Quest>();
    }

    #endregion

    #region Method Region
    #endregion

    #region Virtual Method region

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }

    #endregion
}
