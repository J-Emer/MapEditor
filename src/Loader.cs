using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.Controllers;
using MapEditor.src.TileMapData;
using MapEditor.src.EditorTools;
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

        private void Load()
        {
            new ManagerContext();
            new ControllerContext();
            new MenuToolContext();

            LoadManages();
            LoadControllers();
            LoadMenuTools();


            ManagerContext.Instance.LoadAll();
            ManagerContext.Instance.ForceUpdateAll();
            ControllerContext.Instance.LoadAll();
            ControllerContext.Instance.ForceUpdateAll();
            ControllerContext.Instance.HandleUIAll();
            MenuToolContext.Instance.LoadAll();
        }


        private void LoadManages()
        {
            MapManager _mapManager = new MapManager();
            _mapManager.Map = new Map("Map", 0, 0, Vector2.Zero);

            new PaletteManager();
            new LayerManager();
            new EntityManager();
        }
        private void LoadControllers()
        {
            new LayerController(this.Game);
            new PaletteController(this.Game);
            new GridController(this.Game);
            new EditorToolsController(this.Game, new List<EditorTools.BaseEditorTool>()
                                                                                        {
                                                                                            new PaintEditorTool("Paint"),
                                                                                            new PhysicsEditorTool("Physics"),
                                                                                            new FloodFillEditorTool("Fill Layer"),
                                                                                            new LayerFloodClearEditorTool("Clear Layer")
                                                                                        });
            new MapDrawController(this.Game);
            new EntityController(this.Game);
        }
        private void LoadMenuTools()
        {
            new FileMenuTools("File");
            new PaintMenuTool("Paint");
            new PhysicsMenuTool("Physics");
            new FillLayerMenuTool("Fill Layer");
            new ClearLayerMenuTool("Clear Layer");
        }

    }
}


