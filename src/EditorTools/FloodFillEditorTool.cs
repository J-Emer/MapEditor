
namespace MapEditor.src.EditorTools
{
    public class FloodFillEditorTool : BaseEditorTool
    {

        //this tool should be called "Layer Fill Tool"

        public FloodFillEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            if(IsInMap)
            {
                foreach (var Tile in GetActiveLayer.Tiles)
                {
                    Tile.TextureID = ActiveTextureID;
                }
            }
        }

    }
}


