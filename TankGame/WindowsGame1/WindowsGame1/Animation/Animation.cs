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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Animation
    {

        Texture2D spriteStrip;

        float scale;

        int elapsedTime;

        int frameTime;

        int frameCount;

        int currentFrame;

        Color color;

        Rectangle sourceRect = new Rectangle();

        Rectangle destinationRect = new Rectangle();

        public int frameWidth;

        public int frameHeight;

        public bool active;

        public bool looping;

        public Vector2 position;

        public Animation()
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public void Initialize(Texture2D texture, Vector2 position, int frameWidth,
            int frameHeight, int frameCount, int frametime, Color color, float scale, bool looping)
        {
            // TODO: Add your initialization code here
            this.spriteStrip = texture;
            this.position = position;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.color = color;
            this.scale = scale;
            this.looping = looping;

            elapsedTime = 0;
            currentFrame = 0;

            active = true;

        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            if(!active)
            {
                return;
            }

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if( elapsedTime > frameTime )
            {
                currentFrame++;

                if( currentFrame == frameCount )
                {
                    currentFrame = 0;
                    if (looping == false)
                    {
                        active = false;
                    }
                }

                elapsedTime = 0;
            }

            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2,
                        (int)position.Y - (int)(frameHeight * scale) / 2,
                        (int)(frameWidth * scale),
                        (int)(frameHeight * scale));


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }
        }
    }
}
