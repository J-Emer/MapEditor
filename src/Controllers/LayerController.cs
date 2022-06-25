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
        private ListView _listView;

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<MapManager>();
            _manager.OnManagerStateChanged += HandleUI;

            ScalablePanel _panel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("BottomPanel");
            _listView = (ListView)_panel.Controls.Get("PaletteView");
            _listView.OnListViewItemSelected += ItemSelected;
        }
        public override void ForceRefresh()
        {
            HandleUI();
        }
        protected override void HandleUI()
        {
            for (int i = 0; i < 10; i++)
            {
                _listView.Add("", Loader.Instance.Desktop.Content.Load<Texture2D>("Color"), null);
            }
        }
        private void ItemSelected(object sender, ListViewItem item)
        {
            System.Console.WriteLine("item selected");
        }
    }
}


