using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Contexts;

namespace MapEditor.src.MenuTools
{
    public abstract class BaseMenuTool
    {
        public string Title{get; private set;}

        protected Menu _menu;


        public BaseMenuTool(string _title)
        {
            this.Title = _title;
            MenuToolContext.Instance.Add(this);
            _menu = (Menu)Loader.Instance.Desktop.Controls.Get("MainMenu");
        }

        public virtual void Load()
        {
            _menu.Add_Button(this.Title, this.Title).OnMouseDown += ButtonPress;
        }
        protected virtual void ButtonPress(MouseEventArgs e)
        {

        }
    }
}


