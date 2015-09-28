using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class GameOptions
    {
        public GameOptions(GraphicsDeviceManager graphics)
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }
    }
}
