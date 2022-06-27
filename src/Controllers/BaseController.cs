using Microsoft.Xna.Framework;


namespace MapEditor.src.Controllers
{
    public abstract class BaseController : DrawableGameComponent
    {
        public BaseController(Game _game) : base(_game)
        {
            _game.Components.Add(this);
        }
        public virtual void Load(){}
        public virtual void ForceUpdate(){}
        public virtual void HandleUI(){}

    }
}


