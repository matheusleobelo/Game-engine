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
            if (keyboardState.IsKeyDown(Keys.W))
            {
                _position.Y -= _speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                _position.Y += _speed;
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

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public void HasCollided(Spider spider)
        {
            Rectangle spiderBounds = spider.GetBounds();
            Rectangle shipBounds = GetBounds();

            if (shipBounds.Intersects(spiderBounds))
            {
                if (!spider.HasDisappeared())
                {
                    spider.Disappear();

                    if (spider.Velocity < 0)
                    {
                        spider.SetPosition(_position.X + _texture.Width);
                    }
                    else
                    {
                        spider.SetPosition(_position.X - _texture.Width);
                    }
                }
            }

        }
    }
}

//