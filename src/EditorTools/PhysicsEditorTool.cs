
namespace MapEditor.src.EditorTools
{
    public class PhysicsEditorTool : BaseEditorTool
    {
        public PhysicsEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            if(IsInMap)
            {
                ActiveTile.IsPhysics = true;
            }
        }
        public override void RMBDown()
        {
            if(IsInMap)
            {
                ActiveTile.IsPhysics = false;
            }
        }
    }
}


