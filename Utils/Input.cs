using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Utils
{
    public class Input
    {
        // FIELDS
        private MouseState mouseState;
        private MouseState oldMouse;
        private KeyboardState keyboardState;
        private KeyboardState oldKeyboard;
        private GamePadState gamepadState;
        private GamePadState oldGPState;

        // CONSTRUCTORS
        public Input() {}

        // PROPERTIES
        public MouseState MouseState { get { return this.mouseState; } set { this.mouseState = value; } }
        public KeyboardState KeyboardState { get { return this.keyboardState; } set  { this.keyboardState = value; } }

        // METHODS
        public void Update()
        {
            this.mouseState = Mouse.GetState();//Mouse.GetState();
            this.keyboardState = Keyboard.GetState();
            this.gamepadState = GamePad.GetState(PlayerIndex.One);
        }
        public int GetMouseX()
        {
            return this.mouseState.X;
        }
        public int GetMouseY()
        {
            return this.mouseState.Y;
        }
        public bool IsKeyPressed(Keys key)
        {
            return this.keyboardState.IsKeyDown(key);;
        }
        public bool IsKeyPressedOnce(Keys key)
        {
            return this.keyboardState.IsKeyDown(key) && this.oldKeyboard.IsKeyUp(key);
        }
        public bool IsLeftMousePressed()
        {
            return this.mouseState.LeftButton == ButtonState.Pressed && this.oldMouse.LeftButton == ButtonState.Released;
        }
        public bool IsLeftMousePressedDuring()
        {
            return this.mouseState.LeftButton == ButtonState.Pressed;
        }
        public bool IsRightMousePressed()
        {
            return this.mouseState.RightButton == ButtonState.Pressed && this.oldMouse.RightButton == ButtonState.Released;
        }
        public bool IsRightMousePressedDuring()
        {
            return this.mouseState.RightButton == ButtonState.Pressed;
        }
        public bool IsGPButtonPressedOnce(Buttons button)
        {
            return this.gamepadState.IsButtonDown(button) && this.oldGPState.IsButtonUp(button);
        }
        public bool IsGPButtonPressed(Buttons button)
        {
            return this.gamepadState.IsButtonDown(button);
        }
        public void InitOldStates()
        {
            this.oldMouse = Mouse.GetState();
            this.oldKeyboard = Keyboard.GetState();
            this.oldGPState = GamePad.GetState(PlayerIndex.One);
        }
    }
}
