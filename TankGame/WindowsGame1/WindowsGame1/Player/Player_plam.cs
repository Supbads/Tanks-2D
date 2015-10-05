using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Player_plam : GameObject
    {
        private List<GameObject> _gameObjects;
        private FourFrameSprite _sprite;
        private Vector2 _position;
        private Control_plam _control;
        private Vector2 _prevPosition;
        float playerMoveSpeed;

        private bool _isActive;

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

        public int Width
        {
            get { return _sprite.FrameWidth; }
        }
        public int Height
        {
            get { return _sprite.FrameHeight; }
        }
        private int _currentFrame;

        private int _id;
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

        public Player_plam(FourFrameSprite sprite, Vector2 position, int currentFrame)
        {
            _sprite = sprite;
            _position = position;
            _prevPosition = position;
            _currentFrame = currentFrame;
            _health = 100;

            playerMoveSpeed = 4.0f;
            _control = new Control_plam(_position, Width, Height);
        }


        public void Initialize()
        {

        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            _prevPosition = _position;
            _position = _control.GetControl(playerMoveSpeed, _position, gameObjects);
            _currentFrame = _control.GetFrame();
            _sprite.Position = _position;
            _sprite.Update(_currentFrame);

            if (Collision(gameObjects))
            {
                _position = _prevPosition;
                _sprite.Position = _position;
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
                if (_sprite.GetRect().Intersects(obj.GetRect()) && _id != obj.Id )
                {
                    return true;
                }
            }
            return false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public override void Hit()
        {
        }
    }
}