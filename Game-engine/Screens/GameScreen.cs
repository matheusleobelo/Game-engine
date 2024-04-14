using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine;

public class GameScreen : IScreen
{
    // private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameObject _backgroundI;
    private Texture2D _background;
    private Vector2 _backgroundPosition = Vector2.Zero; // Posição do fundo
    private Ship _ship;
    // private Texture2D _projectileTexture;
    private Spider _spider;
    // private const float BACKGROUND_SPEED = 100.0f;

    public void Initialize()
    {
        // base.Initialize();
        // _ship = new Ship(Content.Load<Texture2D>("ship"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 130), 5.0f, _projectileTexture);
        // _spider = new Spider(Content.Load<Texture2D>("spider"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight - 880), 3.0f);
        // _spider.Initialize();

        // // Define a posição inicial do fundo 
        // _backgroundPosition = new Vector2(0, -(_background.Height - _graphics.PreferredBackBufferHeight));
    }

    public void LoadContent(ContentManager content)
    {
        Texture2D backgroundImage = content.Load<Texture2D>("stars");
        _backgroundI = new GameObject(backgroundImage);
        // _projectileTexture = Content.Load<Texture2D>("shoot");
    }

    public void Update(float deltaTime)
    {
        if (Input.GetKeyDown(Keys.Escape))
        {
            Globals.GameInstance.ChangeScreen(EScreen.Menu);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // _spriteBatch.Draw(_background, _backgroundPosition, Color.White); // Desenha o fundo na posição atual
        // _ship.Draw(_spriteBatch);
        // _spider.Draw(_spriteBatch);
        _backgroundI.Draw(spriteBatch);
    }

}
