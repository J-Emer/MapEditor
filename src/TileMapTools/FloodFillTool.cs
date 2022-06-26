
namespace MapEditor.src.TileMapTools
{
    public class FloodFillTool : BaseTileMapTool
    {
        public FloodFillTool(string _name) : base(_name)
        {

        }
        public override void LMBDown()
        {
            if(IsInMap)
            {
                foreach (var item in _layerManager.ActiveLayer.Tiles)
                {
                    item.TextureID = _paletteManager.ActivePaletteItem.PaletteID;
                }
            }
        }
    }
    public class FloodClearTool : BaseTileMapTool
    {
        public FloodClearTool(string _name) : base(_name)
        {

        }
        public override void LMBDown()
        {
            if(IsInMap)
            {
                foreach (var item in _layerManager.ActiveLayer.Tiles)
                {
                    item.TextureID = -1;
                }
            }
        }
    }
}


