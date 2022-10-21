namespace MGRpgLibrary.ItemClasses;
public class GameItemManager
{
    #region Field Region

    public Dictionary<string, GameItem> GameItems { get; } = new();
    public static SpriteFont SpriteFont { get; private set; } = default!;

    #endregion

    #region Constructor Region

    public GameItemManager(SpriteFont spriteFont)
    {
        SpriteFont = spriteFont;
    }

    #endregion

    #region Method Region
    #endregion

    #region Virtual Method region
    #endregion
}
