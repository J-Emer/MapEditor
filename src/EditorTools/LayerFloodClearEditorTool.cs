
namespace MapEditor.src.EditorTools
{
    public class LayerFloodClearEditorTool : BaseEditorTool
    {
        public LayerFloodClearEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            if(IsInMap)
            {
                foreach (var Tile in GetActiveLayer.Tiles)
                {
                    Tile.TextureID = -1;
                }
            }
        }
    }
}


