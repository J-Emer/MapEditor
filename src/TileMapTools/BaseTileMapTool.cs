using MapEditor.src.Contexts;
using MapEditor.src.Managers;


namespace MapEditor.src.TileMapTools
{
    public abstract class BaseTileMapTool
    {
        public string Name{get;set;}

        protected MapManager _mapManager;
        protected LayerManager _layerManager;
        protected PaletteManager _paletteManager;

        public BaseTileMapTool(string _name)
        {
            this.Name = _name;
            _mapManager = ManagerContext.Instance.GetManager<MapManager>();
            _layerManager = ManagerContext.Instance.GetManager<LayerManager>();
            _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
        }

        public virtual void OnMouseButtonDown(){}
        public virtual void OnMouseButtonUp(){}


        protected bool IsInMap(int x, int y)
        {
            return x >= 0 && x < _mapManager.Map.TilesWide && y >= 0 && y < _mapManager.Map.TilesHigh;
        }


    }
}


