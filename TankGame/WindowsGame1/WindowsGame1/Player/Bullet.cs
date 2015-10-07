using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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

        private Texture2D[] _textures;

        private bool _collision;

        private int health;

        public override int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public override bool IsActive
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

        public Bullet(Sprite sprite, string direction, Texture2D[] bulletTextures)
        {
            _sprite = sprite;
            _direction = direction;
            _textures = bulletTextures;

            health = 40;                                   

        }

        public Bullet()
        {
            health = 40;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            _collision = Collision(gameObjects);

            if(_isActive)
            {
                //dviji se
                if (_direction == "U")
                {
                    _sprite.Y -= 6;
                }
                if (_direction == "D")
                {
                    _sprite.Y += 6;
                }
                if (_direction == "L")
                {
                    _sprite.X -= 6;
                }
                if (_direction == "R")
                {
                    _sprite.X += 6;
                }
            }

            if( ((0 > _sprite.X || _sprite.X > Game1.screenWidth) || (_sprite.Y < 0 || _sprite.Y > Game1.screenHeight)) && _isActive)
            {
                _isActive = false;
                _sprite.X = -100;
                _sprite.Y = -100;    
            }
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
            Rectangle intersect;
            foreach (GameObject obj in gameObjects)
            {
                intersect = Rectangle.Intersect(_sprite.GetRect(), obj.GetRect());
                //if ( intersect != Rectangle.Empty && _id != obj.Id)
                if (_sprite.GetRect().Intersects(obj.GetRect()) && _id != obj.Id && obj.Id < 7000)//obv.Id < 7000 -> Font
                {
                    _isActive = false;
                    _sprite.X = -100;
                    _sprite.Y = -100;
                    obj.Hit();
                    Hit();
                    return true;
                }
            }

            return false;
        }

        public void Shoot(string direction, Vector2 position)
        {
            //To DO Logic 
            _isActive = true;

            //_sprite.Position = new Vector2(position.X, position.Y);

            //Debug.WriteLine(direction);

            if( direction == "U")
            {
                _sprite = new Sprite(_textures[0], new Rectangle((int)position.X + 13, (int)position.Y - 20, 15, 15));
                _direction = direction;
            }
            if (direction == "D")
            {
                _sprite = new Sprite(_textures[1], new Rectangle((int)position.X + 13, (int)position.Y + 45, 15, 15));
                _direction = direction;
            }
            if (direction == "L")
            {
                _sprite = new Sprite(_textures[2], new Rectangle((int)position.X -20, (int)position.Y + 13, 15, 15));
                _direction = direction;
            }
            if (direction == "R")
            {
                _sprite = new Sprite(_textures[3], new Rectangle((int)position.X + 45, (int)position.Y + 13, 15, 15));
                _direction = direction;
            }
        }

        public override void Hit()
        {
            _sprite.X = -200;
            _sprite.Y = -200;
        }
    }
}
