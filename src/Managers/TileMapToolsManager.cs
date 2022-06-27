using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

using MapEditor.src.TileMapTools;

namespace MapEditor.src.Managers
{
    public class TileMapToolsManager : DrawableGameComponent
    {
        public static TileMapToolsManager Instance;

        public BaseTileMapTool ActiveTool{get; private set;}
        private List<BaseTileMapTool> _tools = new List<BaseTileMapTool>();

        public TileMapToolsManager(Game _game, List<BaseTileMapTool> _tools) : base(_game)
        {
            _game.Components.Add(this);
            _game.Services.AddService(this.GetType(), this);

            this._tools = _tools;
            this.ActiveTool = this._tools[0];

            Instance = this;
        }


        public void SwitchTools(string _name)
        {
            ActiveTool = _tools.FirstOrDefault(x => x.Name == _name);
        }

        public override void Update(GameTime gameTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ActiveTool.LMBDown();
            }
            if(Input.GetMouseButton(0))
            {
                ActiveTool.LMBHeld();
            }
            if(Input.GetMouseButtonDown(1))
            {
                ActiveTool.RMBDown();
            }
            if(Input.GetMouseButton(1))
            {
                ActiveTool.RMBHeld();
            }
        }
    }
}

