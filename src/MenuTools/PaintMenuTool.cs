using EditorUI_DX.Utils;

using MapEditor.src.Contexts;
using MapEditor.src.Controllers;

namespace MapEditor.src.MenuTools
{

    //---honestly this should be part of the EditorToolsController

    public class PaintMenuTool : BaseMenuTool
    {
        public PaintMenuTool(string _title) : base(_title){}

        protected override void ButtonPress(MouseEventArgs e)
        {
            ControllerContext.Instance.GetController<EditorToolsController>().SetTool(this.Title);
        }
    }
    public class PhysicsMenuTool : BaseMenuTool
    {
        public PhysicsMenuTool(string _title) : base(_title){}

        protected override void ButtonPress(MouseEventArgs e)
        {
            ControllerContext.Instance.GetController<EditorToolsController>().SetTool(this.Title);
        }
    }
    public class FillLayerMenuTool : BaseMenuTool
    {
        public FillLayerMenuTool(string _title) : base(_title){}

        protected override void ButtonPress(MouseEventArgs e)
        {
            ControllerContext.Instance.GetController<EditorToolsController>().SetTool(this.Title);
        }
    }
    public class ClearLayerMenuTool : BaseMenuTool
    {
        public ClearLayerMenuTool(string _title) : base(_title){}

        protected override void ButtonPress(MouseEventArgs e)
        {
            ControllerContext.Instance.GetController<EditorToolsController>().SetTool(this.Title);
        }
    }
}


