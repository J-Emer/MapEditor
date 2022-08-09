using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

namespace MapEditor.src.Controllers
{
    public class EntityController : BaseController
    {

        private EntityManager _manager;


        public EntityController(Game _game) : base(_game){}

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<EntityManager>();

            //add entity 
            //remove entity
            //select entity
            //rename entity
            //update entity
        }
    }
}


