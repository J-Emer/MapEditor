using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.Controllers;
using MapEditor.src.Shapes;
using MapEditor.src.TileMapTools;
using MapEditor.src.MenuTools;

namespace MapEditor.src
{
    public class Loader
    {
        public static Loader Instance;

        public MainDesktop Desktop{get; private set;}
        public Game Game{get; private set;}

        public Loader(MainDesktop _desktop, Game _game)
        {
            this.Game = _game;
            this.Desktop = _desktop;
            Instance = this;

            Load();
        }

        public void Load()
        {
            new ManagerContext();
            new ControllerContext();
            new MenuToolContext();

            LoadManagers();
            LoadControllers();
            LoadMenuTools();
            LoadEditorTools();

            ManagerContext.Instance.LoadAll();
            ControllerContext.Instance.LoadAll();
            MenuToolContext.Instance.LoadAll();

            ControllerContext.Instance.ForceRefreshAll();
        }

        private void LoadManagers()
        {
            MapManager _mapManger = new MapManager();
            _mapManger.Map = new TileMapData.Map(10, 10, new Vector2(100, 100));


            new LayerManager();
            new PaletteManager();
        }
        private void LoadControllers()
        {
            new LayerController();
            new PaletteController();
        }
        private void LoadMenuTools()
        {
            new FileTools("File");
            new PaintRemoveTool("Paint");
            new PhysicsMenuTool("Physics");
            new FloodFillMenuTool("Flood Fill");
            new FloodClearMenuTool("Flood Clear");
        }
        private void LoadEditorTools()
        {
            new Camera(this.Game);
            new ShapeSystem(this.Game);
            new TileMapDrawer(this.Game);
            new TileMapToolsManager(this.Game, new List<BaseTileMapTool>
                                                                        {
                                                                            new PaintTool("Paint"),
                                                                            new PhysicsTool("Physics"),
                                                                            new FloodFillTool("Flood_Fill"),
                                                                            new FloodClearTool("Flood_Clear")
                                                                        });
        }


    }
}


