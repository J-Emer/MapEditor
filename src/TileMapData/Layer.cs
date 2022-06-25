using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Layer
    {
        public string LayerName{get;set;}
        public int LayerID{get;set;}
        public Vector2 LayerPosition{get;set;}
        public Tile[,] Tiles;

        [JsonConstructor]
        public Layer(string layerName, int layerID, Vector2 layerPosition, Tile[,] tiles)
        {
            this.LayerName = layerName;
            this.LayerID = layerID;
            this.LayerPosition = layerPosition;
            this.Tiles = tiles;
        }
        public Layer(string layerName, int layerID, Vector2 layerPosition, int tilesWide, int tilesHigh)
        {
            this.LayerName = layerName;
            this.LayerID = layerID;
            this.LayerPosition = layerPosition;
            this.Tiles = new Tile[tilesWide, tilesHigh];

            for (int x = 0; x < tilesWide; x++)
            {
                for (int y = 0; y < tilesHigh; y++)
                {
                    Tiles[x,y] = new Tile();
                }
            }
        }

        public Tile GetTile(int x, int y) => Tiles[x,y];
        public override string ToString()
        {
            return $"Layer: {LayerName} | ID: {LayerID} | LayerPosition: {LayerPosition}";
        }
    }
}


