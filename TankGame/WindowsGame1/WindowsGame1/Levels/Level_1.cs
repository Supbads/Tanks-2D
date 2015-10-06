using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Levels;

namespace WindowsGame1
{
    class Level_1// TODO:  Level 1 outline : LEvel
    {
        private Texture2D _tuhla;

        private List<GameObject> _gameObjects;

        public Level_1(Texture2D tuhla_v2, List<GameObject> gameObjects)
        {
            //tuhla = content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");
            //Sprite sprTuhla = new Sprite(tuhla, new Rectangle(200, 200, 50, 50));
            //Sprite sprTuhla = new Sprite(tuhla, new Rectangle(200, 200, 50, 50)); // coppy paste za vsqka
            //test = new Player()
            _gameObjects = gameObjects;
            _tuhla = tuhla_v2;
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(0, 0, 40, 40)) { Id = 2 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(40, 40, 40, 40)) { Id = 3 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(40, 80, 40, 40)) { Id = 4 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(40, 120, 40, 40)) { Id = 6 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(120, 40, 40, 40)) { Id = 7 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(120, 80, 40, 40)) { Id = 8 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(120, 120, 40, 40)) { Id = 9 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(160, 40, 40, 40)) { Id = 10 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(200, 40, 40, 40)) { Id = 11 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(240, 40, 40, 40)) { Id = 12 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(40, 240, 40, 40)) { Id = 13 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(160, 240, 40, 40)) { Id = 14 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(0, 240, 40, 40)) { Id = 15 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(40, 280, 40, 40)) { Id = 16 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(160, 280, 40, 40)) { Id = 17 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(0, 160, 40, 40)) { Id = 18 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(120, 240, 40, 40)) { Id = 19 });//
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(120, 280, 40, 40)) { Id = 20 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(150, 500, 40, 40)) { Id = 21 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(150, 500, 40, 40)) { Id = 22 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(150, 500, 40, 40)) { Id = 23 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(150, 500, 40, 40)) { Id = 24 });
            _gameObjects.Add(new Sprite(_tuhla, new Rectangle(150, 500, 40, 40)) { Id = 25 });
        }

        public Level_1()
        {

        }

    }
}
