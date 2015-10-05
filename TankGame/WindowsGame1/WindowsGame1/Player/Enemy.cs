using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Enemy : GameObject
    {
        private int _id;

        //private FourFrameSprite _sprite;
        private Sprite _sprite;

        private bool _active;

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

        public override bool IsActive
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        public Enemy(Sprite sprite, int[,] levelMask)
        {
            _sprite = sprite;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {                        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public override bool Collision(List<GameObject> gameObjects)
        {

            return false;
        }

        public override Rectangle GetRect()
        {
            return _sprite.GetRect();
        }

        
    }
}
