
namespace MapEditor.src.EditorTools
{
    public class PaintEditorTool : BaseEditorTool
    {
        public PaintEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            if(IsInMap)
            {

                //_layerManager.ActiveLayer.Tiles[GridX, GridY].TextureID = _paletteManager.ActivePaletteItem.TextureID;
                _layerManager.GetTile(GridX, GridY).TextureID = _paletteManager.ActivePaletteItem.TextureID;
                //ActiveTile.TextureID = ActiveTextureID;
            }
        }

        public override void RMBDown()
        {
            if(IsInMap)
            {
                ActiveTile.TextureID = -1;
            }
        }
    }
}


