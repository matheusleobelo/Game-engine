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
        private List<Projectile> _projectiles;
        private const float FIRE_RATE = 0.5f; // tempo em segundos entre cada tiro
        private float _fireCooldown;

        public Ship(Texture2D texture, Texture2D projectileTexture, Vector2 position, float speed)
        {
            _texture = texture;
            _position = position;
            _speed = speed;
            _projectileTexture = projectileTexture;
            _projectiles = new List<Projectile>();
            _fireCooldown = 0.0f;
        }

        public void Update(float deltaTime)
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

            // Atualiza os projéteis
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Update(deltaTime);
            }

            // Cooldown de disparo
            _fireCooldown -= deltaTime;

            // Disparo quando a tecla de espaço é pressionada
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _fireCooldown <= 0)
            {
                Fire();
                _fireCooldown = FIRE_RATE;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);

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

    foreach (Projectile projectile in _projectiles)
    {
        Rectangle projectileBounds = projectile.GetBounds();

        if (projectileBounds.Intersects(spiderBounds))
        {
            _projectiles.Remove(projectile); // Desativa o projétil quando colide com a aranha
            break; // Não é necessário continuar verificando os outros projéteis
        }
    }
}


        private void Fire()
        {
            // Cria um novo projétil e o ativa na posição da nave
            Projectile newProjectile = new Projectile(_projectileTexture, _position, 10.0f);
            newProjectile.Activate(new Vector2(_position.X + (_texture.Width / 2) - (_projectileTexture.Width / 2), _position.Y));
            _projectiles.Add(newProjectile);
        }
    }
}
