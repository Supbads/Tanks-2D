using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class FourFrameSprite
    {
        Texture2D spriteStrip;
        Color color;
        Rectangle sourceRect = new Rectangle();
        private Rectangle _destinationRect = new Rectangle();

        public int FrameWidth;
        public int FrameHeight;
        public Vector2 Position;

        public FourFrameSprite(Texture2D texture, Vector2 position, int frameWidth,
            int frameHeight, Color color)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;

            Position = position;
            spriteStrip = texture;
        }

        public void Initialize()
        {
        }

        public void Update(int frameNum)
        {
            sourceRect = new Rectangle(frameNum * FrameWidth, 0, FrameWidth, FrameHeight);
            _destinationRect = new Rectangle((int)Position.X - (int)FrameWidth / 2,
                                            (int)Position.Y - (int)FrameHeight / 2,
                                            FrameWidth, FrameHeight);
        }
        public Rectangle GetRect()
        {
            return _destinationRect;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteStrip, _destinationRect, sourceRect, color);
        }
    }
}