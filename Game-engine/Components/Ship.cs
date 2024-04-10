using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine
{
    public class Ship
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;

        public Ship(Texture2D texture, Vector2 position, float speed)
        {
            _texture = texture;
            _position = position;
            _speed = speed;
        }

        // public void Initialize()
        // {
        //     Globals.SHIP_WIDTH = _texture.Width;
        // }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                _position.X -= _speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _position.X += _speed;
            }


            if (_position.X < 0)
            {
                _position.X = 0;
            }
            else if (_position.X > Globals.SCREEN_WIDTH - _texture.Width)
            {
                _position.X = Globals.SCREEN_WIDTH - _texture.Width;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

    }
}

//