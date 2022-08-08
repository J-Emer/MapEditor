using System;
using System.Collections.Generic;
using System.Linq;

using MapEditor.src.TileMapData;
using MapEditor.src.Contexts;

namespace MapEditor.src.Managers
{
    public class LayerManager : BaseManager
    {
        private MapManager _mapManager;


        public override event Action OnManagerStateChanged;
        public event Action OnActiveLayerChanged;



        public List<Layer> Layers
        {
            get
            {
                if(_mapManager == null)
                {
                   _mapManager = ManagerContext.Instance.GetManager<MapManager>();
                   _mapManager.OnManagerStateChanged += this.ForceUpdate;
                }
                return _mapManager.Map.Layers;
            }
        }
        public Layer ActiveLayer{get; private set;}
        public int ActiveLayerID{get; private set;}


        public Layer GetLayer(int id) => Layers.FirstOrDefault(x => x.LayerID == id);
        public void NewLayer()
        {
            int x = _mapManager.Map.TilesX;
            int y = _mapManager.Map.TilesY;
            int index = _mapManager.Map.GetNexLayerID();
            string name = $"Layer {index}";

            _mapManager.Map.Layers.Add(new Layer(x, y, index, name));

            ForceUpdate();
        }
        public void RemoveLayer(int id)
        {
            _mapManager.Map.Layers.Remove(GetLayer(id));

            for (int i = 0; i < _mapManager.Map.Layers.Count; i++)
            {
                _mapManager.Map.Layers[i].LayerID = i;
            }
            ForceUpdate();
        }
        public override void ForceUpdate()
        {
            OnManagerStateChanged?.Invoke();
        }
        public void SetActiveLayer(int id)
        {
            ActiveLayer = GetLayer(id);
            ActiveLayerID = id;

            OnActiveLayerChanged?.Invoke();
        }
        public void DuplicateLayer(int id)
        {
            Layer _oldLayer = GetLayer(id);
            
            int _x = _oldLayer.TilesX;
            int _y = _oldLayer.TilesY;
            int _id = _mapManager.Map.GetNexLayerID();
            string _name = _oldLayer.LayerName + " Copy";

            _mapManager.Map.Layers.Add(new Layer(_x, _y, _id, _name, _oldLayer.Tiles));

            OnManagerStateChanged?.Invoke();
        }
        public void RenameLayer(int id)
        {
            WidgetFactory.RenameLayerWidget(this.HandleRename);
        }
        private void HandleRename(string _newName)
        {
            ActiveLayer.LayerName = _newName;
            OnManagerStateChanged?.Invoke();
        }
        public Tile GetTile(int x, int y) => ActiveLayer.Tiles[x,y];
        public bool IsInMap(int x, int y) => x >= 0 && x < _mapManager.Map.TilesX && y >= 0 && y < _mapManager.Map.TilesY;

    }
}


