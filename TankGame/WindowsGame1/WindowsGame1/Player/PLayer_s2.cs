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

        private bool _collide;

        private List<GameObject> _gameObjects;

        private Vector2 _position;
        private Vector2 _prevPosition;
        
        public bool active;

        public override bool IsActive
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        private int health;

        private int _id;

        float playerMoveSpeed;

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

        public Player_s2(Sprite sprite)
        {
            _sprite = sprite;
            _sprite.Id = Id;
            _position.X = sprite.X;
            _position.Y = sprite.Y;
            _prevPosition = _position;
            _control = new Control(_position);

            active = true;

            health = 100;
            playerMoveSpeed = 4.0f;
        }

        public void Initialize()
        {

        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            _prevPosition = _position;
            _position = _control.GetControl(playerMoveSpeed, _position);
            //PlayerControl();         

            //Move the sprite before check collision
            _sprite.X = (int)_position.X;
            _sprite.Y = (int)_position.Y;

            _collide = Collision(gameObjects);            

            if (_collide)
            {
                _position = _prevPosition;
            }

            if (_collide)
            {
                //If collide revert previous position
                _sprite.X = (int)_position.X;
                _sprite.Y = (int)_position.Y;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        private void PlayerControl()
        {
            _position = _control.GetControl(playerMoveSpeed);
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
                if (_sprite.GetRect().Intersects(obj.GetRect()) && _id != obj.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
