using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Bullet : GameObject
    {
        private int _id;

        private Sprite _sprite;

        private bool _isActive;

        private string _direction;

        private Vector2 _velocity;

        private List<GameObject> _gameObjects;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
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

        public Bullet(Sprite sprite, string direction)
        {
            _sprite = sprite;
            _direction = direction;

            if (direction == "D")
            {
                _velocity.Y += 2.5f;
            }
            else if (direction == "U")
            {
                _velocity.Y -= 2.5f;
            }
            else if (direction == "L")
            {
                _velocity.X += 2.5f;
            }
            else if (direction == "R")
            {
                _velocity.X -= 2.5f;
            }

        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isActive)
            {
                _sprite.Draw(spriteBatch);
            }

        }

        public override Rectangle GetRect()
        {
            return _sprite.GetRect();
        }

        public override bool Collision(List<GameObject> gameObjects)
        {
            return false;
        }
    }
}
