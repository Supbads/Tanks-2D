using Microsoft.Xna.Framework;
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

        int[,] _levelMask;

        Texture2D[] buttonsTextures = new Texture2D[6];

        Menu menu;
        
        private int getLevel;

        public int GetLevel { get { return this.getLevel; } }

        public GameManager(GameTime gameTime, ContentManager content)
        {
            _gameTime = gameTime;
            _gameObjects = new List<GameObject>();
            _content = content;
            _currentLevel = 0;
            _enemyCount = 1;
            _maxEnemy = 3;

            _enemyTrackingList = new List<int>();
        }

        public void Initialize()
        {
            //Define and Declare spawnPOints
            _spawnPoints = new Vector2[] { new Vector2(40, 0), new Vector2(1200, 0), new Vector2(40, 360), new Vector2(1200, 360) };
            _levelMask = new int[18, 32];
            _enemyTexture = new Texture2D[] 
            {
                //_content.Load<Texture2D>("sprites\\BlueTank\\BlueTank"),
                _content.Load<Texture2D>("sprites\\RedTank\\RedTank"),
                _content.Load<Texture2D>("sprites\\OrangeTank\\OrangeTank"),
                _content.Load<Texture2D>("sprites\\GreenTank\\GreenTank")
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
            if (_currentLevel >=1)
            {
                GenerateEnemy();

                foreach (GameObject obj in _gameObjects)
                {
                    obj.Update(_gameTime, _gameObjects);
                }

                for (int i = 0; i < _gameObjects.Count; i++)
                {
                    if (_gameObjects[i].Health <= 0)
                    {
                        _gameObjects.RemoveAt(i--);
                    }
                }
            }
            else if (_currentLevel == 0)
            {
                getLevel = menu.Update();

                if (getLevel > 0)
                {
                    _currentLevel = getLevel;
                    LoadContent();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if (_currentLevel == 0)
            //{
            //    menu.Draw(spriteBatch);
            //    return;
            //}
            menu.Draw(spriteBatch);
            foreach (GameObject obj in _gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void LoadContent()
        {
            if (_currentLevel == 0) // menu
            {
                buttonsTextures[0] = _content.Load<Texture2D>("textures/Buttons/start");
                buttonsTextures[1] = _content.Load<Texture2D>("textures/Buttons/exit");
                buttonsTextures[2] = _content.Load<Texture2D>("textures/Buttons/pause");
                buttonsTextures[3] = _content.Load<Texture2D>("textures/Buttons/resume");
                buttonsTextures[4] = _content.Load<Texture2D>("textures/Buttons/Menu");
                buttonsTextures[5] = _content.Load<Texture2D>("textures/Buttons/multiplayerButton");

                menu = new Menu(buttonsTextures, 1280, 720);
            }
            else if (_currentLevel == 1)  //level 1
            {

                //background
                Sprite levelBackground = new Sprite(_backgroundTexture, new Rectangle(0, 0, _backgroundTexture.Width, _backgroundTexture.Height)) {Id = 8000 , IsActive = true}; // this way it collides but loads the bg
                _gameObjects.Add(levelBackground);

                //player tank
                Texture2D tank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite playerSprite = new FourFrameSprite(tank, 40, 40, Color.White);
                _gameObjects.Add(new Player(playerSprite, new Vector2(620,700 ), 3) { Id = 1 });

                //level (will extract in a method or class)
                //Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
                _level1 = new Level_1();
                GenerateLevel(_level1.GetLevel());    
                
                //Load Bullets   
                LoadBullets();



            }
            else if (_currentLevel == 2) // Player vs Player (local)
            {
                //background
                Sprite levelBackground = new Sprite(_backgroundTexture, new Rectangle(0, 0, _backgroundTexture.Width, _backgroundTexture.Height)) { Id = 8000, IsActive = true }; // this way it collides but loads the bg
                _gameObjects.Add(levelBackground);


                //player tank
                Texture2D tank = _content.Load<Texture2D>("sprites/BlueTank/BlueTank");
                FourFrameSprite playerSprite = new FourFrameSprite(tank, 40, 40, Color.White);
                _gameObjects.Add(new Player(playerSprite, new Vector2(620, 700), 2) { Id = 1 });

                //player2 tank
                Texture2D tank2 = _content.Load<Texture2D>("sprites/GreenTank/GreenTank");
                FourFrameSprite player2Sprite = new FourFrameSprite(tank2, 40, 40, Color.White);
                _gameObjects.Add(new Player_2(player2Sprite, new Vector2(620, 0), 3) { Id = 2 });
                //level (will extract in a method or class)
                //Texture2D tuhla_v2 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
                _level1 = new Level_1();
                GenerateLevel(_level1.GetLevel());

                //Load Bullets   
                LoadBullets();



            }

        }

        private void LoadBullets()
        {
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-100, -100, 15, 15)), "D", _bulletDirections) { Id = 1000, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-200, -200, 15, 15)), "U", _bulletDirections) { Id = 1001, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-300, -300, 15, 15)), "L", _bulletDirections) { Id = 1002, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-400, -400, 15, 15)), "L", _bulletDirections) { Id = 1003, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-500, -500, 15, 15)), "D", _bulletDirections) { Id = 1004, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-600, -600, 15, 15)), "D", _bulletDirections) { Id = 1005, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1006, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1007, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1008, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1009, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1010, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1011, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1012, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1013, IsActive = false });
            _gameObjects.Add(new Bullet(new Sprite(_bullet, new Rectangle(-700, -700, 15, 15)), "D", _bulletDirections) { Id = 1014, IsActive = false });
        }

        //private void LoadLevel() //for random level generation
        //{

        //    Random random = new Random();

        //    for (int row = 0; row < _levelMask.GetLength(0); row++)
        //    {

        //    }
        //}

        private void GenerateEnemy()
        {
            if(_currentLevel==1)
            {
                Random randomSP = new Random(); // Random SpawnPoint
                Random randomTT = new Random(); // random TankTextures
                Random randomDir = new Random();

                FourFrameSprite tempSprite = null;

                int tmpRandom = randomSP.Next(0, _spawnPoints.Length);
                int tmpTexture = randomTT.Next(0, _enemyTexture.Length);
                int tmpDirection = randomDir.Next(0, 4);
                int enemyIdCount = 2001;

                if (_enemyCount <= _maxEnemy && !_enemyTrackingList.Contains(tmpRandom))
                {
                    _enemyTrackingList.Add(tmpRandom);
                    tempSprite = new FourFrameSprite(_enemyTexture[tmpTexture], 40, 40, Color.White);
                    Vector2 tempVector = new Vector2((int)_spawnPoints[tmpRandom].X, (int)_spawnPoints[tmpRandom].Y);

                    _gameObjects.Add(new Enemy(tempSprite, tempVector, tmpDirection) { Id = enemyIdCount++ });
                    _enemyCount++;
            }         

            }
        }

        private void GenerateLevel( int[,] levelMask )
        {
            Texture2D tuhla_v1 = _content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
             
            for (int i = 0; i < levelMask.GetLength(0); i++ )
            {
                for (int j = 0; j < levelMask.GetLength(1); j++ )
                {
                    if( levelMask[i, j] == 1 )
                    {
                        _gameObjects.Add(new Sprite(tuhla_v1, new Rectangle(j * 40, i * 40, 40, 40)) { Id = 411 });
                    }
                }
            }
        }
       
    }
}
