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
    class Player_s2 : GameObject
    {

        private Sprite _sprite;

        private Control _control;

        //public Texture2D PlayerTexture;
                
        //public Animation animation;

        public Vector2 position;
        
        public bool active;

        public int healt;

        KeyboardState previousKbState;
        KeyboardState currentKbState;

        float playerMoveSpeed;        

        public Player_s2(GraphicsDeviceManager graphics)
        {
            
        }

        public Player_s2(Sprite sprite)
        {
            _sprite = sprite;
            _control = new Control();

            active = true;

            healt = 100;
            playerMoveSpeed = 8.0f;

            currentKbState = new KeyboardState();
            previousKbState = new KeyboardState();
        }

        public void Initialize()
        {
                        
        }

        public override void Update(GameTime gameTime)
        {
            //animation.position = position;
            //animation.Update(gameTime);          
            PlayerControl();
            _sprite.X = (int)position.X;
            _sprite.Y = (int)position.Y;
        }

        public void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(PlayerTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw();
            //animation.Draw(spriteBatch);
            _sprite.Draw(spriteBatch);
        }

        private void PlayerControl()
        {
            position = _control.GetControl(playerMoveSpeed);
        }

        private bool Collision()
        {
            return false;
        }
    }
}
