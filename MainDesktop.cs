using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

namespace MapEditor
{
    public class MainDesktop : Desktop
    {

        public MainDesktop(GraphicsDevice _graphics, ContentManager _content, GameWindow _window, string _defaultFontName) : base(_graphics, _content, _window, _defaultFontName)
        {
        }

        public override void Load()
        {
            Menu _mainMenu = new Menu(this)
            {
                Name = "MainMenu",
                ZOrder = 0,
                Position = Vector2_Int.Zero,
                Size = new Vector2_Int(100,30),
                DockStyle = DockStyle.Top,
                BorderThickness = 2,
                BorderColor = Color.DarkGray
            };
            Controls.Add(_mainMenu);



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


            for (int i = 0; i < 10; i++)
            {
                _listView.Add("", this.Content.Load<Texture2D>("Color"), null);
            }

        }
    }
}


