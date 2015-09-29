using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Sprite : GameObject
    {
        Texture2D _texture;
        Rectangle _rectangle;       
       
        public int X
        {
            get
            {
                return _rectangle.X;
            }
            set
            {
                _rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _rectangle.Y;
            }
            set
            {
                _rectangle.Y = value;
            }
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _rectangle = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
        }

        public Sprite(Texture2D texture, int posX, int posY)
        {
            _texture = texture;
            _rectangle = new Rectangle(posX, posY, _texture.Width, _texture.Height);
        }

        public Sprite(Texture2D texture, Rectangle rectanngle)
        {
            _texture = texture;
            _rectangle = rectanngle;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);            
        }        
    }
}
