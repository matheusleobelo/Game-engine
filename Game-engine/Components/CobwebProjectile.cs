using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class CobwebProjectile
{
    private Texture2D _texture;
    private Vector2 _position;
    private float _speed;

    public CobwebProjectile(Texture2D texture, Vector2 position, float speed)
    {
        _texture = texture;
        _position = position;
        _speed = speed;
    }

    public void Update(float deltaTime)
    {
        _position.Y += _speed * deltaTime;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }

    public Rectangle GetBounds()
    {
        return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
    }
}
