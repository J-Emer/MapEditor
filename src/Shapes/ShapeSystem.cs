using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MapEditor.src.Managers;
using MapEditor.src.Contexts;

namespace MapEditor.src.Shapes
{
    public class ShapeSystem : DrawableGameComponent
    {
        private List<Rect> _rects = new List<Rect>();
        private Texture2D _pixel;
        private MapManager _mapManager;


        public ShapeSystem(Game _game) : base(_game)
        {
            _game.Components.Add(this);
            _game.Services.AddService(this.GetType(), this);

            _pixel = new Texture2D(_game.GraphicsDevice, 1, 1);
            _pixel.SetData(new Color[] {Color.White});

            _mapManager = ManagerContext.Instance.GetManager<MapManager>();
            _mapManager.OnManagerStateChanged += SetGrid;
            SetGrid();
        }

        private void SetGrid()
        {
            Clear();

            for (int x = 0; x < _mapManager.Map.TilesWide; x++)
            {
                for (int y = 0; y < _mapManager.Map.TilesHigh; y++)
                {
                    Vector2 _pos = new Vector2(x, y) * _mapManager.Map.TileSize;
                    AddRect(_pos, _mapManager.Map.TileSize - Vector2.One);
                }
            }
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
            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            //Game1._spriteBatch.Begin();

            for (int i = 0; i < _rects.Count; i++)
            {
                _rects[i].Draw(Game1._spriteBatch);
            }

            Game1._spriteBatch.End();
        }
    }
}


