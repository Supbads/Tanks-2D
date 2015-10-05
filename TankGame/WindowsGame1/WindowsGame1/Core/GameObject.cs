using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    //To be inherited From sprites, Player, etc everithing is game object.
    abstract class GameObject
    {
        public abstract int Id { get; set; }

        public abstract bool IsActive { get; set; }

        public abstract int Health { get; set; }

        public abstract void Hit();

        public abstract Rectangle GetRect();

        public abstract void Update(GameTime gameTime, List<GameObject> gameObjects);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract bool Collision(List<GameObject> gameObjects);

    }
}
