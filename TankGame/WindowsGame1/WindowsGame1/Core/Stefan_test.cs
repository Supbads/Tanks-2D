using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame1
{
    class Stefan_test
    {
        Texture2D tuhla;

        Player stefan;

        List<GameObject> gameObjects;

        public Stefan_test(ContentManager content)
        {
            tuhla = content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");

            Sprite sprTuhla = new Sprite(tuhla, new Rectangle(200, 200, 50, 50));

            stefan = new Player();

            gameObjects = new List<GameObject>();

            gameObjects.Add(sprTuhla);
            gameObjects.Add(stefan);
        }



    }
}
