using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    class Control
    {
        KeyboardState previousKbState;
        KeyboardState currentKbState;

        private Vector2 _position;

        public Control(Vector2 position)
        {
            _position = position;
            previousKbState = new KeyboardState();
            currentKbState = new KeyboardState();
        }

        public Vector2 GetControl(float playerMoveSpeed)
        {

            previousKbState = currentKbState;
            currentKbState = Keyboard.GetState();


            if (currentKbState.IsKeyDown(Keys.Right))
            {
                _position.X += playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Left))
            {
                _position.X -= playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Up))
            {
                _position.Y -= playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Down))
            {
                _position.Y += playerMoveSpeed;
            }
            //position.X = MathHelper.Clamp(position.X, 0, Game1.ScreenWidth - Width);
            //position.Y = MathHelper.Clamp(position.Y, 0, Game1.ScreenHeight - Height);
            return _position;            
        }

    }
}
