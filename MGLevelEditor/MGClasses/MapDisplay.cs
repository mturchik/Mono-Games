using MGLevelEditor.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGLevelEditor.MGClasses;
public class MapDisplay : MonoGame.Forms.Controls.MonoGameControl
{
    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw()
    {
        base.Draw();
        if (FormMain.map == null)
            return;
        Editor.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: FormMain.camera.Transformation);

        for (int i = 0; i < FormMain.layers.Count; i++)
            FormMain.layers[i].Draw(Editor.spriteBatch, FormMain.camera, FormMain.tileSets);

        Editor.spriteBatch.End();
    }
}
