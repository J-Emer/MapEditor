using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Contexts;

namespace MapEditor.src.MenuTools
{
    public abstract class BaseMenuTool
    {
        public string Title{get;set;}
        
        public BaseMenuTool(string _title)
        {
            this.Title = _title;
            MenuToolContext.Instance.Add(this);
        }
        public virtual void Load()
        {
            Menu _menu = (Menu)Loader.Instance.Desktop.Controls.Get("MainMenu");
            Button _b = _menu.Add_Button(this.Title);
            _b.OnMouseDown += ButtonDown;
        }
        protected virtual void ButtonDown(MouseEventArgs e)
        {

        }
    }
}


