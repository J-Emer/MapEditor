using Microsoft.Xna.Framework;


namespace MapEditor.src.TileMapData
{
    public class EntityObject
    {
        public string Name{get;set;} = "Entity";
        public string Tag{get;set;} = "Default";
        public bool IsPhysics{get;set;} = false;
        public int TextureID{get;set;} = 0;
        public Vector2 Position{get;set;} = Vector2.Zero;
    }
}


