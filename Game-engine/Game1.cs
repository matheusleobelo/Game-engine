using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IScreen _menuScreen;
    private IScreen _gameScreen;
    private IScreen _currentScreen;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 531;
        _graphics.PreferredBackBufferHeight = 728;
        _graphics.ApplyChanges();
    }

    public void ChangeScreen(EScreen screenType)
    {
        switch (screenType)
        {
            case EScreen.Menu:
                _currentScreen = _menuScreen;
                break;
            case EScreen.Game:
                _currentScreen = _gameScreen;
                break;
        }

        _currentScreen.Initialize();
    }

    protected override void Initialize()
    {
        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
        base.Initialize();

        Globals.GameInstance = this;
        _currentScreen.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _menuScreen = new MenuScreen();
        _menuScreen.LoadContent(Content);

        _gameScreen = new GameScreen();
        _gameScreen.LoadContent(Content);

        _currentScreen = _menuScreen;
    }

    protected override void Update(GameTime gameTime)
    {
        // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //     Exit();

        _currentScreen.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _currentScreen.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
