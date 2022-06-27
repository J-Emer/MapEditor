using System;
using System.IO;
using System.Windows.Forms;

using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;
using MapEditor.src.TileMapData;
using MapEditor.src.Widgets;

using Newtonsoft.Json;

namespace MapEditor.src.MenuTools
{
    public class FileTools : BaseMenuTool
    { 
        private MapManager _mapManager;

        public FileTools(string _title) : base(_title)
        {

        }
        public override void Load()
        {
            System.Console.WriteLine("file tools load");

            _mapManager = ManagerContext.Instance.GetManager<MapManager>();

            Menu _menu = (Menu)Loader.Instance.Desktop.Controls.Get("MainMenu");
            Drop_Down_Button _fileDropDown = _menu.AddDropDown(this.Title, this.Title);

            //new map
            _fileDropDown.AddButton("New Map", "New_Map").OnMouseDown += NewMap;
            //open map
            _fileDropDown.AddButton("Open Map", "Open_Man").OnMouseDown += OpenMap;
            //save map
            _fileDropDown.AddButton("Save Map", "Save_Map").OnMouseDown += SaveMap;
        }

        private void NewMap(EditorUI_DX.Utils.MouseEventArgs e)
        {
            //open new map dialog
            new NewMapWidget(Loader.Instance.Desktop, "New Map");
        }
        private void OpenMap(EditorUI_DX.Utils.MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            ofd.Multiselect = false;
            ofd.Filter = "json files (*.json)|*.json";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string _path = ofd.FileName;

                using(StreamReader sr = new StreamReader(_path))
                {
                    _mapManager.Map = JsonConvert.DeserializeObject<Map>(sr.ReadToEnd());    
                    sr.Close();
                }
            }
        }
        private void SaveMap(EditorUI_DX.Utils.MouseEventArgs e)
        {
            if(!Directory.Exists( @"C:\Users\jemer\MapEditor"))
            {
                Directory.CreateDirectory( @"C:\Users\jemer\MapEditor");
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\jemer\MapEditor";
            sfd.Filter = "json files (*.json)|*.json";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string _path = sfd.FileName;
            
                using(StreamWriter sw = new StreamWriter(_path))
                {
                    sw.Write(JsonConvert.SerializeObject(_mapManager.Map, Formatting.Indented));
                    sw.Close();
                }
            }
        }
    }
}


