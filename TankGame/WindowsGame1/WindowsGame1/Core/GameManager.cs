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
                _content.Load<Texture2D>("sprites\\RedTank\\RedTankDown"),
                _content.Load<Texture2D>("sprites\\OrangeTank\\OrangeDown"),
                _content.Load<Texture2D>("sprites\\BlueTank\\BlueTankDown")
            };

            _bullet = _content.Load<Texture2D>("textures/Bullet");
        }

        public void Update()
        {
            GenerateEnemy();

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


            if (_currentLevel == 0)
            {
                Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(50, 300, 50, 50)));
            }
            else
            {
                //Texture2D tankche = _content.Load<Texture2D>("sprites/BlueTank/BlueTankUp");
                Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");

                //Sprite tuhla = new Sprite(tankche, new Vector2(100, 100));
                //Sprite tank_v2 = new Sprite(tankche, new Vector2(300, 20));
                //Sprite tank_v2 = new Sprite(tankche, new Rectangle(300, 0, 40, 40));
                //_gameObjects.Add(new Player_s2(tank_v2) { Id = 1 });
                //_gameObjects.Add(tuhla);
                //_gameObjects.Add(new Sprite(tuhla_v2, new Vector2(50, 50)));
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(50, 300, 40, 40)) { Id = 2 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(200, 300, 40, 40)) { Id = 3 });
                _gameObjects.Add(new Sprite(tuhla_v2, new Rectangle(150, 300, 40, 40)) { Id = 4 });

                //tank #3
                Texture2D tank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite playerSprite = new FourFrameSprite(tank, 40, 40, Color.White);
                _gameObjects.Add(new Player_plam(playerSprite, new Vector2(0, 0), 0) { Id = 5 });

                //Tank enemy
                Texture2D enemyTank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite enemySprite = new FourFrameSprite(enemyTank, 40, 40, Color.White);
                Player_plam enemy = new Player_plam(enemySprite, new Vector2(1240, 0), 0) { };

                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 0, 15, 15))) { Id = 1000, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 0, 15, 15))) { Id = 1001, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15))) { Id = 1002, IsActive = false });
                _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, 100, 15, 15))) { Id = 1003, IsActive = false });
            }
        }

        private void LoadLevel()
        {

            Random random = new Random();

            for (int row = 0; row < _levelMask.GetLength(0); row++)
            {

            }
        }

        private void LoadLEvel_1()
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
                _gameObjects.Add(new Enemy(tmpSprite, _levelMask) { Id = 100});
                _enemyCount++;

            }



        }
    }
}
