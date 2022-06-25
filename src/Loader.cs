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

        public Desktop Desktop{get; private set;}

        public Loader(Desktop _desktop)
        {
            this.Desktop = _desktop;
            Instance = this;
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
        }

        private void LoadManagers()
        {

        }
        private void LoadControllers()
        {

        }
        private void LoadMenuTools()
        {

        }
        private void LoadEditorTools()
        {

        }


    }
}


