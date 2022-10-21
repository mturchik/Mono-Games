using RpgLibrary.ItemClasses;

namespace MGRpgLibrary.ItemClasses;
public class GameItem
{
    #region Field Region

    public Vector2 Position;
    public Rectangle? SourceRectangle;
    public Texture2D Image { get; }
    public BaseItem Item { get; }
    public Type Type { get; }

    #endregion

    #region Constructor Region

    public GameItem(BaseItem item, Texture2D texture, Rectangle? source)
    {
        Item = item;
        Image = texture;
        SourceRectangle = source;
        Type = item.GetType();
    }

    #endregion

    #region Method Region

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Image, Position, SourceRectangle, Color.White);
    }

    #endregion

    #region Virtual Method region
    #endregion
}
