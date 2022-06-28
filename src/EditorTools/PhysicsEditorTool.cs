
namespace MapEditor.src.EditorTools
{
    public class PhysicsEditorTool : BaseEditorTool
    {
        public PhysicsEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            System.Console.WriteLine(this.GetType().Name + " LMBDown()");
        }
    }
}


