using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapEditor.src
{
    public class Camera : DrawableGameComponent
    {
        public static Camera Main;
        public Matrix TransformMatrix{get; internal set;}
        public Vector2 Position{get;set;} = Vector2.Zero;
        public float Rotation{get;set;} = 0f;
        public float Zoom { get; set; } = 1f;
        public float MaxZoom { get; set; } = 3f;
        public float MinZoom {get; set;} = 0.1f;
        public float Movespeed{get;set;} = 5;
        public float ZoomRate{get;set;} = 0.1f;
        
        private GraphicsDevice Graphics;
        private Vector2 ViewPortSize
        {
            get
            {
                return new Vector2(Graphics.Viewport.Width, Graphics.Viewport.Height);
            }
        }
        
        public Camera(Game _game) : base(_game)
        {
            _game.Components.Add(this);
            this.Graphics = _game.GraphicsDevice;
            Main = this;
        }

        public override void Update(GameTime gameTime)
        {
            Zoom = MathHelper.Clamp(Zoom, MinZoom, MaxZoom);

            TransformMatrix = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0f)) *
               Matrix.CreateRotationZ(Rotation) *
               Matrix.CreateScale(Zoom) * //----found in a youtube comment -> this is important -> allows for screentoworld and worldtoscreen below? 
               Matrix.CreateTranslation(new Vector3(ViewPortSize.X / 2f, ViewPortSize.Y / 2f, 0f));
        }

        private void Move()
        {
            float x = Input.xAxis * Time.DeltaTime;
            float y = Input.yAxis * Time.DeltaTime;
            Position += new Vector2(x,y) * Movespeed;
        }
        private void Scroll()
        {
            Zoom += Input.ScrollWheel() * ZoomRate;
        }
        /// original code: https://manbeardgames.com/tutorials/2d-camera/
        public Vector2 ScreenToWorld(Vector2 position)
        {
            return Vector2.Transform(position, Matrix.Invert(TransformMatrix));
        }

        /// original code: https://manbeardgames.com/tutorials/2d-camera/
        public Vector2 WorldToScreen(Vector2 position)
        {
            return Vector2.Transform(position, TransformMatrix);
        }
    }
}


