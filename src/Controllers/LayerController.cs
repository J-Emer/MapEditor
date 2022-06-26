using MapEditor.src.Contexts;
using MapEditor.src.Managers;

using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.TileMapData;

namespace MapEditor.src.Controllers
{
    public class LayerController : BaseController
    {
        private LayerManager _manager;
        private TreeView _layerTree;
        private Button _addButton;
        private Button _removeButton;



        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<LayerManager>();
            _manager.OnManagerStateChanged += HandleUI;

            ScalablePanel _scalablePanel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("LeftPanel");
            
            _layerTree = (TreeView)_scalablePanel.Controls.Get("LayerTree");
            _layerTree.OnNodeSelected += LayerSelected;

            Panel _panel = (Panel)_scalablePanel.Controls.Get("ButtonsPanel");
            _addButton = (Button)_panel.Controls.Get("AddLayer");
            _removeButton = (Button)_panel.Controls.Get("RemoveLayer");

            _addButton.OnMouseDown += AddLayer;
            _removeButton.OnMouseDown += RemoveLayer;

        }
        public override void ForceRefresh()
        {
            HandleUI();
        }
        protected override void HandleUI()
        {
            _layerTree.Controls.Clear();

            foreach (var item in _manager.Layers)
            {
                TreeNode _node = _layerTree.AddParent(item.LayerName, item.LayerID);
            }
        }
        private void AddLayer(MouseEventArgs e)
        {
            _manager.AddLayer();
        }
        private void RemoveLayer(MouseEventArgs e)
        {
            if(_manager.ActiveLayer == null){return;}

            _manager.RemoveLayer(_manager.ActiveLayerID);
        }
        private void LayerSelected(object sender, TreeNode node)
        {
            _manager.SetActiveLayer((int)node.Tag);
        }
    }
}


