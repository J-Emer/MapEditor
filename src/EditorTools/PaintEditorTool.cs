
namespace MapEditor.src.EditorTools
{
    public class PaintEditorTool : BaseEditorTool
    {
        public PaintEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            if(IsInMap)
            {
                ActiveTile.TextureID = ActiveTextureID;
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


