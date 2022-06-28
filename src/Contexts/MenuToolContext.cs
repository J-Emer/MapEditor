using System;
using System.Collections.Generic;
using System.Linq;

using MapEditor.src.MenuTools;

namespace MapEditor.src.Contexts
{
    public class MenuToolContext
    {
        private static MenuToolContext _instance;
        public static MenuToolContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MenuToolContext();
                }
                return _instance;
            }
        }

        private List<BaseMenuTool> _tools = new List<BaseMenuTool>();


        public void Add(BaseMenuTool _tool) => _tools.Add(_tool);
        public void Remove(BaseMenuTool _tool) => _tools.Remove(_tool);
        public void LoadAll() => _tools.ForEach(x => x.Load());
        public T GetMenuTool<T>() where T : BaseMenuTool => (T)_tools.FirstOrDefault(x => x.GetType() == typeof(T));
    }
}


