using MapEditor.src.TileMapData;
using System;

namespace MapEditor.src.Managers
{
    public class MapManager : BaseManager
    {
        public override event Action OnManagerStateChanged;

        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = value;
                OnManagerStateChanged?.Invoke();
            }
        }
        private Map _map;



        public override void ForceUpdate()
        {
            OnManagerStateChanged?.Invoke();
        }
    }
}


