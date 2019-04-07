using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BrickBreakerM
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] images = new Texture2D[3];

        Paddle paddle;
        Ball ball;

        List<Bricks> bricks = new List<Bricks>();

        KeyboardState ks;

        //Color color = new Color(new Vector3(100f, 0f, 50f)); //Make a Color
        //Color color = Color.Lerp(Color.White, Color.HotPink, 0.5f); //Mixing 2 colors

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

            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();

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

            images[0] = Content.Load<Texture2D>("RedBrick");
            images[1] = Content.Load<Texture2D>("PongBall");
            images[2] = Content.Load<Texture2D>("PaddleBrickBreaker");

            ball = new Ball(images[1], new Vector2(50, 770), new Vector2(15, 13), Color.White);
            paddle = new Paddle(images[2], new Vector2(200, 900), new Vector2(15, 0), Color.White);

            //BRICKS

            float width = 20;
            int spacing = 10;
            int starty = 10;
            int numrows = 6;
            int counter = 0;
            
            Color tempColor = Color.Red;

            for (int i = 0; i < 16 * numrows; i++)
            {                
                Bricks TheBrick = new Bricks(images[0], new Vector2(width + spacing, starty), new Vector2(0, 0), tempColor);
                bricks.Add(TheBrick);
                width = bricks[i].Position.X + bricks[i].Image.Width;

                if (i % 16 == 0 && i != 0) // || i == 30 || i == 45 || i == 60)
                {
                    starty += 50;
                    width = 20;
                    counter++;
                    if (counter == 1)
                    {
                        tempColor = Color.Orange;
                    }

                    else if (counter == 2)
                    {
                        tempColor = Color.Yellow;
                    }

                    else if (counter == 3)
                    {
                        tempColor = Color.Green;
                    }

                    else if (counter == 4)
                    {
                        tempColor = Color.Blue;
                    }

                    else if (counter == 5)
                    {
                        tempColor = Color.Indigo;
                    }

                    else if (counter == 6)
                    {
                        tempColor = Color.Violet;
                    }
                }
            }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ks = Keyboard.GetState();
            // TODO: Add your update logic here

            ////////////////////////////////////////////////////////////////UPDATES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            ball.Update(GraphicsDevice.Viewport);
            paddle.Update(GraphicsDevice.Viewport, ks);

            ////////////////////////////////////////////////////////////////UPDATES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            if (ball.Hitbox.Intersects(paddle.Hitbox))
            {
                ball.Speed.Y *= -1;
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                if (ball.Hitbox.Intersects(bricks[i].Hitbox))
                {
                    ball.Speed.Y *= -1;
                    bricks.Remove(bricks[i]);
                }
            }

            bool gameOver = false;

            if (bricks.Count == 0)
            {
                gameOver = true;
            }

            if (gameOver)
            {

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            ball.Draw(spriteBatch);
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(spriteBatch);
            }
            paddle.Draw(spriteBatch);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
