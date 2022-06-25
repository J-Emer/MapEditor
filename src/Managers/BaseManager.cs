using System;
using MapEditor.src.Contexts;

namespace MapEditor.src.Managers
{
    public abstract class BaseManager
    {
        public abstract event Action OnManagerStateChanged;


        public BaseManager()
        {
            ManagerContext.Instance.Add(this);
        }

        public virtual void Load(){}
        public virtual void ForceUpdate(){}
        
    }
}


