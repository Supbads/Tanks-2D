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

        public Bullet(Sprite sprite)
        {
            _sprite = sprite;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(_isActive)
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
