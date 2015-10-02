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
    public class Level_1// TODO:  Level 1 outline
    {
        Texture2D tuhla;

        //Player test;

        List<GameObject> gameObjects;

        public Level_1(ContentManager content)
        {
            tuhla = content.Load<Texture2D>("textures/Bricks/480px-Brick_Block_-_New_Super_Mario_Bros");

            Sprite sprTuhla = new Sprite(tuhla, new Rectangle(200, 200, 50, 50));
            //Sprite sprTuhla = new Sprite(tuhla, new Rectangle(200, 200, 50, 50)); // coppy paste za vsqka

            //test = new Player();

            gameObjects = new List<GameObject>();

            gameObjects.Add(sprTuhla);
        }
    }
}
