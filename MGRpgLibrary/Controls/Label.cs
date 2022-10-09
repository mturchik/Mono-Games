namespace MGRpgLibrary.Controls;
public class Label : Control
{
    #region Constructor

    public Label()
    {
        TabStop = false;
    }

    #endregion

    #region Abstract Methods

    public override void Update(GameTime gameTime) { }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(SpriteFont, Text, Position, Color);
    }

    public override void HandleInput(PlayerIndex playerIndex) { }

    #endregion
}
