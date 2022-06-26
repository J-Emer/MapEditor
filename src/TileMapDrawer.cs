using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

namespace MapEditor.src
{
    public class TileMapDrawer : DrawableGameComponent
    {
        private MapManager Manager
        {
            get
            {
                if(_manager == null)
                {
                    _manager = ManagerContext.Instance.GetManager<MapManager>();
                }
                return _manager;
            }
        }
        private MapManager _manager;

        private PaletteManager PaletteManager
        {
            get
            {
                if(_paletteManager == null)
                {
                    _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
                }
                return _paletteManager;
            }
        }
        private PaletteManager _paletteManager;




        public TileMapDrawer(Game _game) : base(_game)
        {
            _game.Components.Add(this);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            Vector2 _tileSize = Manager.Map.TileSize;

            foreach (var Layer in Manager.Map.Layers)
            {
                for (int x = 0; x < Manager.Map.TilesWide; x++)
                {
                    for (int y = 0; y < Manager.Map.TilesHigh; y++)
                    {
                        Tile _tile = Layer.GetTile(x,y);

                        if(_tile.TextureID == -1){continue;}

                        Vector2 _pos = new Vector2(x,y) * _tileSize;

                        Texture2D _texture = PaletteManager.GetPaletteTexture(_tile.TextureID);
                        
                        Color _drawColor = _tile.IsPhysics ? Color.Red : Color.White;

                        Game1._spriteBatch.Draw(_texture, _pos, _drawColor);
                    }
                }
            }

            Game1._spriteBatch.End();
        }
    }
}


