using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.src
{
    public class OnScreenLog : DrawableGameComponent
    {
        public static OnScreenLog Instance;

        private Queue<string> _messageQueue = new Queue<string>();


        public Vector2 StartPosition{get; set;} = new Vector2(350,50);
        public float YOffset{get;set;} = 20;
        public Color DrawColor{get;set;} = Color.Black;
        public float QueueClearTimer{get;set;} = 5f;
        private float _timer;


        private SpriteFont Font;

        public OnScreenLog(Game _game) : base(_game)
        {
            _game.Components.Add(this);
            this.Font = AssetLoader.DefaultFont;
            Instance = this;
        }

        public void Log(string _message) => _messageQueue.Enqueue(_message);
        public void Log(object _sender, string _message) => _messageQueue.Enqueue(_sender.GetType().Name + " : " + _message);
        public void Log(object _sender, object _message) => _messageQueue.Enqueue(_sender.GetType().Name + " : " + _message.ToString());





        public override void Update(GameTime gameTime)
        {
            if(_messageQueue.Count > 0)
            {
                _timer += 0.01f;
            }

            if(_timer >= QueueClearTimer)
            {
                _timer = 0;
                _messageQueue.Dequeue();
            }
        }


        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin();

            int i = 0;
            foreach (var item in _messageQueue)
            {
                float yPos = (i * YOffset) + StartPosition.Y;
                Game1._spriteBatch.DrawString(Font, item, new Vector2(StartPosition.X, yPos), DrawColor);
                i+=1;
            }



            Game1._spriteBatch.End();
        }
    }
}


