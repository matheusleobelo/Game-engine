using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_engine
{
    public class Projectile
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;

        public Projectile(Texture2D texture, Vector2 position, float speed)
        {
            _texture = texture;
            _position = position;
            _speed = speed;
        }

        public void Update()
        {
            // Move o projétil para cima (ou em outra direção, dependendo do seu jogo)
            _position.Y -= _speed;

            // Remove o projétil quando ele sai da tela
            if (_position.Y < -_texture.Height)
            {
                // Remover o projétil da lista ou definir uma flag para removê-lo
                // Isso depende de como você está gerenciando os projéteis em seu jogo
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}