
namespace MapEditor.src.EditorTools
{
    public class PaintEditorTool : BaseEditorTool
    {
        public PaintEditorTool(string _title) : base(_title){}

        public override void LMBDown()
        {
            System.Console.WriteLine(this.GetType().Name + " LMBDown()");
        }
    }
}


