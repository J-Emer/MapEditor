using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

namespace MapEditor.src.Controllers
{
    public class GridController : BaseController
    {

        private MapManager _mapManager;
        private List<Rect> _rects = new List<Rect>();
        private Texture2D _pixel;

        public GridController(Game _game) : base(_game){}

        public override void Load()
        {
            _pixel = new Texture2D(this.GraphicsDevice, 1, 1);
            _pixel.SetData(new Color[] {Color.White});

            _mapManager = ManagerContext.Instance.GetManager<MapManager>();
            _mapManager.OnManagerStateChanged += HandleUI;
        }
        public override void HandleUI()
        {
            _rects.Clear();

            int _tilesX = _mapManager.Map.TilesX;
            int _tilesY = _mapManager.Map.TilesY;
            Vector2 _size = _mapManager.Map.TileSize;

            for (int x = 0; x < _tilesX; x++)
            {
                for (int y = 0; y < _tilesY; y++)
                {
                    Vector2 _pos = (new Vector2(x,y) * _size);
                    _rects.Add(new Rect(_pixel, _pos, _size - Vector2.One, 2));
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            for (int i = 0; i < _rects.Count; i++)
            {
                _rects[i].Draw(Game1._spriteBatch);
            }

            Game1._spriteBatch.End();
        }
    }

    internal class Rect
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public Color DrawColor = Color.White;
        public int LineThickness;
        private Rectangle _sourceRect;

        public Rect(Texture2D _texture, Vector2 _pos, Vector2 _size, int _thickness)
        {
            this.Texture = _texture;
            this.Position = _pos;
            this.Size = _size;
            this.LineThickness = _thickness;
            this._sourceRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, _sourceRect.Width, LineThickness), DrawColor);//top
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Right, _sourceRect.Top, LineThickness, _sourceRect.Height), DrawColor);//right
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Bottom, _sourceRect.Width + LineThickness, LineThickness), DrawColor);//bottom
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, LineThickness, _sourceRect.Height), DrawColor);//left
        }
    }
}


