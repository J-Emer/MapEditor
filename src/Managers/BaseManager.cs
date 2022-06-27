using System;

namespace MapEditor.src.Managers
{
    public abstract class BaseManager
    {
        public abstract event Action OnManagerStateChanged;

        public BaseManager()
        {

        }

        public virtual void ForceUpdate(){}
    }
}


