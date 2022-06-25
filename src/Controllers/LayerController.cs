using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

using EditorUI_DX.Controls;

namespace MapEditor.src.Controllers
{
    public class LayerController : BaseController
    {
        private MapManager _manager;
        private TreeView _layerTree;

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<MapManager>();
            _manager.OnManagerStateChanged += HandleUI;

            ScalablePanel _panel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("LeftPanel");
            _layerTree = (TreeView)_panel.Controls.Get("LayerTree");
            _layerTree.OnNodeSelected += LayerSelected;
        }
        public override void ForceRefresh()
        {
            HandleUI();
        }
        protected override void HandleUI()
        {
            _layerTree.Controls.Clear();

            foreach (var item in _manager.Map.Layers)
            {
                TreeNode _node = _layerTree.AddParent(item.LayerName, item.LayerID);
            }
        }
        private void LayerSelected(object sender, TreeNode node)
        {
            System.Console.WriteLine(node.Text);
        }
    }
}


