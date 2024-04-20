using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_engine;
public class MenuScreen : IScreen
{
    private Texture2D _backgroundTexture;
    private Button _playButton;
    private Button _exitButton;

    public void LoadContent(ContentManager content)
    {
        _backgroundTexture = content.Load<Texture2D>("menu-background");
        _playButton = new Button(content.Load<Texture2D>("play_button"), Play);
        _exitButton = new Button(content.Load<Texture2D>("exit_button"), Exit);
    }

    public void Initialize()
    {
        _playButton.Position = new Point((Globals.SCREEN_WIDTH - _playButton.Bounds.Width) / 2, 450);
        _exitButton.Position = new Point((Globals.SCREEN_WIDTH - _exitButton.Bounds.Width) / 2, 500);
    }

    public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_backgroundTexture, Vector2.Zero, Color.White);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
    }

    private void Play()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Game);
    }

    private void Exit()
    {
        Globals.GameInstance.Exit();
    }
}
