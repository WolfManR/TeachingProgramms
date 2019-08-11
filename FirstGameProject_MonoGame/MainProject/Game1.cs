using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MainProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    enum State
    {
        SplashScreen,
        Game,
        Pause,
        Final
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        State state = State.SplashScreen;


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
            graphics.PreferredBackBufferWidth=1600;
            graphics.PreferredBackBufferHeight=900;
            graphics.IsFullScreen = false;
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
            SplashScreen.BackGround = Content.Load<Texture2D>("BackGround1");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            GameScene.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Star.Texture2D = Content.Load<Texture2D>("star");
            StarShip.Texture2D = Content.Load<Texture2D>("ship");
            // TODO: use this.Content to load your game content here
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
            KeyboardState keyboardState = Keyboard.GetState();
            switch (state)
            {
                case State.SplashScreen:
                    SplashScreen.Update();
                    if (keyboardState.IsKeyDown(Keys.Space)) state = State.Game;
                    break;
                case State.Game:
                    GameScene.Update();
                    if (keyboardState.IsKeyDown(Keys.Tab)) state = State.SplashScreen;
                    if (keyboardState.IsKeyDown(Keys.Up)) GameScene.StarShip.Up();
                    if (keyboardState.IsKeyDown(Keys.Down)) GameScene.StarShip.Down();
                    if (keyboardState.IsKeyDown(Keys.Left)) GameScene.StarShip.Left();
                    if (keyboardState.IsKeyDown(Keys.Right)) GameScene.StarShip.Right();
                    break;
                case State.Pause:
                    break;
                case State.Final:
                    break;
                default:
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape)) Exit();

            // TODO: Add your update logic here
            
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
            switch (state)
            {
                case State.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case State.Game:
                    GameScene.Draw();
                    break;
                case State.Pause:
                    break;
                case State.Final:
                    break;
                default:
                    break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
