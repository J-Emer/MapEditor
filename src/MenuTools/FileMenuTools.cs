using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

namespace MapEditor.src.MenuTools
{
    public class FileMenuTools : BaseMenuTool
    {
        public FileMenuTools(string _title) : base(_title){}

        public override void Load()
        {
            Drop_Down_Button _fileDropDown = _menu.AddDropDown(this.Title, this.Title);

            Button _newMapButton = _fileDropDown.AddButton("New Map");
            Button _saveMapButton = _fileDropDown.AddButton("Save Map");
            Button _loadMapButton = _fileDropDown.AddButton("Load Map");
            Button _savePaletteButton = _fileDropDown.AddButton("Save Palette");
            Button _loadPaletteButton = _fileDropDown.AddButton("Load Palette");


            _newMapButton.OnMouseDown += (MouseEventArgs e) => { WidgetFactory.NewMapWidget(); };
            _saveMapButton.OnMouseDown += (MouseEventArgs e) => { IO.SaveMap(); };
            _loadMapButton.OnMouseDown += (MouseEventArgs e) => { IO.LoadMap(); };
            _savePaletteButton.OnMouseDown += (MouseEventArgs e) => { IO.SavePalette(); };
            _loadPaletteButton.OnMouseDown += (MouseEventArgs e) => { IO.LoadPalette(); };




        }
    }
}


