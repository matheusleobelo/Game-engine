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
        private Vector2 _backgroundPosition = Vector2.Zero; // Posição do fundo
        private Ship _ship;
        private Spider _spider;

        private Texture2D _spiderAnimation;
        private Rectangle[] _frames;
        private int _index;
        private double _time;
        

        // Adicione uma textura para o projétil
        private Texture2D _projectileTexture;

        // Velocidade de movimento do fundo
        private const float BACKGROUND_SPEED = 100.0f;

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

            _frames = new Rectangle[10]
            {
    // Coordenadas para cada quadro na sprite sheet (organizada em 4 colunas por 3 linhas)
    new Rectangle(0, 0, 416, 340),      // Quadro 1 (coluna 1, linha 1)
    new Rectangle(416, 0, 416, 340),    // Quadro 2 (coluna 2, linha 1)
    new Rectangle(832, 0, 416, 340),    // Quadro 3 (coluna 3, linha 1)
    new Rectangle(1248, 0, 416, 340),   // Quadro 4 (coluna 4, linha 1)
    new Rectangle(0, 340, 416, 340),    // Quadro 5 (coluna 1, linha 2)
    new Rectangle(416, 340, 416, 340),  // Quadro 6 (coluna 2, linha 2)
    new Rectangle(832, 340, 416, 340),  // Quadro 7 (coluna 3, linha 2)
    new Rectangle(1248, 340, 416, 340), // Quadro 8 (coluna 4, linha 2)
    new Rectangle(0, 680, 416, 340),    // Quadro 9 (coluna 1, linha 3)
    new Rectangle(416, 680, 416, 340)   // Quadro 10 (coluna 2, linha 3)
};

            _index = 0;
            _time = 0.0;

            _ship = new Ship(Content.Load<Texture2D>("ship"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 130), 5.0f, _projectileTexture);


            _spider = new Spider(Content.Load<Texture2D>("spider"), Content.Load<Texture2D>("spiderSprite"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 880), 3.0f);

            _spider.Initialize();
            // Define a posição inicial do fundo 
            _backgroundPosition = new Vector2(0, -(_background.Height - _graphics.PreferredBackBufferHeight));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("stars");

            _spiderAnimation = Content.Load<Texture2D>("spiderSprite");

            // Carrega a textura do projétil
            _projectileTexture = Content.Load<Texture2D>("shoot");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);

            _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
            if (_time > 0.1)
            {
                _time = 0.0;
                _index++;
                if (_index > 5)
                {
                    _index = 0;
                }
            }

            // move a imagm de fundo para baixo
            _backgroundPosition.Y += BACKGROUND_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //  reinicia a posição da imagem
            if (_backgroundPosition.Y >= 0)
                _backgroundPosition.Y = -(_background.Height - _graphics.PreferredBackBufferHeight);

            _ship.Update(gameTime);
            _spider.Update(gameTime);

            _ship.HasCollided(_spider);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, _backgroundPosition, Color.White); // Desenha o fundo na posição atual
            _ship.Draw(_spriteBatch);
            _spider.Draw(_spriteBatch);
            // _spriteBatch.Draw(_spiderAnimation, new Rectangle(0, 0, 416, 340), _frames[_index], Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
