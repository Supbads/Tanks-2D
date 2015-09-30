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
        private Texture2D _texture;
        private Rectangle _rectangle;

        private Vector2 _position;

        private bool _active;

        private int _id;
               
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

        public override int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _rectangle = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
            _position = position;
            _active = true;
        }

        public Sprite(Texture2D texture, int posX, int posY)
        {
            _texture = texture;
            _position.X = posX;
            _position.Y = posY;
            _rectangle = new Rectangle(posX, posY, _texture.Width, _texture.Height);
            _active = true;
        }

        public Sprite(Texture2D texture, Rectangle rectangle)
        {
            _texture = texture;
            _rectangle = rectangle;
            _position.X = rectangle.X;
            _position.Y = rectangle.Y;
            _active = true;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_active)
            {
                spriteBatch.Draw(_texture, _rectangle, Color.White);
            }
        }

        public override bool Collision(List<GameObject> gameObjects)
        {
            return false;
        }

        public override Rectangle GetRect()
        {
            return _rectangle;
        }
    }
}
