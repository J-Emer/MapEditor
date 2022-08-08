using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MapEditor.src
{
    public static class AssetLoader
    {
        private static GraphicsDevice graphics;
        private static ContentManager content;


        public static SpriteFont DefaultFont{get; private set;}


        public static void Init(GraphicsDevice _graphics, ContentManager _content)
        {
            graphics = _graphics;
            content = _content;
            DefaultFont = content.Load<SpriteFont>("font");
        }


        public static Texture2D LoadTexture(string _path) => Texture2D.FromFile(graphics, _path);
    }
}


