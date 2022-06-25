using System;
using System.Collections.Generic;
using System.Linq;

using MapEditor.src.Managers;

namespace MapEditor.src.Contexts
{
    public class ManagerContext
    {
        public static ManagerContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ManagerContext();
                }
                return _instance;
            }
        }
        private static ManagerContext _instance;
    
    
        private List<BaseManager> _managers = new List<BaseManager>();


        public void Add(BaseManager _manager) => _managers.Add(_manager);
        public void Remove(BaseManager _manager) => _managers.Remove(_manager);
        public void LoadAll() => _managers.ForEach(x => x.Load());
        public void ForceUpdateAll() => _managers.ForEach(x => x.ForceUpdate());
        public T GetManager<T>() where T : BaseManager => (T)_managers.FirstOrDefault(x => x.GetType() == typeof(T));

    
    
    }
}


