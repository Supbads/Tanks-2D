using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class Menu
    {
        private Texture2D startButton;

        private Texture2D exitButton;

        private Texture2D multiplayerButton;

        private Texture2D pauseButton;

        private Texture2D resumeButton;

        private Texture2D menuBackground;

        private Rectangle backgroundRectangle;

        private Vector2 startButtonPosition = new Vector2(1000, 400);

        private Vector2 exitButtonPosition = new Vector2(1000, 500);

        private Vector2 resumeButtonPosition = new Vector2(400, 300);

        private Vector2 pauseButtonPosition = new Vector2(750, 0);

        private Vector2 multiplayerButtonPosition = new Vector2(1000, 450);

        MouseState mouseState = Mouse.GetState();

        MouseState previousMouseState;

        private int windowWidht;
        private int windowHeight;

        private GameState gameState = GameState.StartMenu;

        enum GameState
        {
            StartMenu,
            Playing,
            Paused,
            Exit,
            Multiplayer
        }


        public Menu(Texture2D[] buttonTextures, int windowWidth, int windowHeight)
        {
            this.startButton = buttonTextures[0];
            this.exitButton = buttonTextures[1];
            this.pauseButton = buttonTextures[2];
            this.resumeButton = buttonTextures[3];
            this.menuBackground = buttonTextures[4];
            this.multiplayerButton = buttonTextures[5];

            this.windowWidht = windowWidth;
            this.windowHeight = windowHeight;

            this.backgroundRectangle = new Rectangle(0, 0, windowWidht, windowHeight);
            previousMouseState = mouseState;
        }

        public int Update()
        {
            //wait for mouseclick
            mouseState = Mouse.GetState();

            if (previousMouseState.LeftButton == ButtonState.Pressed &&
               mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }

            previousMouseState = mouseState;

            int level = 0;
            if (gameState == GameState.Playing)
            {
                level = 1;
            }
            else if (gameState == GameState.Multiplayer)
            {
                level = 2;
            }

            return level;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw the start menu
            if (gameState == GameState.StartMenu)
            {
                spriteBatch.Draw(menuBackground, backgroundRectangle, Color.White);
                spriteBatch.Draw(startButton, startButtonPosition, Color.White);
                spriteBatch.Draw(exitButton, exitButtonPosition, Color.White);
            }

            //draw the pause screen
            if (gameState == GameState.Paused)
            {
                //spriteBatch.Draw(resumeButton, resumeButtonPosition, Color.White);
                spriteBatch.Draw(exitButton, exitButtonPosition, Color.White);
            }

            //draw the the game when playing
            if (gameState == GameState.Playing)
            {
                //pause
                spriteBatch.Draw(pauseButton, pauseButtonPosition, Color.White);
            }
            if (gameState == GameState.Multiplayer)
            {
                spriteBatch.Draw(multiplayerButton, multiplayerButtonPosition, Color.White);
            }
        }

        public void MouseClicked(int x, int y)
        {
            //creates a rectangle of 10x10 around the place where the mouse was clicked
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);

            //check the startmenu
            if (gameState == GameState.StartMenu)
            {
                Rectangle startButtonRect = new Rectangle((int)startButtonPosition.X,
                                             (int)startButtonPosition.Y, 100, 20);
                Rectangle exitButtonRect = new Rectangle((int)exitButtonPosition.X,
                                            (int)exitButtonPosition.Y, 100, 20);
                Rectangle multiplayerButtonRect = new Rectangle((int)multiplayerButtonPosition.X, (int)multiplayerButtonPosition.Y, 137, 28);

                if (mouseClickRect.Intersects(startButtonRect)) //player clicked start button
                {
                    gameState = GameState.Playing;
                }
                else if (mouseClickRect.Intersects(multiplayerButtonRect))
                {
                    gameState = GameState.Multiplayer;
                }
                else if (mouseClickRect.Intersects(exitButtonRect)) //player clicked exit button
                {
                    gameState = GameState.Exit;
                }
            }

            //check the pausebutton
            if (gameState == GameState.Playing)
            {
                Rectangle pauseButtonRect = new Rectangle(750, 0, 70, 70);

                if (mouseClickRect.Intersects(pauseButtonRect))
                {
                    gameState = GameState.Paused;
                }
            }

            //check the resumebutton
            if (gameState == GameState.Paused)
            {
                Rectangle resumeButtonRect = new Rectangle(400, 300, 100, 20);
                Rectangle exitButtonRect = new Rectangle(400, 400, 100, 20);
                exitButtonPosition = new Vector2(400, 400);

                if (mouseClickRect.Intersects(resumeButtonRect))
                {
                    gameState = GameState.Playing;
                }
                if (mouseClickRect.Intersects(exitButtonRect))
                {
                    gameState = GameState.Exit;
                }
            }
        }
    }
}
