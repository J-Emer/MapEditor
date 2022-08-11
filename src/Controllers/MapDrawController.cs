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
            Game1._spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, Camera.Main.TransformMatrix);

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
                            //Vector2 _origin = _manager.Map.TileSize / 2f;
                            Color _drawColor = _tile.IsPhysics ? Color.Red : Color.White;
                            Texture2D _texture = _paletteManager.GetTexture(_tile.TextureID);

                            Game1._spriteBatch.Draw
                                                    (
                                                        _texture,
                                                        _pos,
                                                        null,
                                                        _drawColor,
                                                        0f,
                                                        Vector2.Zero,
                                                        Vector2.One,
                                                        SpriteEffects.None,
                                                        Layer.LayerID * 0.1f
                                                    );
                        }
                    }
                }

                //draw the entities for this layer
                //---should have the entities name displayed over the top of the entity texture
                DrawEntities(Layer);
            }

            Game1._spriteBatch.End();
        }

        private void DrawTiles(Layer _layer)
        {

        }
        private void DrawEntities(Layer _layer)
        {
            for (int i = 0; i < _layer.Entities.Count; i++)
            {
                EntityObject _ent = _layer.Entities[i];

                if(_ent.TextureID == -1){continue;}//---if this entity doesn't have a texture, dont draw it

                Texture2D _texture = _paletteManager.GetTexture(_ent.TextureID);
                Vector2 _texturesize = new Vector2(_texture.Width, _texture.Height);
                Color _drawcolor = _ent.IsPhysics ? Color.Red : Color.White;

                

                Game1._spriteBatch.Draw
                                        (
                                            _texture,
                                            _ent.Position,
                                            null,
                                            _drawcolor,
                                            0f,
                                            _texturesize / 2f,
                                            Vector2.One,
                                            SpriteEffects.None,
                                            _layer.LayerID * 0.1f
                                        );

                float x = _ent.Position.X;
                float y = (_ent.Position.Y - (_texturesize.Y / 2)) - 20;

                Game1._spriteBatch.DrawString(AssetLoader.DefaultFont, _ent.Name, new Vector2(x,y), Color.White);

            }
        }

    }
}


