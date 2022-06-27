using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Map
    {
        public string MapName{get;set;}
        public int TilesX{get;set;}
        public int TilesY{get;set;}
        public int NextLayerID{get;set;} = -1;
        public Vector2 TileSize{get;set;}
        public List<Layer> Layers;



        [JsonConstructor]
        public Map(string mapName, int tilesX, int tilesY, int nextLayerID, Vector2 tileSize, List<Layer> layers)
        {
            this.MapName = mapName;
            this.TilesX = tilesX;
            this.TilesY = tilesY;
            this.NextLayerID = nextLayerID;
            this.TileSize = tileSize;
            this.Layers = layers;
        }

        public Map(string mapName, int tilesX, int tilesY, int nextLayerID, Vector2 tileSize)
        {
            this.MapName = mapName;
            this.TilesX = tilesX;
            this.TilesY = tilesY;
            this.NextLayerID = nextLayerID;
            this.TileSize = tileSize;
            
            this.Layers = new List<Layer>();

            this.Layers.Add(new Layer(this.TilesX, this.TilesY, GetNexLayerID(), $"Layer {NextLayerID}"));
        }

        private int GetNexLayerID()
        {
            this.NextLayerID += 1;
            return this.NextLayerID;
        }
    }
}


