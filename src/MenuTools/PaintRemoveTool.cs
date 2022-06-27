using EditorUI_DX.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

namespace MapEditor.src.MenuTools
{
    public class PaintRemoveTool : BaseMenuTool
    {
        public PaintRemoveTool(string _title) : base(_title)
        {

        }
        protected override void ButtonDown(MouseEventArgs e)
        {
            TileMapToolsManager.Instance.SwitchTools("Paint");
        }
    }
    public class PhysicsMenuTool : BaseMenuTool
    {
        public PhysicsMenuTool(string _title) : base(_title)
        {

        }
        protected override void ButtonDown(MouseEventArgs e)
        {
            TileMapToolsManager.Instance.SwitchTools("Physics");
        }
    }
    public class FloodFillMenuTool : BaseMenuTool
    {
        public FloodFillMenuTool(string _title) : base(_title)
        {

        }
        protected override void ButtonDown(MouseEventArgs e)
        {
            TileMapToolsManager.Instance.SwitchTools("Flood_Fill");
        }
    }
    public class FloodClearMenuTool : BaseMenuTool
    {
        public FloodClearMenuTool(string _title) : base(_title)
        {

        }
        protected override void ButtonDown(MouseEventArgs e)
        {
            TileMapToolsManager.Instance.SwitchTools("Flood_Clear");
        }
    }
}


