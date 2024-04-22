using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine
{
    public class Projectile2
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;
        private bool _isActive;

        public Projectile2(Texture2D texture, Vector2 position, float speed)
        {
            _texture = texture;
            _position = position;
            _speed = 300.0f;;
            _isActive = false;
        }

        public void Update(float deltaTime)
        {
            if (_isActive)
            {
                _position.Y -= _speed * deltaTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isActive)
            {
                spriteBatch.Draw(_texture, _position, Color.White);
            }
        }

        public void Activate(Vector2 position)
        {
            _position = position;
            _isActive = true;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public bool IsActive()
        {
            return _isActive;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
    }
}
