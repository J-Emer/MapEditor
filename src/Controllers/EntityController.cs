using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.TileMapData;

namespace MapEditor.src.Controllers
{
    public class EntityController : BaseController
    {

        //treeview
        private TreeView _tree;
            //context menu strip (not added yet)
        //propertygrid
        private PropertyGrid _grid;
        //add button
        private Button _addButton;
        //remove button
        private Button _removeButton;


        private EntityManager _manager;


        public EntityController(Game _game) : base(_game){}

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<EntityManager>();
            _manager.OnManagerStateChanged += HandleUI;
            _manager.OnSelectedEntityChanged += EntityChanged;

            ScalablePanel _rightPanel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("RightPanel");
            Panel _buttonsPanel = (Panel)_rightPanel.Controls.Get("EntityButtonsPanel");

            _tree = (TreeView)_rightPanel.Controls.Get("EntitiesTree");
            _grid = (PropertyGrid)_rightPanel.Controls.Get("EntityPropGrid");
            _grid.OnPropertyValueChanged += PropertyValuesChanged;
            _addButton = (Button)_buttonsPanel.Controls.Get("AddEntityButton");
            _removeButton = (Button)_buttonsPanel.Controls.Get("RemoveEntityButton");

            _tree.OnNodeSelected += NodeSelected;
            _addButton.OnMouseDown += Add;
            _removeButton.OnMouseDown += Remove;


            //add entity 
            //remove entity
            //select entity
            //rename entity
            //update entity
        }
        public override void HandleUI()
        {
            _tree.Controls.Clear();

            foreach (var item in _manager.Entities)
            {
                _tree.AddParent(item.Name, item);
            }

            System.Console.WriteLine(_manager.Entities.Count);
        }
        private void NodeSelected(object sender, TreeNode node)
        {
            _manager.SelectEntity((EntityObject)node.Tag);
        }
        private void Add(MouseEventArgs e)
        {
            _manager.AddEntity();
        }
        private void Remove(MouseEventArgs e)
        {
            _manager.RemoveEntity();
        }
        private void EntityChanged(EntityObject _ent)
        {
            _grid.Select_Object(_ent);
        }
        private void PropertyValuesChanged(object sender, PropertyInfo info)
        {
            HandleUI();
        }
    }
}


