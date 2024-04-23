using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_engine;
public class EndScreen : IScreen
{
    private Texture2D _backgroundTexture;
    private Button _playButton;
    private Button _exitButton;

    private SpriteFont _spriteFont;

    public void LoadContent(ContentManager content)
    {
        _backgroundTexture = content.Load<Texture2D>("EndScreen");
        _playButton = new Button(content.Load<Texture2D>("play_button"), Play);
        _exitButton = new Button(content.Load<Texture2D>("exit_button"), Exit);

        _spriteFont =  content.Load<SpriteFont>("EncodeSansExpanded-Medium");
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
        spriteBatch.DrawString(_spriteFont, "Score: 5000"  , new Vector2(315, 375), Color.White);
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
