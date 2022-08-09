using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.TileMapData;

namespace MapEditor
{
    public class MainDesktop : Desktop
    {

        public MainDesktop(GraphicsDevice _graphics, ContentManager _content, GameWindow _window, string _defaultFontName) : base(_graphics, _content, _window, _defaultFontName)
        {
        }

        public override void Load()
        {
            //----------Main Menu---------------

            Menu _mainMenu = new Menu(this)
            {
                Name = "MainMenu",
                ZOrder = 0,
                Position = Vector2_Int.Zero,
                Size = new Vector2_Int(100,30),
                DockStyle = DockStyle.Top,
            };
            Controls.Add(_mainMenu);



            //----------Left Side Panel---------------

            ScalablePanel _leftPanel = new ScalablePanel(this)
            {
                Name = "LeftPanel",
                Size = new Vector2_Int(300, 300),
                DockStyle = DockStyle.Left,
                Padding = new Padding(10),
                Layout = new Vertical_Stretch_Layout(),
                BorderThickness = 2,
                BorderColor = Color.DarkGray
            };
            Controls.Add(_leftPanel);

            Panel _buttonsPanel = new Panel(this)
            {
                Name = "ButtonsPanel",
                Size = new Vector2_Int(200, 30),
                Padding = new Padding(10),
                Layout = new Horizontal_Layout(),
            };
            _leftPanel.Controls.Add(_buttonsPanel);
            Button _addButton = new Button(this)
            {
                Name = "AddLayer",
                Text = "Add"
            };
            _buttonsPanel.Controls.Add(_addButton);
            Button _removeButton = new Button(this)
            {
                Name = "RemoveLayer",
                Text = "Remove"
            };
            _buttonsPanel.Controls.Add(_removeButton);

            TreeView _treeView = new TreeView(this, this.DefaultFontName)
            {
                Name = "LayerTree",
                Size = new Vector2_Int(300, 300),
                BackgroundColor = new Color(24, 34, 41),
                BorderColor = Color.DarkGray,
                BorderThickness = 1
            };
            _leftPanel.Controls.Add(_treeView);
            _treeView.ContextMenu = new ContextMenu(this, this.DefaultFontName)
            {
                Size = new Vector2_Int(150,120)
            };
            Controls.Add(_treeView.ContextMenu);


            //----------Right Side Panel---------------
            ScalablePanel _rightSidePanel = new ScalablePanel(this)
            {
                Name = "RightPanel",
                Size = new Vector2_Int(300, 300),
                DockStyle = DockStyle.Right,
                Padding = new Padding(10),
                Layout = new Vertical_Stretch_Layout(),
                BorderThickness = 2,
                BorderColor = Color.DarkGray
            };
            Controls.Add(_rightSidePanel);

            TreeView _entitiesTree = new TreeView(this, this.DefaultFontName)
            {
                Name = "EntitiesTree",
                Size = new Vector2_Int(300, 300),
                BackgroundColor = new Color(24, 34, 41),
                BorderColor = Color.DarkGray,
                BorderThickness = 1
            };
            _rightSidePanel.Controls.Add(_entitiesTree);

            _entitiesTree.AddParent("Node");
            _entitiesTree.AddParent("Node");
            _entitiesTree.AddParent("Node");


            Panel _entityButtonsPanel = new Panel(this)
            {
                Name = "EntityButtonsPanel",
                Size = new Vector2_Int(300, 50),
                Layout = new Horizontal_Stretch_Layout(),
                Padding = new Padding(10),
                BorderColor = Color.DarkGray,
                BorderThickness = 1
            };
            _rightSidePanel.Controls.Add(_entityButtonsPanel);

            Button _addEntityButton = new Button(this)
            {
                Name = "AddEntityButton",
                Text = "Add",
            };
            _entityButtonsPanel.Controls.Add(_addEntityButton);

            Button _removeEntityButton = new Button(this)
            {
                Name = "RemoveEntityButton",
                Text = "Remove",
            };
            _entityButtonsPanel.Controls.Add(_removeEntityButton);


            PropertyGrid _grid = new PropertyGrid(this, this.DefaultFontName)
            {
                Name = "EntityPropGrid",
                Size = new Vector2_Int(300, 300),
                BackgroundColor = new Color(24, 34, 41),
                BorderColor = Color.DarkGray,
                BorderThickness = 1
            };
            _rightSidePanel.Controls.Add(_grid);


            //----------Bottom Panel---------------

            ScalablePanel _bottomPanel = new ScalablePanel(this)
            {
                Name = "BottomPanel",
                Size = new Vector2_Int(300, 300),
                DockStyle = DockStyle.Bottom,
                Padding = new Padding(10),
                Layout = new Vertical_Stretch_Layout(),
                BorderThickness = 2,
                BorderColor = Color.DarkGray
            };
            Controls.Add(_bottomPanel);

            ListView _listView = new ListView(this, this.DefaultFontName)
            {
                Name = "PaletteView",
                Size = new Vector2_Int(200, 200),
                Padding = new Padding(15)
            };
            _bottomPanel.Controls.Add(_listView);

        }
    }
}


