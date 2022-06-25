using MapEditor.src.Contexts;

namespace MapEditor.src.Controllers
{
    public abstract class BaseController
    {
        public BaseController()
        {
            ControllerContext.Instance.Add(this);
        }

        public virtual void Load(){}
        public virtual void ForceRefresh(){}
        protected virtual void HandleUI(){}
    }
}


