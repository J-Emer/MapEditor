
namespace MapEditor.src.Controllers
{
    public abstract class BaseController
    {
        public virtual void Load(){}
        public virtual void ForceRefresh(){}
        protected virtual void HandleUI(){}
    }
}


