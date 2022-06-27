using Microsoft.Xna.Framework;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

namespace MapEditor.src.TileMapTools
{
    public abstract class BaseTileMapTool
    {
        public string Name{get;set;}

        protected MapManager _mapManager;
        protected LayerManager _layerManager;
        protected PaletteManager _paletteManager;

        protected int GridX{get; private set;}
        protected int GridY{get; private set;}
        protected bool IsInMap
        {
            get
            {
                return GridX >= 0 && GridX < _mapManager.Map.TilesWide && GridY >= 0 && GridY < _mapManager.Map.TilesHigh;
            }
        }
        protected bool HasTexture
        {
            get
            {
                return _paletteManager.ActivePaletteItem != null;
            }
        }


        public BaseTileMapTool(string _name)
        {
            this.Name = _name;
            _mapManager = ManagerContext.Instance.GetManager<MapManager>();
            _layerManager = ManagerContext.Instance.GetManager<LayerManager>();
            _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
        }

        public virtual void LMBDown(){}
        public virtual void RMBDown(){}

        public virtual void LMBHeld(){}
        public virtual void RMBHeld(){}

        protected void GetGridPos()
        {
            Vector2 _pos = Camera.Main.RoundMouseToNearest((int)_mapManager.Map.TileSize.X);
            GridX = (int)_pos.X;
            GridY = (int)_pos.Y;
        }
        protected Tile GetTile()
        {
            return _layerManager.GetTile(GridX, GridY);
        }

    }
}


