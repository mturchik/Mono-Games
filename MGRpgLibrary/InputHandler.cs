using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary;
public class InputHandler : GameComponent
{
    #region Fields and Properties

    private static KeyboardState _keyboardState;
    public static KeyboardState KeyboardState => _keyboardState;

    private static KeyboardState _lastKeyboardState;
    public static KeyboardState LastKeyboardState => _lastKeyboardState;

    #endregion

    #region Constructor

    public InputHandler(Game game) : base(game)
    {
        _keyboardState = Keyboard.GetState();
    }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        _lastKeyboardState = _keyboardState;
        _keyboardState = Keyboard.GetState();
        base.Update(gameTime);
    }

    #endregion

    #region General Methods

    public static void Flush()
    {
        _lastKeyboardState = _keyboardState;
    }

    #endregion

    #region Keyboard Methods

    /// <summary>
    /// Key is currently up, but previously down
    /// </summary>
    public static bool KeyReleased(Keys key) => _keyboardState.IsKeyUp(key) && _lastKeyboardState.IsKeyDown(key);

    /// <summary>
    /// Key is currently down, but previously up
    /// </summary>
    public static bool KeyPressed(Keys key) => _keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key);

    /// <summary>
    /// Key is currently down
    /// </summary>
    public static bool KeyDown(Keys key) => _keyboardState.IsKeyDown(key);

    #endregion
}
