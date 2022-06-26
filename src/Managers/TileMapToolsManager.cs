using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

using MapEditor.src.TileMapTools;

namespace MapEditor.src.Managers
{
    public class TileMapToolsManager : DrawableGameComponent
    {

        public BaseTileMapTool ActiveTool{get; private set;}
        private List<BaseTileMapTool> _tools = new List<BaseTileMapTool>();

        public TileMapToolsManager(Game _game, List<BaseTileMapTool> _tools) : base(_game)
        {
            _game.Components.Add(this);
            _game.Services.AddService(this.GetType(), this);

            this._tools = _tools;
            this.ActiveTool = this._tools[0];
        }


        public void SwitchTools(string _name)
        {
            ActiveTool = _tools.FirstOrDefault(x => x.Name == _name);
        }

        public override void Update(GameTime gameTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ActiveTool.OnMouseButtonDown();
            }
            if(Input.GetMouseButtonUp(0))
            {
                ActiveTool.OnMouseButtonUp();
            }
        }
    }
}


