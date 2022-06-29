using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Layer
    {
        public int TilesX{get;set;}
        public int TilesY{get;set;}
        public int LayerID{get;set;}
        public string LayerName{get;set;}
        public Tile[,] Tiles;

        [JsonConstructor]
        public Layer(int tilesX, int tilesY, int layerID, string layerName, Tile[,] tiles)
        {
            this.TilesX = tilesX;
            this.TilesY = tilesY;
            this.LayerID = layerID;
            this.LayerName = layerName;
            this.Tiles = tiles;
        }

        public Layer(int tilesX, int tilesY, int layerID, string layerName)
        {
            this.TilesX = tilesX;
            this.TilesY = tilesY;
            this.LayerID = layerID;
            this.LayerName = layerName;
            this.Tiles = new Tile[tilesX, tilesY];
            
            for (int x = 0; x < tilesX; x++)
            {
                for (int y = 0; y < tilesY; y++)
                {
                    this.Tiles[x,y] = new Tile();
                }
            }
        }

        public override string ToString()
        {
            return $"Layer: Name: {this.LayerName} | ID: {this.LayerID}";
        }
    }
}


