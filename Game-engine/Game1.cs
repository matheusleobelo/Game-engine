using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Ship _ship;
        private Spider _spider;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 531;
            _graphics.PreferredBackBufferHeight = 885;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
            Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;


            _ship = new Ship(Content.Load<Texture2D>("ship"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 130), 5.0f);
            // _ship.Initialize();
            
            _spider = new Spider(Content.Load<Texture2D>("spider"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 880), 3.0f);
            _spider.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("stars");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);

            _ship.Update(gameTime);
            _spider.Update(gameTime);

            _ship.HasCollided(_spider);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _ship.Draw(_spriteBatch);
            _spider.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
