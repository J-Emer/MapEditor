using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace MapEditor.src.TileMapData
{
    public class Palette
    {
        public List<PaletteItem> Items;

        [JsonConstructor]
        public Palette(List<PaletteItem> items)
        {
            this.Items = items;
        }
        public Palette()
        {
            Items = new List<PaletteItem>();
        }
        public Palette(List<string> files)
        {
            Items = new List<PaletteItem>();

            for (int i = 0; i < files.Count; i++)
            {
                string _name = Path.GetFileNameWithoutExtension(files[i]);
                Items.Add(new PaletteItem(_name, files[i], i));
            }
        }

        public PaletteItem GetPaletteItem(int id)
        {
            return Items.FirstOrDefault(x => x.PaletteID == id);
        }
        
    }
}


