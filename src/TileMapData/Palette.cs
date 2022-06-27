using System.Collections.Generic;

using Newtonsoft.Json;

namespace MapEditor.src.TileMapData
{
    public class Palette
    {
        public string PaletteName{get;set;}
        public List<PaletteItem> Items{get;set;}

        [JsonConstructor]
        public Palette(string paletteName, List<PaletteItem> items)
        {
            this.PaletteName = paletteName;
            this.Items = items;
        }

        public Palette(string paletteName)
        {
            this.PaletteName = paletteName;
            this.Items = new List<PaletteItem>();
        }
    }
}


