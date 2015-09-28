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
    class CollisionHelper
    {
        const int penetrationMargin = 3; // 3 pixels
        public static bool Touches(this Rectangle r1, Rectangle r2)
        {
            bool touchesBottom = (r1.Bottom >= r2.Top - penetrationMargin)&&
                (r1.Bottom <= r2.Top+1)&&
                (r1.Right >= r2.Left + penetrationMargin)&&
                r1.Left <= r2.Right - penetrationMargin;
            bool touchesTop = (( r1.Top >= r2.Bottom - penetrationMargin)&&
                (r1.Top <= r2.Top + penetrationMargin)&&
                (r1.Right >= r2.Left+penetrationMargin)&&
                r1.Left <= r2.Right-penetrationMargin );

            //bool touchesLeft = (r1.Left <= r2.Right - penetrationMargin);
            //bool touchestRight;
            // see how it goes
            
            return (touchesBottom&&touchesTop) ;
            // stop < (touches)
        }
    }
}
