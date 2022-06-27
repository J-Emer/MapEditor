using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;

using EditorUI_DX.Controls;
using EditorUI_DX.Utils;


namespace MapEditor.src.Controllers
{
    public class LayerController : BaseController
    {

        private LayerManager _layerManager;
        private TreeView _layerTree;

        public LayerController(Game _game) : base(_game){}

        public override void Load()
        {
            _layerManager = ManagerContext.Instance.GetManager<LayerManager>();
            _layerManager.OnManagerStateChanged += HandleUI;
            

            ScalablePanel _leftPanel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("LeftPanel");
            Panel _buttonsPanel = (Panel)_leftPanel.Controls.Get("ButtonsPanel");
            Button _addButton = (Button)_buttonsPanel.Controls.Get("AddLayer");
            _addButton.OnMouseDown += AddLayer;

            Button _removeButton = (Button)_buttonsPanel.Controls.Get("RemoveLayer");
            _removeButton.OnMouseDown += RemoveLayer;

            _layerTree = (TreeView)_leftPanel.Controls.Get("LayerTree");
            _layerTree.OnNodeSelected += SelectLayer;

            _layerManager.SetActiveLayer(0);
        }

        private void AddLayer(MouseEventArgs e)
        {
            _layerManager.NewLayer();
        }
        private void RemoveLayer(MouseEventArgs e)
        {
            if(_layerManager.ActiveLayer == null){return;}

            _layerManager.RemoveLayer(_layerManager.ActiveLayerID);
        }
        private void SelectLayer(object sender, TreeNode node)
        {
            Layer _layer = (Layer)node.Tag;
            _layerManager.SetActiveLayer(_layer.LayerID);
        }
        public override void HandleUI()
        {
            _layerTree.Controls.Clear();

            foreach (var item in _layerManager.Layers)
            {
                _layerTree.AddParent(item.LayerName, item);
            }
        }
    }
}

