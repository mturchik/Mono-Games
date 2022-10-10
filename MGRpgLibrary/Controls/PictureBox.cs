namespace MGRpgLibrary.Controls;
public class PictureBox : Control
{
    #region Fields and Properties

    public Texture2D Image { get; set; }
    public Rectangle SourceRect { get; set; }
    public Rectangle DestRect { get; set; }

    #endregion

    #region Constructor

    public PictureBox(Texture2D image, Rectangle destination)
    {
        Image = image;
        DestRect = destination;
        SourceRect = new(0, 0, image.Width, image.Height);
        Color = Color.White;
    }

    public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
    {
        Image = image;
        DestRect = destination;
        SourceRect = source;
        Color = Color.White;
    }

    #endregion

    #region Abstract Methods

    public override void Update(GameTime gameTime) { }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Image, DestRect, SourceRect, Color);
    }

    public override void HandleInput(PlayerIndex playerIndex) { }

    #endregion

    #region PictureBox Methods

    public void SetPosition(Vector2 newPosition)
    {
        DestRect = new((int)newPosition.X, (int)newPosition.Y, SourceRect.Width, SourceRect.Height);
    }

    #endregion
}
