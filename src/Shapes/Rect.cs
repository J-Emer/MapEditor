using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.src.Shapes
{
    public class Rect
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public Color DrawColor = Color.White;
        private int _lineThickness;
        private Rectangle _sourceRect;

        public Rect(int _lineThickness, Texture2D texture, Vector2 position, Vector2 size)
        {
            this._lineThickness = _lineThickness;
            this.Texture = texture;
            this.Position = position;
            this.Size = size;
            _sourceRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, _sourceRect.Width, _lineThickness), DrawColor);//top
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Right, _sourceRect.Top, _lineThickness, _sourceRect.Height), DrawColor);//right
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Bottom, _sourceRect.Width + _lineThickness, _lineThickness), DrawColor);//bottom
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, _lineThickness, _sourceRect.Height), DrawColor);//left
        }
    }
}


