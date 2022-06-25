using System;
using System.Collections.Generic;
using System.Linq;

using MapEditor.src.Controllers;

namespace MapEditor.src.Contexts
{
    public class ControllerContext
    {
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
        private static ControllerContext _instance;
    
    
        private List<BaseController> _controllers = new List<BaseController>();


        public void Add(BaseController _controller) => _controllers.Add(_controller);
        public void Remove(BaseController _controller) => _controllers.Remove(_controller);
        public void LoadAll() => _controllers.ForEach(x => x.Load());
        public void ForceRefreshAll() => _controllers.ForEach(x => x.ForceRefresh());
        public T GetController<T>() where T : BaseController => (T)_controllers.FirstOrDefault(x => x.GetType() == typeof(T));
    }
}


