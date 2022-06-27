using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src;

namespace MapEditor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        private MainDesktop _desktop;


        public Color BackgroundColor{get;set;} = new Color(89, 106, 133, 255);





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Window.AllowUserResizing = true;
            Window.Position = new Point(0,0);

            _graphics.PreferredBackBufferWidth = 1900;
            _graphics.PreferredBackBufferHeight = 1060;
            _graphics.ApplyChanges();

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader.Init(this.GraphicsDevice, this.Content);

            _desktop = new MainDesktop(this.GraphicsDevice, this.Content, this.Window, "font");
            new Loader(_desktop, this);

            new Camera(this);
       }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Time.Update(gameTime);
            MapEditor.src.Input.Update();//---EditorUI_DX has an Input class aswell

            Camera.Main.Update(gameTime);

            _desktop.Process();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);

            base.Draw(gameTime);

            _desktop.Render(_spriteBatch);
        }
    }
}
