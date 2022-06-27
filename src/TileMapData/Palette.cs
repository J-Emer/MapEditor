using System.Collections.Generic;

using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Palette
    {

        public List<PaletteItem> Items{get;set;}

        [JsonConstructor]
        public Palette(List<PaletteItem> items)
        {
            this.Items = items;
        }

        public Palette()
        {
            this.Items = new List<PaletteItem>();
        }
    }
}


