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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Agregate all assets in one strukture to be managed easy
        AssetManager assets;

        //This is the option class
        GameOptions options;

        //Static Fields for global needs
        public static int ScreenWidth;
        public static int ScreenHeight;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;            
            graphics.PreferredBackBufferHeight = 720;

            Content.RootDirectory = "Content";


            //options = new GameOptions(graphics);
        }
               
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            
            //Experimental
            assets = new AssetManager(Content);
            
            base.Initialize();
        }
       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
                
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                        
            assets.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }        
    }
}
