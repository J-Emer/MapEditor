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
        public int TextureID{get;set;}


        [JsonConstructor]
        public PaletteItem(string textureName, string texturePath, int textureID)//--in game we dont care about this PaletteItems texture....game can handle that itself
        {
            this.TextureName = textureName;
            this.TexturePath = texturePath;
            this.TextureID = textureID;
        }


        public PaletteItem(Texture2D texture, string textureName, string texturePath, int textureID)//---in editor we do care about the texture
        {
            this.Texture = texture;
            this.TextureName = textureName;
            this.TexturePath = texturePath;
            this.TextureID = textureID;
        }
    }
}


