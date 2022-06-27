using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Map
    {
        public int TilesWide{get;set;}
        public int TilesHigh{get;set;}
        public Vector2 TileSize{get;set;}
        public int NextLayerID = -1;
        public List<Layer> Layers;

        [JsonConstructor]
        public Map(int tilesWide, int tilesHigh, Vector2 tileSize, int nextLayerID, List<Layer> layers)
        {
            this.TilesWide = tilesWide;
            this.TilesHigh = tilesHigh;
            this.TileSize = tileSize;
            this.NextLayerID = nextLayerID;
            this.Layers = layers;
        }
        public Map(int tilesWide, int tilesHigh, Vector2 tileSize)
        {
            this.TilesWide = tilesWide;
            this.TilesHigh = tilesHigh;
            this.TileSize = tileSize;
            this.NextLayerID = -1;
            HandleLayerID();
            Layers = new List<Layer>();
            Layers.Add(new Layer($"Layer {NextLayerID}", NextLayerID, Vector2.Zero, this.TilesWide, this.TilesHigh));
        }
        public void AddLayer()
        {
            HandleLayerID();
            Layers.Add(new Layer($"Layer {NextLayerID}", NextLayerID, Vector2.Zero, this.TilesWide, this.TilesHigh));
        }
        private void HandleLayerID()
        {
            this.NextLayerID += 1;
        }
    }
}


