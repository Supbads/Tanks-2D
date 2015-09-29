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

        public bool active;

        public int health;

        float playerMoveSpeed;

        public Player_s2(Sprite sprite)
        {
            _sprite = sprite;
            _control = new Control();

            active = true;

            health = 100;
            playerMoveSpeed = 8.0f;
        }

        public void Initialize()
        {

        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            Vector2 prevPosition = new Vector2();
            prevPosition = _position;
            
            PlayerControl();            
            _collide = Collision(gameObjects);

            if (_collide)
            {
                _position = prevPosition;
            }
            
            _sprite.X = (int)_position.X;
            _sprite.Y = (int)_position.Y;
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
            foreach (GameObject obj in gameObjects)
            {
                if (_sprite.GetRect().Intersects(obj.GetRect()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
