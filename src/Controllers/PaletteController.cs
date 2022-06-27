using Microsoft.Xna.Framework;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

using EditorUI_DX.Controls;

namespace MapEditor.src.Controllers
{
    public class PaletteController : BaseController
    {

        private PaletteManager _paletteManager;
        private ListView _listView;

        public PaletteController(Game _game) : base(_game){}

        public override void Load()
        {
            _paletteManager = ManagerContext.Instance.GetManager<PaletteManager>();
            _paletteManager.OnManagerStateChanged += HandleUI;

            ScalablePanel _panel = (ScalablePanel)Loader.Instance.Desktop.Controls.Get("BottomPanel");
            _listView = (ListView)_panel.Controls.Get("PaletteView");
            _listView.OnListViewItemSelected += ItemSelected;
            _listView.OnDragDrop += DragDrop;
        }
        public override void HandleUI()
        {
            _listView.Controls.Clear();

            foreach (var item in _paletteManager.Palette.Items)
            {
                _listView.Add("", item.Texture, item.TextureID);
            }
        }
        private void ItemSelected(object sender, ListViewItem item)
        {
            _paletteManager.SetPaletteItem((int)item.Tag);
        }   
        private void DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
        }
    }
}


