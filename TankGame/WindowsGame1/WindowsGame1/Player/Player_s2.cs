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
    class Player_S2
    {
        GraphicsDeviceManager _graphics;

        //public Texture2D PlayerTexture;

        public Texture2D tank;
        public Texture2D[] tankPositions;

        public Rectangle position;

        public bool active;

        public int health;

        KeyboardState previousKbState;
        KeyboardState currentKbState;

        float playerMoveSpeed;

        public int Width
        {
            //get { return PlayerTexture.Width; }
            get { return tank.Width; }
        }

        public int Height
        {
            //get { return PlayerTexture.Height; }
            get { return tank.Height; }
        }

        public Player_S2(GraphicsDeviceManager graphics, Texture2D[] tankPositions, Rectangle position)
        {
            _graphics = graphics;
            this.tank = tankPositions[0];
            this.position = position;
            this.tankPositions = tankPositions;

            active = true;

            health = 100;
            playerMoveSpeed = 3.0f;

            currentKbState = new KeyboardState();
            previousKbState = new KeyboardState();
        }
        public void setPlayerTank(Texture2D tank)
        {
            this.tank = tank;
        }

        //public void Initialize(Texture2D tank, Rectangle position)
        //{
        //    this.tank = tank;
        //    this.position = position;

        //    active = true;

        //    healt = 100;
        //    playerMoveSpeed = 3.0f;

        //    currentKbState = new KeyboardState();
        //    previousKbState = new KeyboardState();
        //}

        public void Update(GameTime gameTime)
        {
            //animation.position = position;
            //animation.Update(gameTime);
            PlayerControl();

            position.X = (int)MathHelper.Clamp(position.X, 0, Game1.screenWidth - Width);
            position.Y = (int)MathHelper.Clamp(position.Y, 0, Game1.screenHeight - Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(PlayerTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(tank, position, Color.White);
        }

        private void PlayerControl()
        {
            previousKbState = currentKbState;
            currentKbState = Keyboard.GetState();
            if (currentKbState.IsKeyDown(Keys.Left))
            {
                position.X -= (int)playerMoveSpeed;
                setPlayerTank(tankPositions[2]);
            }
            else if (currentKbState.IsKeyDown(Keys.Right))
            {
                position.X += (int)playerMoveSpeed;
                setPlayerTank(tankPositions[3]);
            }
            else if (currentKbState.IsKeyDown(Keys.Up))
            {
                position.Y -= (int)playerMoveSpeed;
                setPlayerTank(tankPositions[0]);
            }

            else if (currentKbState.IsKeyDown(Keys.Down))
            {
                position.Y += (int)playerMoveSpeed;
                setPlayerTank(tankPositions[1]);
            }



        }
    }
}