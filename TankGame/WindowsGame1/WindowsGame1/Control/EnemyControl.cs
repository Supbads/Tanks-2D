using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    class EnemyControl
    {
        private Vector2 _position;
        private int _frame;
        private int _width;
        private int _height;
        private string _bulletDirection;

        private Random _random = new Random();

        private TimeSpan _timeSpan;

        private Stopwatch _stopWatch;

        public string BulletDirection { get; set; }
        public EnemyControl(Vector2 position, int width, int height, string direction)
        {
            _position = position;

            if (direction == "Right")
                _frame = 0;
            else if (direction == "Left")
                _frame = 1;
            else if (direction == "Down")
                _frame = 2;
            else if (direction == "Up")
                _frame = 3;

            _width = width;
            _height = height;

            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public void ChooseDirection()
        {
            _frame = _random.Next(0, 4);

        }

        public Vector2 GetControl(float playerMoveSpeed, Vector2 position, List<GameObject> gameObjects)
        {
            _position = position;

            Bullet bullet = new Bullet();

            if (_frame == 0) //right
            {
                _position.X += playerMoveSpeed;
                _bulletDirection = "R";
            }

            else if (_frame == 1) //left
            {
                _position.X -= playerMoveSpeed;
                _bulletDirection = "L";
            }

            else if (_frame == 3) //up
            {
                _position.Y -= playerMoveSpeed;
                _bulletDirection = "U";
            }

            else if (_frame == 2) //down
            {
                _position.Y += playerMoveSpeed;
                _bulletDirection = "D";
            }

            _timeSpan = _stopWatch.Elapsed;

            //choose directin every few seconds
            if (_timeSpan.TotalSeconds > 1 && _timeSpan.TotalSeconds < 7)
            {
                ChooseDirection();
                _stopWatch.Reset();
                _stopWatch.Start();
            }

            foreach (GameObject obj in gameObjects)
            {
                if (obj.Id >= 1000 && obj.Id < 2000 && obj.IsActive == false && _timeSpan.TotalSeconds > 0.6)
                {
                    bullet = (Bullet)obj;
                    bullet.Shoot(_bulletDirection, _position);                    

                    break;
                }
            }

            _position.X = (int)MathHelper.Clamp(_position.X, 0, Game1.screenWidth - _width);
            _position.Y = (int)MathHelper.Clamp(_position.Y, 0, Game1.screenHeight - _height);

            return _position;
        }

        public int GetFrame()
        {
            return _frame;
        }

    }
}