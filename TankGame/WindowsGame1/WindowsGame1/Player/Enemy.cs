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

        private int _health;

        public override int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
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
            _health = 100;
            _active = true;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            if( _health <= 0 )
            {
                //_active = false;
                //_sprite.X = -100;
                //_sprite.Y = -100;
            }
                                          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if ( _active )
            {
                _sprite.Draw(spriteBatch);
            }
        }

        public override bool Collision(List<GameObject> gameObjects)
        {
            return false;
        }

        public override Rectangle GetRect()
        {
            return _sprite.GetRect();
        }

        public override void Hit()
        {
            _health -= 50;
        }
    }
}
