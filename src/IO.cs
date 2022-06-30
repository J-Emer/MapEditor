using System.IO;
using System.Windows.Forms;

using MapEditor.src.Managers;
using MapEditor.src.Contexts;
using MapEditor.src.TileMapData;

using Newtonsoft.Json;

namespace MapEditor.src
{
    public static class IO
    {
        public static void SaveMap()
        {
            Map _map = ManagerContext.Instance.GetManager<MapManager>().Map;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            sfd.Filter = "json files (*.json)|*.json";


            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(JsonConvert.SerializeObject(_map, Formatting.Indented));
                    sw.Close();
                }
            }

        }
        public static void LoadMap()
        {

            //check if there is already a palette loaded
            bool _noPalette = ManagerContext.Instance.GetManager<PaletteManager>().Palette.Items.Count == 0;

            if(_noPalette)
            {
                WidgetFactory.MessageBoxWidget("Load Palette before loading Map");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            ofd.Filter = "json files (*.json)|*.json";
            ofd.Multiselect = false;
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Map _map = null;

                using(StreamReader sr = new StreamReader(ofd.FileName))
                {
                    _map = JsonConvert.DeserializeObject<Map>(sr.ReadToEnd());
                    sr.Close();
                }
                
                ManagerContext.Instance.GetManager<MapManager>().Map = _map;
            }

        }
        public static void SavePalette()
        {
            Palette _palette = ManagerContext.Instance.GetManager<PaletteManager>().Palette;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            sfd.Filter = "json files (*.json)|*.json";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(JsonConvert.SerializeObject(_palette, Formatting.Indented));
                    sw.Close();
                }
            }
        }
        public static void LoadPalette()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            ofd.Filter = "json files (*.json)|*.json";
            ofd.Multiselect = false;
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Palette _palette = null;

                using(StreamReader sr = new StreamReader(ofd.FileName))
                {
                    _palette = JsonConvert.DeserializeObject<Palette>(sr.ReadToEnd());
                    sr.Close();
                }

                ManagerContext.Instance.GetManager<PaletteManager>().NewPalette(_palette);
            }

        }
    }
}


