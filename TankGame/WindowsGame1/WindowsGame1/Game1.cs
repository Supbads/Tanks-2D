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
                
        //Player
        Player player;
        Texture2D[] tankPositions; //Containing the 4 images for every direction of the tank
        Rectangle playerPosition;

        public static int screenWidth;
        public static int screenHeight;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Init player
            //player.Initialize(playerTank, playerPosition);       

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            // OLD CODE -------------------- 
           /* Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("animations/shipAnimation");
            playerAnimation.Initialize( playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true );
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, 
                GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(playerAnimation, playerPosition); 
            -------------------------------------------------------*/

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            tankPositions = new Texture2D[4];
            tankPositions[0] = Content.Load<Texture2D>("sprites/BlueTank/BlueTankUp");
            tankPositions[1] = Content.Load<Texture2D>("sprites/BlueTank/BlueTankDown");
            tankPositions[2] = Content.Load<Texture2D>("sprites/BlueTank/BlueTankLeft");
            tankPositions[3] = Content.Load<Texture2D>("sprites/BlueTank/BlueTankRight");

            playerPosition = new Rectangle(300, 700, tankPositions[0].Width, tankPositions[0].Height);
            player = new Player(graphics, tankPositions, playerPosition);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            
            //Store Keyboard state
            //previousKbState = currentKbState;
            //currentKbState = Keyboard.GetState();

            //Update Player
            //UpdatePlayer(gameTime);
            //pControl.UpdatePlayer();
            player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }        
    }
}
