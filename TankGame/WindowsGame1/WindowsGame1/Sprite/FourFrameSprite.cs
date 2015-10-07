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
        Rectangle sourceRect;
        private Rectangle _destinationRect;

        public int FrameWidth;
        public int FrameHeight;
        public Vector2 Position;
        public bool _active;

        public bool IsActive
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        public FourFrameSprite(Texture2D texture, int frameWidth,
            int frameHeight, Color color)
        {
            sourceRect = new Rectangle();
            _destinationRect = new Rectangle();
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;

            spriteStrip = texture;
        }

        public void Initialize()
        {
        }

        public void Update(int frameNum)
        {
            sourceRect = new Rectangle(frameNum * FrameWidth, 0, FrameWidth, FrameHeight);
            _destinationRect = new Rectangle((int)Position.X,
                                            (int)Position.Y,
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