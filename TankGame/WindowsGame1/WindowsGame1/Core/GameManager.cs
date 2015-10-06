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
        private int _enemyCount;
        private int _maxEnemy;
        private int _currentLevel;

        private Vector2[] _spawnPoints;

        private Texture2D[] _enemyTexture;

        private Texture2D _bullet;

        private List<GameObject> _gameObjects;

        private List<int> _enemyTrackingList;

        private GameTime _gameTime;

        private ContentManager _content;

        private Texture2D[] _bulletDirections;

        private Texture2D _backgroundTexture;

        private Level_1 _level1;

        int[,] _levelMask = new int[18, 32];

        public GameManager(GameTime gameTime, ContentManager content)
        {
            _gameTime = gameTime;
            _gameObjects = new List<GameObject>();
            _content = content;
            _currentLevel = 1;
            _enemyCount = 1;
            _maxEnemy = 3;

            _enemyTrackingList = new List<int>();
        }

        public void Initialize()
        {
            //Define and Declare spawnPOints
            _spawnPoints = new Vector2[] { new Vector2(40, 0), new Vector2(1200, 0), new Vector2(600, 0), new Vector2(1000, 0) };

            _enemyTexture = new Texture2D[] 
            {
                _content.Load<Texture2D>("sprites\\GreenTank\\Down"),
                _content.Load<Texture2D>("sprites\\RedTank\\Down"),
                _content.Load<Texture2D>("sprites\\OrangeTank\\Down"),
                _content.Load<Texture2D>("sprites\\BlueTank\\Down")
            };
            _backgroundTexture = _content.Load<Texture2D>("textures/Backgrounds/BG1");

            _bulletDirections = new Texture2D[]
            {
                //_bullet = _content.Load<Texture2D>("textures/Bullet/Up");
                _content.Load<Texture2D>("textures/Bullet/Up"),
                _content.Load<Texture2D>("textures/Bullet/Down"),
                _content.Load<Texture2D>("textures/Bullet/Left"),
                _content.Load<Texture2D>("textures/Bullet/Right"),
            };
        }

        public void Update()
        {
            GenerateEnemy();

            foreach (GameObject obj in _gameObjects)
            {
                obj.Update(_gameTime, _gameObjects);
            }

            for (int i = 0; i < _gameObjects.Count; i++ )
            {
                if(_gameObjects[i].Health <= 0)
                {
                    _gameObjects.RemoveAt(i--);
                }
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


            if (_currentLevel == 0) // menu
            {

            }
            else if (_currentLevel == 1)  //level 1
            {
                //background
                Sprite levelBackground = new Sprite(_backgroundTexture, new Rectangle(0, 0, _backgroundTexture.Width, _backgroundTexture.Height)) {Id = 8000 , IsActive = true}; // this way it collides but loads the bg
                _gameObjects.Add(levelBackground);

                //player tank
                Texture2D tank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite playerSprite = new FourFrameSprite(tank, 40, 40, Color.White);
                _gameObjects.Add(new Player_plam(playerSprite, new Vector2(400,680 ), 0) { Id = 5 });

                //level (will extract in a method or class)
                Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
                //_level1 = new Level_1(tuhla_v2,_gameObjects);

                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(0, 0, 40, 40)) { Id = 2 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(40, 40, 40, 40)) { Id = 3 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(40, 80, 40, 40)) { Id = 4 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(40, 120, 40, 40)) { Id = 6 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 40, 40, 40)) { Id = 7 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 80, 40, 40)) { Id = 8 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 120, 40, 40)) { Id = 9 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(160, 40, 40, 40)) { Id = 10 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(200, 40, 40, 40)) { Id = 11 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(240, 40, 40, 40)) { Id = 12 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(40, 240, 40, 40)) { Id = 13 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(160, 240, 40, 40)) { Id = 14 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(0, 240, 40, 40)) { Id = 15 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(160, 280, 40, 40)) { Id = 17 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(0, 160, 40, 40)) { Id = 18 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 240, 40, 40)) { Id = 19 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 280, 40, 40)) { Id = 20 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(160, 320, 40, 40)) { Id = 21 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(200, 360, 40, 40)) { Id = 22 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(120, 440, 40, 40)) { Id = 23 });//
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(80, 400, 40, 40)) { Id = 24 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(40, 360, 40, 40)) { Id = 25 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(0 , 320, 40, 40)) { Id = 25 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(0, 280, 40, 40)) { Id = 25 });


                                
                //Tank enemy
                Texture2D enemyTank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite enemySprite = new FourFrameSprite(enemyTank, 40, 40, Color.White);
                Player_plam enemy = new Player_plam(enemySprite, new Vector2(1240, 0), 0) { }; // should instance Enemy class
                // bullets somewhere      
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 0, 15, 15)), "D", _bulletDirections) { Id = 1000, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 0, 15, 15)), "U", _bulletDirections) { Id = 1001, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15)), "L", _bulletDirections) { Id = 1002, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15)), "L", _bulletDirections) { Id = 1003, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15)), "D", _bulletDirections) { Id = 1004, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15)), "D", _bulletDirections) { Id = 1005, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15)), "D", _bulletDirections) { Id = 1006, IsActive = false });

            }
            else if (_currentLevel == 2) // level 2
            {


            }

        }

        private void LoadLevel() //for random level generation
        {

            Random random = new Random();

            for (int row = 0; row < _levelMask.GetLength(0); row++)
            {

            }
        }

        private void LoadLevel_1()
        {

            Texture2D tuhlicka = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
            FourFrameSprite playerSprite = new FourFrameSprite(tuhlicka, 40, 40, Color.White);

        }

        private void GenerateEnemy()
        {
            Random randomSP = new Random(); // Random SpawnPoint
            Random randomTT = new Random(); // random TankTextures
            int tmpRandom = 0;
            int tmpTexture = 0;
            
            Sprite tmpSprite = null;

            tmpRandom = randomSP.Next(0, _spawnPoints.Length - 1);
            tmpTexture = randomTT.Next(0, _enemyTexture.Length - 1);

            if (_enemyCount <= _maxEnemy && !_enemyTrackingList.Contains(tmpRandom))
            {
                _enemyTrackingList.Add(tmpRandom);
                tmpSprite = new Sprite(_enemyTexture[tmpTexture], new Rectangle((int)_spawnPoints[tmpRandom].X, (int)_spawnPoints[tmpRandom].Y, 40, 40));
                _gameObjects.Add(new Enemy(tmpSprite, _levelMask) { Id = 100 });
                _enemyCount++;

            }
        }

       
    }
}
