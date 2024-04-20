using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_engine
{
    public class Spider
    {
        private Texture2D _texture;
        private Texture2D _texture2;
        private Vector2 _position;


        private Rectangle[] _frames;
        private int _index;
        private double _time;


        private float _speed;
        private bool right;
        private bool left;

        private bool _disappeared = false;

        public float Velocity { get => _speed; }


        public Spider(Texture2D texture, Texture2D texture2, Vector2 position, float speed)
        {
            _texture = texture;
            _texture2 = texture2;
            _position = position;
            _speed = speed;
        }

        public void Initialize()
        {
            right = true;
            left = false;


            _frames = new Rectangle[10]
            {
    // Coordenadas para cada quadro na sprite sheet (organizada em 4 colunas por 3 linhas)
    new Rectangle(0, 0, 416, 340),      // Quadro 1 (coluna 1, linha 1)
    new Rectangle(416, 0, 416, 340),    // Quadro 2 (coluna 2, linha 1)
    new Rectangle(832, 0, 416, 340),    // Quadro 3 (coluna 3, linha 1)
    new Rectangle(1248, 0, 416, 340),   // Quadro 4 (coluna 4, linha 1)
    new Rectangle(0, 340, 416, 340),    // Quadro 5 (coluna 1, linha 2)
    new Rectangle(416, 340, 416, 340),  // Quadro 6 (coluna 2, linha 2)
    new Rectangle(832, 340, 416, 340),  // Quadro 7 (coluna 3, linha 2)
    new Rectangle(1248, 340, 416, 340), // Quadro 8 (coluna 4, linha 2)
    new Rectangle(0, 680, 416, 340),    // Quadro 9 (coluna 1, linha 3)
    new Rectangle(416, 680, 416, 340)   // Quadro 10 (coluna 2, linha 3)
};

            _index = 0;
            _time = 0.0f;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
            if (_time > 0.1)
            {
                _time = 0.0;
                _index++;
                if (_index > 9)
                {
                    _index = 0;
                }
            }

            if (right)
            {
                if (_position.X < Globals.SCREEN_WIDTH - 416)
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

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_disappeared)
            {
                // spriteBatch.Draw(_texture, _position, _frames[_index], Color.White);
                spriteBatch.Draw(_texture2, _position, _frames[_index], Color.White);
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

    }
}