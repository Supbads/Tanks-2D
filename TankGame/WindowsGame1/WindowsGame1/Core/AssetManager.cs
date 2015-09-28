using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class AssetManager
    {
        ContentManager _contentManage;

        List<Sprite> _sprites;

        List<string> _sprNames;

        Dictionary<string, Sprite> _spritesColl;

        //return null if no sprites
        public List<Sprite> GetSprites
        {
            get
            {
                if(_sprites.Count > 0)
                    return _sprites;
                return null;
            }
        }

       
        public AssetManager(ContentManager content)
        {
            _contentManage = content;
            _sprites = new List<Sprite>();
            _sprNames = new List<string>();
            _spritesColl = new Dictionary<string, Sprite>();

            LoadObjects();
        }

        public void Initialize()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (string sprite in _sprNames)
            {
                _spritesColl[sprite].Draw(spriteBatch);
            }
        }
        
        public void Remove(string sprName)
        {
            _sprNames.Remove(sprName);
            _spritesColl.Remove(sprName);
        }

        public void Add(string sprName, Sprite sprite)
        {
            _sprNames.Add(sprName);
            _spritesColl.Add(sprName, sprite);
        }

        public Sprite GetSprite(string sprName)
        {
            if (_spritesColl.ContainsKey(sprName))
                return _spritesColl[sprName];
            return null;
        }

        private void LoadObjects()
        {
            Sprite tuhla1 = new Sprite( _contentManage.Load<Texture2D>("textures/Bricks/120px-Brick_Block"), new Rectangle(0, 0, 50, 50));
            Add("tuhla1", tuhla1);
                            
            Sprite tuhla2 = new Sprite( _contentManage.Load<Texture2D>("textures/Bricks/120px-Brick_Block"), new Rectangle(150, 150, 50, 50));
            Add("tuhla2", tuhla2);

            Sprite tuhla3 = new Sprite( _contentManage.Load<Texture2D>("textures/Bricks/120px-Brick_Block"), new Rectangle(250, 250, 50, 50));
            Add("tuhla3", tuhla3);

            Sprite tuhla4 = new Sprite( _contentManage.Load<Texture2D>("textures/Bricks/120px-Brick_Block"), new Rectangle(320, 250, 50, 50));
            Add("tuhla4", tuhla4);

            Sprite tuhla5 = new Sprite( _contentManage.Load<Texture2D>("textures/Bricks/120px-Brick_Block"), new Rectangle(400, 400, 50, 50));
            Add("tuhla5", tuhla5);
        }        
    }
}
