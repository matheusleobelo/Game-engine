using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_engine
{
    public class Spider
    {
        private Texture2D _texture;
        private Texture2D _texture2;
        private Texture2D _spiderLifeBar;
        private Texture2D _cobwebTexture; // Textura do projétil de teia
        private Vector2 _position;

        private Rectangle[] _frames;
        private int _index;
        private double _time;

        private Rectangle[] _frames2;
        private int _index2;

        private float _speed;
        private bool right;
        private bool left;

        private bool _disappeared = false;

        private List<CobwebProjectile> _cobwebProjectiles; // Lista de projéteis de teia

        private float _shootCobwebTimer = 0.0f;
        private float _shootCobwebInterval; // Intervalo entre disparos (em segundos)

        public float Velocity { get => _speed; }

        public Spider(Texture2D texture, Texture2D texture2, Texture2D spiderLifeBar, Texture2D cobwebTexture, Vector2 position, float speed)
        {
            _texture = texture;
            _texture2 = texture2;
            _spiderLifeBar = spiderLifeBar;
            _cobwebTexture = cobwebTexture;
            _position = position;
            _speed = speed;

            _shootCobwebInterval = 0.0f;
            _cobwebProjectiles = new List<CobwebProjectile>();
        }

        public void Initialize()
        {
            right = true;
            left = false;

            _frames = new Rectangle[10]
            {
                new Rectangle(0, 0, 312, 255),
                new Rectangle(312, 0, 312, 255),
                new Rectangle(624, 0, 312, 255),
                new Rectangle(936, 0, 312, 255),
                new Rectangle(0, 255, 312, 255),
                new Rectangle(312, 255, 312, 255),
                new Rectangle(624, 255, 312, 255),
                new Rectangle(936, 255, 312, 255),
                new Rectangle(0, 510, 312, 255),
                new Rectangle(312, 510, 312, 255)
            };

            _index = 0;
            _time = 0.0f;

            _frames2 = new Rectangle[6]
            {
                new Rectangle(0, 0, 42*5, 11 *5),
                new Rectangle(48*5, 0, 42*5, 11*5),
                new Rectangle(96*5, 0, 42*5, 11*5),
                new Rectangle(144*5, 0, 42*5, 11*5),
                new Rectangle(192*5, 0, 42*5, 11*5),
                new Rectangle(240*5, 0, 42*5, 11*5)
            };

            _index2 = 0;
        }

        public void Update(float deltaTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            _time += deltaTime;
            if (_time > 0.1)
            {
                _time = 0.0;
                _index++;
                if (_index > 9)
                {
                    _index = 0;
                }
            }

            // Atualiza a posição dos projéteis de teia
            foreach (var projectile in _cobwebProjectiles)
            {
                projectile.Update(deltaTime);
            }

            // Remove projéteis que saíram da tela
            _cobwebProjectiles.RemoveAll(p => p.GetBounds().Bottom > Globals.SCREEN_HEIGHT);

            // Lógica de movimento da aranha
            if (right)
            {
                if (_position.X < Globals.SCREEN_WIDTH - 312)
                {
                    _position.X += _speed;
                }
                else
                {
                    right = false;
                    left = true;
                }
            }
            if (left)
            {
                if (_position.X > 0)
                {
                    _position.X -= _speed;
                }
                else
                {
                    right = true;
                    left = false;
                }
            }

            // Lógica de disparo da teia
            _shootCobwebTimer += deltaTime;
            if (_shootCobwebTimer >= _shootCobwebInterval)
            {
                _shootCobwebTimer = 0.0f;
                ShootCobweb();
            }

            _shootCobwebInterval -= deltaTime;
        }


        private void ShootCobweb()
        {
            Vector2 projectilePosition = new Vector2(_position.X + (_texture2.Width / 2), _position.Y + _texture2.Height);

            CobwebProjectile newProjectile = new CobwebProjectile(_cobwebTexture, projectilePosition, 10.0f); // Velocidade do projétil
            _cobwebProjectiles.Add(newProjectile);
            System.Console.WriteLine("Cobweb shot! Position: " + projectilePosition); // Log de depuração
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_disappeared)
            {
                spriteBatch.Draw(_texture2, _position, _frames[_index], Color.White);
                spriteBatch.Draw(_spiderLifeBar, _position, _frames2[_index2], Color.White);
            }

            // Desenha os projéteis de teia
            foreach (var projectile in _cobwebProjectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public bool HasDisappeared()
        {
            return _disappeared;
        }

        public void Disappear()
        {
            _disappeared = true;
        }

        public void SetPosition(float X)
        {
            _position.X = X;
        }

        public void GetIndex2(int index)
        {
            _index2 = index;
        }
    }
}
