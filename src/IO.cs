using System.IO;

using MapEditor.src.TileMapData;

using Newtonsoft.Json;

namespace MapEditor.src
{
    public static class IO
    {
        public static void SaveMap(Map _map, string _path)
        {
            using(StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(JsonConvert.SerializeObject(_map));
                sw.Close();
            }
        }
        public static Map LoadMap(string _filePath)
        {
            Map _map = null;

            using(StreamReader sr = new StreamReader(_filePath))
            {
                _map = JsonConvert.DeserializeObject<Map>(sr.ReadToEnd());
                sr.Close();
            }

            return _map;
        }
        public static void SavePalette(Palette _palette, string _path)
        {
            using(StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(JsonConvert.SerializeObject(_palette));
                sw.Close();
            }
        }
        public static Palette LoadPaneltte(string _filePath)
        {
            Palette _palette = null;

            using(StreamReader sr = new StreamReader(_filePath))
            {
                _palette = JsonConvert.DeserializeObject<Palette>(sr.ReadToEnd());
                sr.Close();
            }

            return _palette;
        }
    }
}


