using System.Collections.Generic;
using System.Linq;

using MapEditor.src.Controllers;

namespace MapEditor.src.Contexts
{
    public class ControllerContext
    {
        private static ControllerContext _instance;
        public static ControllerContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ControllerContext();
                }
                return _instance;
            }
        }


        private List<BaseController> _controllers = new List<BaseController>();




        public void Add(BaseController _controller) => _controllers.Add(_controller);
        public void Remove(BaseController _controller) => _controllers.Remove(_controller);
        public void ForceUpdateAll() => _controllers.ForEach(x => x.ForceUpdate());
        public void LoadAll() => _controllers.ForEach(x => x.Load());
        public void HandleUIAll() => _controllers.ForEach(x => x.HandleUI());

        public T GetController<T>() where T : BaseController => (T)_controllers.FirstOrDefault(x => x.GetType() == typeof(T));

    }
}


