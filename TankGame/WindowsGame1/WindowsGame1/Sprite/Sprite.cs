using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Sprite
    {
        Texture2D _texture;
        Rectangle _rectangle;
        
        public Vector2 Position 
        { 
            get
            {
                Vector2 rectPos = new Vector2( (int)_rectangle.X, (int)_rectangle.Y );
                return rectPos;
            } 
            set
            {
                _rectangle.X = (int)Position.X;
                _rectangle.Y = (int)Position.Y;
            }
        }

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
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);            
        }        
    }
}
