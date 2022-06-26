using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Managers;
using MapEditor.src.Contexts;
using MapEditor.src.TileMapData;

namespace MapEditor.src.Controllers
{
    public class PaletteController : BaseController
    {

        private PaletteManager _manager;
        private ListView _listView;

        public override void Load()
        {
            _manager = ManagerContext.Instance.GetManager<PaletteManager>();
            _manager.OnManagerStateChanged += HandleUI;

            ScalablePanel _panel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("BottomPanel");
            _listView = (ListView)_panel.Controls.Get("PaletteView");
            _listView.OnDragDrop += ListViewDragDrop;
            _listView.OnListViewItemSelected += ItemSelected;
        }

        public override void ForceRefresh()
        {
            HandleUI();
        }
        protected override void HandleUI()
        {
            _listView.Controls.Clear();

            foreach (var item in _manager.PaletteItems)
            {
                _listView.Add("", item.Texture, item);
            }
        }
        private void ListViewDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
            
            _manager.NewPalette(files.ToList());
        }
        private void ItemSelected(object sender, ListViewItem item)
        {
            _manager.SetActivePaletteItem((PaletteItem)item.Tag);
        }
    }

    
}


