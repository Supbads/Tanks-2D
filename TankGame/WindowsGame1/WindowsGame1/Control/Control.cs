﻿using System;
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
    class Control_plam
    {
        KeyboardState previousKbState;
        KeyboardState currentKbState;
        List<GameObject> _gameObjects;
        private Vector2 _position;
        //Bullet bullet = new Bullet((new Sprite<Texture2D>"textures/Bullet",Rectangle(0,5,15,15)),/* direction*/);
        private int _frame;
        private int _width;
        private int _height;
        private string _bulletDirection;

        private TimeSpan _timeSpan;

        private Stopwatch _stopWatch;

        public string BulletDirection { get; set; }
        public Control_plam(Vector2 position, int width, int height)
        {
            _position = position;
            _frame = 3;
            previousKbState = new KeyboardState();
            currentKbState = new KeyboardState();
            _width = width;
            _height = height;

            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public Vector2 GetControl(float playerMoveSpeed, Vector2 position, List<GameObject> gameObjects)
        {
            _position = position;
            previousKbState = currentKbState;
            currentKbState = Keyboard.GetState();

            

            Bullet bullet = new Bullet();

            if (currentKbState.IsKeyDown(Keys.Right))
            {
                _position.X += playerMoveSpeed;
                _frame = 0;
                _bulletDirection = "R";
            }

            else if (currentKbState.IsKeyDown(Keys.Left))
            {
                _position.X -= playerMoveSpeed;
                _frame = 1;
                _bulletDirection = "L";
            }

            else if (currentKbState.IsKeyDown(Keys.Up))
            {
                _position.Y -= playerMoveSpeed;
                _frame = 3;
                _bulletDirection = "U";
            }

            else if (currentKbState.IsKeyDown(Keys.Down))
            {
                _position.Y += playerMoveSpeed;
                _frame = 2;
                _bulletDirection = "D";
            }

            if (currentKbState.IsKeyDown(Keys.Space))
            {
               
                
                _timeSpan = _stopWatch.Elapsed;
                foreach ( GameObject obj in gameObjects )
                {
                    if (obj.Id >= 1000 && obj.Id < 2000 && obj.IsActive == false && _timeSpan.TotalSeconds > 0.5)
                    {
                        bullet = (Bullet)obj;
                        bullet.Shoot(_bulletDirection, _position);
                        _stopWatch.Reset();
                        _stopWatch.Start();  
                        //Debug.WriteLine("SHOOOOOOOOTTTTTT");
                        //Debug.WriteLine(_timeSpan.TotalSeconds);
                        
                        break;
                    }
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