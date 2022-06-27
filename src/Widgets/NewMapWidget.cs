using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

namespace MapEditor.src.Widgets
{
    public class NewMapWidget : Widget
    {
        private Map _map;

        private Button _saveButton;
        private PropertyGrid _grid;

        public NewMapWidget(Desktop _desktop, string _str) : base(_desktop, _str)
        {
            _map = new Map(10, 10, new Vector2(16, 16));

            _grid = new PropertyGrid(_desktop, _desktop.DefaultFontName)
            {
                Size = new Vector2_Int(300,300)
            };
            _grid.Select_Object(_map);

            _saveButton = new Button(_desktop)
            {
                Text = "Generate"
            };

            _saveButton.OnMouseDown += SaveMap;

            this.Controls.Add(_grid);
            this.Controls.Add(_saveButton);

            this.Size = new Vector2_Int(300,400);
            this.Position = new Vector2_Int(600, 400);

            this.Layout = new Vertical_Stretch_Layout();
            this.Padding = new Padding(15);
        }

        private void SaveMap(MouseEventArgs e)
        {
            ManagerContext.Instance.GetManager<MapManager>().Map = this._map;
            this.Close();
        }


    }
}


