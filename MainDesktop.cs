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
            System.Console.WriteLine("const");
        }

        public override void Load()
        {
            Button _b = new Button(this)
            {
                Position = new Vector2_Int(100,100),
                Size = new Vector2_Int(150, 30),
                Text = "Some Button"
            };
            Controls.Add(_b);

            _b.OnMouseDown += (MouseEventArgs e) =>{System.Console.WriteLine("running");};

            System.Console.WriteLine("loade?");
        }
    }
}


