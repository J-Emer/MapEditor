using System;
using System.Collections.Generic;

using MapEditor.src.Contexts;
using MapEditor.src.TileMapData;

namespace MapEditor.src.Managers
{
    public class LayerManager : BaseManager
    {
        public override event Action OnManagerStateChanged;
        public event Action OnSelectedLayerChanged;

        private MapManager MapManager
        {
            get
            {
                if(_mapManager == null)
                {
                    _mapManager = ManagerContext.Instance.GetManager<MapManager>();
                }

                return _mapManager;
            }
        }
        private MapManager _mapManager;
    
    
        public List<Layer> Layers
        {
            get
            {
                return MapManager.Map.Layers;
            }
        }
    
    
        public Layer ActiveLayer{get; private set;}
        public int ActiveLayerID{get; private set;}



        public void AddLayer()
        {
            MapManager.Map.AddLayer();
            OnManagerStateChanged?.Invoke();
        }
        public void RemoveLayer(int id)
        {
            MapManager.Map.Layers.Remove(GetLayer(id));

            for (int i = 0; i < MapManager.Map.Layers.Count; i++)
            {
                MapManager.Map.Layers[i].LayerID = i;
            }

            OnManagerStateChanged?.Invoke();
        }
        public Layer GetLayer(int id)
        {
            return MapManager.Map.Layers.Find(x => x.LayerID == id);
        }
        public void RenameLayer(int id, string newName)
        {
            GetLayer(id).LayerName = newName;
        }
        public void SetActiveLayer(int id)
        {
            ActiveLayer = GetLayer(id);
            ActiveLayerID = id;
            OnSelectedLayerChanged?.Invoke();
        }
    }
}


