using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_engine
{
    public class Ship
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;


        private Texture2D _projectileTexture;
        private List<Projectile> _projectiles = new List<Projectile>();
        private float _shootCooldown = 0.5f;
        private float _shootTimer = 0f;
        public Ship(Texture2D texture, Vector2 position, float speed, Texture2D projectileTexture)
        {
            _texture = texture;
            _position = position;
            _speed = speed;
            _projectileTexture = projectileTexture;
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

            // Atualiza o temporizador de disparo
            _shootTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (keyboardState.IsKeyDown(Keys.Space) && _shootTimer <= 0)
            {
                Shoot();
                // Reseta o temporizador de disparo
                _shootTimer = _shootCooldown;
            }

            // Atualiza os projéteis
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Update();
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
            
            // Desenha os projéteis
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }



        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public void HasCollided(Spider spider)
{
    Rectangle spiderBounds = spider.GetBounds();

    // Verifica colisão entre os projéteis e a aranha
    foreach (Projectile projectile in _projectiles)
    {
        Rectangle projectileBounds = projectile.GetBounds();

        if (projectileBounds.Intersects(spiderBounds))
        {
            // Remove o projétil
            _projectiles.Remove(projectile);
            break; 
        }
    }
}


        private void Shoot()
        {
            Projectile newProjectile = new Projectile(_projectileTexture, new Vector2(_position.X + _texture.Width / 2 - _projectileTexture.Width / 2, _position.Y), _speed);
            _projectiles.Add(newProjectile);
        }
    }
}
