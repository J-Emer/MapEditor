
namespace MapEditor.src.TileMapTools
{
    public abstract class BaseTileMapTool
    {
        public string Name{get;set;}

        public BaseTileMapTool(string _name)
        {
            this.Name = _name;
        }

        public virtual void OnMouseButtonDown(){}
        public virtual void OnMouseButtonUp(){}

    }
}


