using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class GameManager
    {
        private int _currentLevel;

        private List<GameObject> _gameObjects;

        private GameTime _gameTime;

        private ContentManager _content;

        public GameManager(GameTime gameTime, ContentManager content)
        {           
            _gameTime = gameTime;
            _gameObjects = new List<GameObject>();
            _content = content;
            _currentLevel = 1;            
        }

        public void Initialize()
        {

        }

        public void Update()
        {
            foreach (GameObject obj in _gameObjects)
            {                   
                obj.Update(_gameTime, _gameObjects);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void LoadContent()
        {
            
            if ( _currentLevel == 0 )
            {
                Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(50, 300, 50, 50)));
            }
            else
            {
                Texture2D tankche = _content.Load<Texture2D>("sprites/BlueTank/BlueTankUp");
                Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");

                //Sprite tuhla = new Sprite(tankche, new Vector2(100, 100));
                Sprite tank_v2 = new Sprite(tankche, new Vector2(300, 20));

                _gameObjects.Add(new Player_s2(tank_v2) { Id = 1 });
                //_gameObjects.Add(tuhla);
                //_gameObjects.Add(new Sprite(tuhla_v2, new Vector2(50, 50)));
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(50, 300, 50, 50)) { Id = 2 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(200, 300, 50, 50)) { Id = 3 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(150, 300, 50, 50)) { Id = 4 });
            }
        }                
    }
}
