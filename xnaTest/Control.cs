using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        float playerMoveSpeed;

        public Control()
        {
            playerMoveSpeed = 8.0f;
        }

        public void UpdatePlayer(Player player)
        {
            if (currentKbState.IsKeyDown(Keys.Right))
            {
                player.position.X += playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Left))
            {
                player.position.X -= playerMoveSpeed;
            }

            //if(currentKbState.IsKeyDown(Keys.Right))
            //{
            //    player.position.X += playerMoveSpeed;
            //}

            if (currentKbState.IsKeyDown(Keys.Up))
            {
                player.position.Y -= playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Down))
            {
                player.position.Y += playerMoveSpeed;
            }
            //player.position.X = MathHelper.Clamp(player.position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
            //player.position.Y = MathHelper.Clamp(player.position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);
        }
    }
}
