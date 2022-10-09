using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary;
public enum MouseButton { Left, Middle, Right }
public class InputHandler : GameComponent
{
    #region Fields and Properties

    public static KeyboardState KeyboardState { get; private set; }
    public static KeyboardState LastKeyboardState { get; private set; }

    public static MouseState MouseState { get; private set; }
    public static MouseState LastMouseState { get; private set; }

    public static GamePadState[] GamePadStates { get; private set; } = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
    public static GamePadState[] LastGamePadStates { get; private set; } = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];


    #endregion

    #region Constructor

    public InputHandler(Game game) : base(game)
    {
        KeyboardState = Keyboard.GetState();
        MouseState = Mouse.GetState();
        foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            GamePadStates[(int)index] = GamePad.GetState(index);
    }

    #endregion

    #region MG Methods

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        LastKeyboardState = KeyboardState;
        KeyboardState = Keyboard.GetState();

        LastMouseState = MouseState;
        MouseState = Mouse.GetState();

        LastGamePadStates = (GamePadState[])GamePadStates.Clone();
        foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            GamePadStates[(int)index] = GamePad.GetState(index);

        base.Update(gameTime);
    }

    #endregion

    #region General Methods

    public static void Flush()
    {
        LastKeyboardState = KeyboardState;
        LastMouseState = MouseState;
    }

    #endregion

    #region Keyboard Methods

    public static bool KeyReleased(Keys key) => KeyboardState.IsKeyUp(key) && LastKeyboardState.IsKeyDown(key);
    public static bool KeyPressed(Keys key) => KeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key);
    public static bool KeyDown(Keys key) => KeyboardState.IsKeyDown(key);

    #endregion

    #region Mouse Methods

    public static Point MouseAsPoint => new(MouseState.X, MouseState.Y);
    public static Vector2 MouseAsVector2 => new(MouseState.X, MouseState.Y);
    public static Point LastMouseAsPoint => new(MouseState.X, MouseState.Y);
    public static Vector2 LastMouseAsVector2 => new(LastMouseState.X, LastMouseState.Y);

    public static bool CheckMousePress(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Pressed
                            && LastMouseState.LeftButton == ButtonState.Released,
        MouseButton.Right => MouseState.RightButton == ButtonState.Pressed
                            && LastMouseState.RightButton == ButtonState.Released,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Pressed
                            && LastMouseState.MiddleButton == ButtonState.Released,
        _ => false,
    };

    public static bool CheckMouseReleased(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Released
                            && LastMouseState.LeftButton == ButtonState.Pressed,
        MouseButton.Right => MouseState.RightButton == ButtonState.Released
                            && LastMouseState.RightButton == ButtonState.Pressed,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Released
                            && LastMouseState.MiddleButton == ButtonState.Pressed,
        _ => false,
    };

    public static bool IsMouseDown(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Pressed,
        MouseButton.Right => MouseState.RightButton == ButtonState.Pressed,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Pressed,
        _ => false,
    };

    public static bool IsMouseUp(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Pressed,
        MouseButton.Right => MouseState.RightButton == ButtonState.Pressed,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Pressed,
        _ => false,
    };

    #endregion

    #region GamePad Methods

    public static bool ButtonReleased(Buttons button, PlayerIndex index)
        => GamePadStates[(int)index].IsButtonUp(button) && LastGamePadStates[(int)index].IsButtonDown(button);
    public static bool ButtonPressed(Buttons button, PlayerIndex index)
        => GamePadStates[(int)index].IsButtonDown(button) && LastGamePadStates[(int)index].IsButtonUp(button);
    public static bool ButtonDown(Buttons button, PlayerIndex index) => GamePadStates[(int)index].IsButtonDown(button);

    #endregion
}
