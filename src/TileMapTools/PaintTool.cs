using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapEditor.src.TileMapTools
{
    public class PaintTool : BaseTileMapTool
    {
        public PaintTool(string _name) : base(_name){}

        public override void OnMouseButtonDown()
        {
            Vector2 _pos = Camera.Main.RoundMouseToNearest((int)_mapManager.Map.TileSize.X);
            int x = (int)_pos.X;
            int y = (int)_pos.Y;

            if(IsInMap(x,y))
            {
                _layerManager.GetTile(x,y).TextureID = _paletteManager.ActivePaletteItem.PaletteID;
            }
        }
        /*public override void OnMouseButtonUp()
        {
            Vector2 _pos = Camera.Main.RoundMouseToNearest((int)_mapManager.Map.TileSize.X);
            int x = (int)_pos.X;
            int y = (int)_pos.Y;

            if(IsInMap(x,y))
            {
                _layerManager.GetTile(x,y).TextureID = -1;
            }
        }*/
    }
}


