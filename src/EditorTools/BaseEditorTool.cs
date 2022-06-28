using MapEditor.src.Contexts;
using MapEditor.src.Managers;

using MapEditor.src.TileMapData;

namespace MapEditor.src.EditorTools
{
    public abstract class BaseEditorTool
    {
        public string Title{get; private set;}
        protected MapManager _mapManager;
        protected PaletteManager _paletteManager;
        protected LayerManager _layerManager;


        protected int GridX
        {
            get
            {
                return (int)Camera.Main.RoundMouseToNearest((int)_mapManager.Map.TileSize.X).X;
            }
        }
        protected int GridY
        {
            get
            {
                return (int)Camera.Main.RoundMouseToNearest((int)_mapManager.Map.TileSize.X).Y;
            }
        }
        protected bool IsInMap
        {
            get
            {
                return GridX >= 0 && GridX < _mapManager.Map.TilesX && GridY >= 0 && GridY < _mapManager.Map.TilesY;
            }
        }
        protected Tile ActiveTile
        {
            get
            {
                return _layerManager.ActiveLayer.Tiles[GridX, GridY];
            }
        }
        protected Layer GetActiveLayer
        {
            get
            {
                return _layerManager.ActiveLayer;
            }
        }
        protected int ActiveTextureID
        {
            get
            {
                return _paletteManager.ActivePaletteItem.TextureID;
            }
        }


        public BaseEditorTool(string _title)
        {
            this.Title = _title;
            _mapManager = ManagerContext.Instance.GetManager<MapManager>();
            _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
            _layerManager = ManagerContext.Instance.GetManager<LayerManager>();
        }

        public virtual void LMBDown(){}
        public virtual void RMBDown(){}







    }
}


