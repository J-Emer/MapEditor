using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

namespace MapEditor.src.Controllers
{
    public class LayerController : BaseController
    {
        private MapManager _manager;

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<MapManager>();
            _manager.OnManagerStateChanged += HandleUI;
        }
        protected override void HandleUI()
        {
            
        }
    }
}


