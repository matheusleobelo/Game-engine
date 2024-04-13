using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_engine
{
    public class Shoot
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;

        public Texture2D Texture { get { return _texture; } }
        public Vector2 Position { get { return _position; } }

        public Shoot(Texture2D texture, Vector2 vector2, float v)
        {
            _texture = texture;
        }

        public void Initialize(Vector2 position, float speed)
        {
            _position = position;
            _speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            _position.Y -= _speed;

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
    
}
