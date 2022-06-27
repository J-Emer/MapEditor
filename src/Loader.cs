using System.Collections.Generic;

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

            LoadManages();
            LoadControllers();


            ManagerContext.Instance.LoadAll();
            ManagerContext.Instance.ForceUpdateAll();
            ControllerContext.Instance.LoadAll();
            ControllerContext.Instance.ForceUpdateAll();
        }


        private void LoadManages()
        {

        }
        private void LoadControllers()
        {

        }

    }
}


