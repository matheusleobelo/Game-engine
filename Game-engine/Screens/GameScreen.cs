using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_engine;

public class GameScreen : IScreen
{
    private GameObject _backgroundI;
    private Ship _ship;
    private Texture2D _projectileTexture;
    private Spider _spider;
    private const float BACKGROUND_SPEED = 100.0f;

    public void Initialize()
    {
        // base.Initialize();
        _spider.Initialize();

        // Define a posição inicial do fundo 
        _backgroundI.Position = new Point(0, -(_backgroundI.Bounds.Height - Globals.SCREEN_HEIGHT));
    }

    public void LoadContent(ContentManager content)
    {
        List<Texture2D> shipTextures = new List<Texture2D>(); // Lista de texturas para a animação da nave
            shipTextures.Add(content.Load<Texture2D>("sprites-ship/ship-1"));
            shipTextures.Add(content.Load<Texture2D>("sprites-ship/ship-2"));
            shipTextures.Add(content.Load<Texture2D>("sprites-ship/ship-3"));

        _ship = new Ship(shipTextures, content.Load<Texture2D>("shoot"), new Vector2(Globals.SCREEN_WIDTH / 2, Globals.SCREEN_HEIGHT - 130), 5.0f);
        _spider = new Spider(content.Load<Texture2D>("spider"), new Vector2(Globals.SCREEN_WIDTH / 2, 0), 3.0f);
        Texture2D backgroundImage = content.Load<Texture2D>("stars");
        _backgroundI = new GameObject(backgroundImage);

        // Carrega a textura do projétil
        _projectileTexture = content.Load<Texture2D>("shoot");
    }

    public void Update(float deltaTime)
    {
        if (Input.GetKeyDown(Keys.Escape))
        {
            Globals.GameInstance.ChangeScreen(EScreen.Menu);
        }

        // move a imagm de fundo para baixo
        _backgroundI.Y += (int)(BACKGROUND_SPEED * deltaTime);

        //  reinicia a posição da imagem
        if (_backgroundI.Y >= 0)
            _backgroundI.Y = -(_backgroundI.Bounds.Height - Globals.SCREEN_HEIGHT);

        _ship.Update(deltaTime);
        _spider.Update(deltaTime);

        _ship.HasCollided(_spider);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _backgroundI.Draw(spriteBatch); // Desenha o fundo na posição atual
        _ship.Draw(spriteBatch);
        _spider.Draw(spriteBatch);
    }

}
