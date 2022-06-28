using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MapEditor.src.TileMapData;
using MapEditor.src.Contexts;
using MapEditor.src.Managers;

namespace MapEditor.src.Controllers
{
    public class MapDrawController : BaseController
    {
        private MapManager _manager;
        private PaletteManager _paletteManager;

        public MapDrawController(Game _game) : base(_game){}

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<MapManager>();

            _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
        }

        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            foreach (var Layer in _manager.Map.Layers)
            {
                for (int x = 0; x < Layer.TilesX; x++)
                {
                    for (int y = 0; y < Layer.TilesY; y++)
                    {
                        Tile _tile = Layer.Tiles[x, y];

                        if(_tile.TextureID != -1)
                        {
                            //then draw the tile

                            Vector2 _pos = new Vector2(x, y) * _manager.Map.TileSize;
                            Vector2 _origin = _manager.Map.TileSize / 2f;
                            Color _drawColor = _tile.IsPhysics ? Color.Red : Color.White;
                            Texture2D _texture = _paletteManager.GetTexture(_tile.TextureID);

                            Game1._spriteBatch.Draw
                                                    (
                                                        _texture,
                                                        _pos,
                                                        null,
                                                        _drawColor,
                                                        0f,
                                                        _origin,
                                                        Vector2.One,
                                                        SpriteEffects.None,
                                                        Layer.LayerID * 0.1f
                                                    );
                        }
                    }
                }
            }

            Game1._spriteBatch.End();
        }

    }
}


