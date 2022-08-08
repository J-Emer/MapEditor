using Microsoft.Xna.Framework;

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

        private PropertyGrid _grid;

        public NewMapWidget(Desktop _desktop, string _title) : base(_desktop, _title)
        {
            _grid = new PropertyGrid(_desktop, _desktop.DefaultFontName)
            {
                Size = new Vector2_Int(300, 300)
            };
            Controls.Add(_grid);
            _grid.Select_Object(new Map());


            Panel _panel = new Panel(_desktop)
            {
                Size = new Vector2_Int(300,50),
                Layout = new Vertical_Layout(),
                Padding = new Padding(10)
            };
            Controls.Add(_panel);

            Button _button = new Button(_desktop)
            {
                Size = new Vector2_Int(150, 30),
                Text = "Generate"
            };
            _panel.Controls.Add(_button);
            _button.OnMouseDown += GenerateMap;


            this.Padding = new Padding(15);
            this.Layout = new Vertical_Stretch_Layout();
            this.Size = new Vector2_Int(400, 500);
            this.Position = new Vector2_Int(500, 500);

        }

        private void GenerateMap(MouseEventArgs e)
        {
            ManagerContext.Instance.GetManager<MapManager>().Map = (Map)_grid.SelectedObject;

            this.Close();
        }
    
    }
}


