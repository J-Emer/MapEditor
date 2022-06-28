
namespace MapEditor.src.EditorTools
{
    public abstract class BaseEditorTool
    {
        public string Title{get; private set;}

        public BaseEditorTool(string _title)
        {
            this.Title = _title;
        }

        public virtual void LMBDown(){}
        public virtual void RMBDown(){}

    }
}


