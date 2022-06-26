
namespace MapEditor.src.TileMapTools
{
    public class PaintTool : BaseTileMapTool
    {
        public PaintTool(string _name) : base(_name){}

        public override void LMBDown()
        {
            GetGridPos();

            if(IsInMap)
            {
                GetTile().TextureID = _paletteManager.ActivePaletteItem.PaletteID;
            }
        }
        public override void LMBHeld()
        {
            GetGridPos();

            if(IsInMap)
            {
                GetTile().TextureID = _paletteManager.ActivePaletteItem.PaletteID;
            }
        }
        public override void RMBDown()
        {
            GetGridPos();

            if(IsInMap)
            {
                GetTile().TextureID = -1;
            }
        }
        public override void RMBHeld()
        {
            GetGridPos();

            if(IsInMap)
            {
                GetTile().TextureID = -1;
            } 
        }
    }
}


