using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.src.Shapes
{
    public class ShapeSystem : DrawableGameComponent
    {
        private List<Rect> _rects = new List<Rect>();
        private Texture2D _pixel;

        public ShapeSystem(Game _game) : base(_game)
        {
            _game.Components.Add(this);
            _game.Services.AddService(this.GetType(), this);

            _pixel = new Texture2D(_game.GraphicsDevice, 1, 2);
            _pixel.SetData(new Color[] {Color.White});
        }

        public void AddRect(Vector2 _pos, Vector2 _size)
        {
            _rects.Add(new Rect(2, _pixel, _pos, _size));
        }
        public void Clear()
        {
            _rects.Clear();
        }
        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin();

            for (int i = 0; i < _rects.Count; i++)
            {
                _rects[i].Draw(Game1._spriteBatch);
            }

            Game1._spriteBatch.End();
        }
    }
}


