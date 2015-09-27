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
    class Player
    {
        GraphicsDeviceManager _graphics;

        //public Texture2D PlayerTexture;

        public Animation animation;

        public Vector2 position;

        public bool active;

        public int healt;

        KeyboardState previousKbState;
        KeyboardState currentKbState;

        float playerMoveSpeed;

        public int Width
        {
            //get { return PlayerTexture.Width; }
            get { return animation.frameWidth; }
        }

        public int Height
        {
            //get { return PlayerTexture.Height; }
            get { return animation.frameHeight; }
        }

        public Player(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public void Initialize(Animation _animation, Vector2 position)
        {

            //PlayerTexture = texture;
            animation = _animation;
            this.position = position;

            active = true;

            healt = 100;
            playerMoveSpeed = 8.0f;

            currentKbState = new KeyboardState();
            previousKbState = new KeyboardState();
        }

        public void Update(GameTime gameTime)
        {
            animation.position = position;
            animation.Update(gameTime);

            PlayerControl();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(PlayerTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            animation.Draw(spriteBatch);
        }

        private void PlayerControl()
        {
            previousKbState = currentKbState;
            currentKbState = Keyboard.GetState();


            if (currentKbState.IsKeyDown(Keys.Right))
            {
                position.X += playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Left))
            {
                position.X -= playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Up))
            {
                position.Y -= playerMoveSpeed;
            }

            if (currentKbState.IsKeyDown(Keys.Down))
            {
                position.Y += playerMoveSpeed;
            }
            position.X = MathHelper.Clamp(position.X, 0, Game1.ScreenWidth - Width);
            position.Y = MathHelper.Clamp(position.Y, 0, Game1.ScreenHeight - Height);
        }
    }
}
