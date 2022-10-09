namespace MGRpgLibrary.Controls;
public class LinkLabel : Control
{
    #region Fields and Properties

    public Color SelectedColor { get; set; }

    #endregion

    #region Constructor

    public LinkLabel()
    {
        SelectedColor = Color.Red;
        TabStop = true;
        HasFocus = false;
        Position = Vector2.Zero;
    }

    #endregion

    #region Abstract Methods

    public override void Update(GameTime gameTime) { }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (HasFocus)
            spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColor);
        else
            spriteBatch.DrawString(SpriteFont, Text, Position, Color);
    }

    public override void HandleInput(PlayerIndex playerIndex)
    {
        if (!HasFocus) return;

        if (InputHandler.KeyReleased(Keys.Enter) || InputHandler.ButtonReleased(Buttons.A, playerIndex))
            OnSelected(EventArgs.Empty);

        if (InputHandler.CheckMouseReleased(MouseButton.Left))
        {
            Size = SpriteFont.MeasureString(Text);

            var r = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            if (r.Contains(InputHandler.MouseAsPoint))
                OnSelected(EventArgs.Empty);
        }
    }

    #endregion
}
