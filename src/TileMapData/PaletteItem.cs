using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class PaletteItem
    {
        [JsonIgnore]
        public Texture2D Texture{get;set;}
        public string TextureName{get;set;}
        public string TexturePath{get;set;}
        public int PaletteID{get;set;}

        public PaletteItem(string TextureName, string TexturePath, int paletteID)
        {
            this.TexturePath = TexturePath;
            this.TextureName = TextureName;
            this.Texture = AssetLoader.LoadTexture(this.TexturePath);
            this.PaletteID = paletteID;
        }
    }
}


