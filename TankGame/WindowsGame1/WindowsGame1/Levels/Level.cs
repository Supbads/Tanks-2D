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

namespace WindowsGame1
{
    public abstract class Level 
    {
        private int currentLevel;

        public int CurrentLevel
        {
            get { return this.currentLevel; }
            set
            {
                if (this.currentLevel <= 0||this.currentLevel>2)  //  IF OVERCAP => throw exception
                {
                    throw new ArgumentException("Level", "Reaching incorect level");
                }
                else
                {
                    this.currentLevel = value;
                };
            }
        }

        public Level(int level)
        {
            this.CurrentLevel = level;
        }
    }
}