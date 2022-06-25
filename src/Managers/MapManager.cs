using System;
using System.Linq;

using MapEditor.src.TileMapData;

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


        public MapManager() : base(){}

        public void AddLayer()
        {
            Map.AddLayer();
            OnManagerStateChanged?.Invoke();
        }
        public void RemoveLayer(int id)
        {
            _map.Layers.Remove(GetLayer(id));
            OnManagerStateChanged?.Invoke();
        }
        public Layer GetLayer(int id)
        {
            return _map.Layers.FirstOrDefault(x => x.LayerID == id);
        }
    }
}


