using System.Collections.Generic;

using Microsoft.Xna.Framework;

using MapEditor.src.EditorTools;


namespace MapEditor.src.Controllers
{
    public class EditorToolsController : BaseController
    {
        public BaseEditorTool ActiveTool{get; private set;}
        private List<BaseEditorTool> _tools;


        
        public EditorToolsController(Game _game, List<BaseEditorTool> _tools) : base(_game)
        {
            this._tools = _tools;
        }

        public override void Load()
        {
            if(_tools.Count > 0)
            {
                ActiveTool = _tools[0];
            }
        }
        public override void Update(GameTime gameTime)
        {
            if(ActiveTool == null){return;}

            if(Input.GetMouseButtonDown(0))
            {
                ActiveTool.LMBDown();
            }
            if(Input.GetMouseButtonDown(1))
            {
                ActiveTool.RMBDown();
            }
        }
        public void SetTool(string _title)
        {
            ActiveTool = _tools.Find(x => x.Title == _title);
        }
    }
}


