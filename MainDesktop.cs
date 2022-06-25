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

        }
    }
}


