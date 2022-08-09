using System.Collections.Generic;

using MapEditor.src.TileMapData;
using MapEditor.src.Contexts;

using System;

namespace MapEditor.src.Managers
{
    public class EntityManager : BaseManager
    {
        public override event Action OnManagerStateChanged;
        public event Action<EntityObject> OnSelectedEntityChanged;
        public EntityObject SelectedEntity{get; private set;}
        private LayerManager _manager;

        public List<EntityObject> Entities
        {
            get
            {
                return _manager.ActiveLayer.Entities;
            }
        }
       
        public EntityManager() : base(){}

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<LayerManager>();
        }
        public override void ForceUpdate()
        {
            OnManagerStateChanged?.Invoke();
        }
        public void AddEntity()
        {
            EntityObject _ent = new EntityObject();
            _ent.Name += Entities.Count.ToString();

            _manager.ActiveLayer.Entities.Add(_ent);
        }
        public void RemoveEntity(EntityObject _ent)
        {
            _manager.ActiveLayer.Entities.Remove(_ent);
            ForceUpdate();
        }
        public void SelectEntity(EntityObject _ent)
        {
            SelectedEntity = _ent;
            OnSelectedEntityChanged?.Invoke(SelectedEntity);
        }

    }
}


