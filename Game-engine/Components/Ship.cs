using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_engine
{
    public class Ship
    {
        private List<Texture2D> _shipTextures; // Lista de texturas para a animação da nave
        private int _currentFrame;
        private float _frameTimer;
        private float _frameDuration;


        private Texture2D _lifeBar;
        private Rectangle[] _frames;
        private int _index;
        private double _time;


        private int _index2;


        private Texture2D _projectileTexture;
        private Vector2 _position;
        private float _speed;
        private List<Projectile> _projectiles;
        private const float FIRE_RATE = 0.5f;
        private float _fireCooldown;

        public Ship(List<Texture2D> shipTextures, Texture2D projectileTexture, Texture2D lifeBar, Vector2 position, float speed)
        {
            _shipTextures = shipTextures; // Alteração: atribui a lista de texturas fornecida
            _currentFrame = 0;
            _frameTimer = 0.0f;
            _frameDuration = 0.1f;

            _lifeBar = lifeBar;

            _projectileTexture = projectileTexture;
            _position = position;
            _speed = speed;
            _projectiles = new List<Projectile>();
            _fireCooldown = 0.0f;
        }

        public void Initialize()
        {
            _frames = new Rectangle[5]
{
    new Rectangle(0, 0, 42*5, 7*5),
    new Rectangle(48*5, 0, 42*5, 7*5),
    new Rectangle(96*5, 0, 42*5, 7*5),
    new Rectangle(144*5, 0, 42*5, 7*5),
    new Rectangle(192*5, 0, 42*5, 7*5),
};

            _index = 0;
            _time = 0.0f;
            _index2 = 0;
        }

        public void Update(float deltaTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            _time = _time += deltaTime;
            if (_time > 0.1)
            {
                _time = 0.0;
                _index++;
                if (_index > 4)
                {
                    _index = 0;
                }
            }

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
            else if (_position.X > Globals.SCREEN_WIDTH - _shipTextures[0].Width) // Alteração: usa a largura do primeiro quadro da animação
            {
                _position.X = Globals.SCREEN_WIDTH - _shipTextures[0].Width; // Alteração: usa a largura do primeiro quadro da animação
            }

            foreach (Projectile projectile in _projectiles)
            {
                projectile.Update(deltaTime);
            }

            _fireCooldown -= deltaTime;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _fireCooldown <= 0)
            {
                Fire();
                _fireCooldown = FIRE_RATE;
            }

            // Atualiza o contador de tempo para trocar os quadros da animação
            _frameTimer += deltaTime;

            if (_frameTimer >= _frameDuration)
            {
                _currentFrame++;
                if (_currentFrame >= _shipTextures.Count)
                {
                    _currentFrame = 0;
                }
                _frameTimer = 0.0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_shipTextures[_currentFrame], _position, Color.White); // Alteração: desenha o quadro atual da animação
            spriteBatch.Draw(_lifeBar, new Vector2(0, 650), _frames[0], Color.White);


            foreach (Projectile projectile in _projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _shipTextures[_currentFrame].Width, _shipTextures[_currentFrame].Height); // Alteração: usa a largura e a altura do quadro atual da animação
        }

        public void HasCollided(Spider spider)
        {
            Rectangle spiderBounds = spider.GetBounds();

            foreach (Projectile projectile in _projectiles)
            {
                Rectangle projectileBounds = projectile.GetBounds();

                if (projectileBounds.Intersects(spiderBounds))
                {
                    if (_index2 < 5)
                    {
                        _index2++;
                    }
                    else
                    {
                        Globals.GameInstance.ChangeScreen(EScreen.End);
                        _index2 = 0;
                    }
                    _projectiles.Remove(projectile);
                    break;

                }
            }
        }

        public int GetIndex2()
        {
            return _index2;
        }

        private void Fire()
        {
            Projectile newProjectile = new Projectile(_projectileTexture, _position, 10.0f);
            newProjectile.Activate(new Vector2(_position.X + (_shipTextures[_currentFrame].Width / 2) - (_projectileTexture.Width / 2), _position.Y));
            _projectiles.Add(newProjectile);
        }
    }
}
