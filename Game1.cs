using System;
using System.Windows.Forms;

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

        private bool _hasFocus = true;



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
            Form _mainForm = (Form)Form.FromHandle(this.Window.Handle);
            _mainForm.GotFocus += MainForm_GotFocus;
            _mainForm.LostFocus += MainForm_LostFocus;

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

        private void MainForm_GotFocus(object sender, EventArgs e)
        {
            _hasFocus = true;
        }
        private void MainForm_LostFocus(object sender, EventArgs e)
        {
            _hasFocus = false;
        }
        protected override void Update(GameTime gameTime)
        {
            Time.Update(gameTime);
            MapEditor.src.Input.Update();//---EditorUI_DX has an Input class aswell

            if(Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Exit();
            }

            if(!_hasFocus){return;}            

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
