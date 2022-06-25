using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.Controllers;

namespace MapEditor.src
{
    public class Loader
    {
        public static Loader Instance;

        public MainDesktop Desktop{get; private set;}

        public Loader(MainDesktop _desktop)
        {
            this.Desktop = _desktop;
            Instance = this;

            Load();
        }

        public void Load()
        {
            new ManagerContext();
            new ControllerContext();

            LoadManagers();
            LoadControllers();
            LoadMenuTools();
            LoadEditorTools();

            ManagerContext.Instance.LoadAll();
            ControllerContext.Instance.LoadAll();
            ControllerContext.Instance.ForceRefreshAll();
        }

        private void LoadManagers()
        {
            MapManager _mapManger = new MapManager();
            _mapManger.Map = new TileMapData.Map(10, 10, new Vector2(16, 16));
        }
        private void LoadControllers()
        {
            new LayerController();
        }
        private void LoadMenuTools()
        {

        }
        private void LoadEditorTools()
        {

        }


    }
}


