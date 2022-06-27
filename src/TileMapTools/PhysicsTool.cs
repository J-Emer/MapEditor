
namespace MapEditor.src.TileMapTools
{
    public class PhysicsTool : BaseTileMapTool
    {
        public PhysicsTool(string _name) : base(_name){}

        public override void LMBDown()
        {
            if(IsInMap)
            {
                GetTile().IsPhysics = true;
                System.Console.WriteLine("physics");
            }
        }
        public override void RMBDown()
        {
            if(IsInMap)
            {
                GetTile().IsPhysics = false;
            }
        }
        public override void LMBHeld()
        {
            if(IsInMap)
            {
                GetTile().IsPhysics = true;
            }
        }
        public override void RMBHeld()
        {
            if(IsInMap)
            {
                GetTile().IsPhysics = false;
            }
        }
    }
}


