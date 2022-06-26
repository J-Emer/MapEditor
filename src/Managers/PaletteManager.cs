using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Graphics;

using MapEditor.src.TileMapData;

namespace MapEditor.src.Managers
{
    public class PaletteManager : BaseManager
    {
        public override event Action OnManagerStateChanged;
        public Palette Palette{get; private set;}
        public List<PaletteItem> PaletteItems
        {
            get
            {
                return Palette.Items;
            }
        }

        public PaletteManager() : base(){}

        public override void Load()
        {
            this.Palette = new Palette();
        }

        public void NewPalette()
        {
            this.Palette = new Palette();
            OnManagerStateChanged?.Invoke();
        }
        public void NewPalette(List<PaletteItem> _items)
        {
            this.Palette = new Palette(_items);
            OnManagerStateChanged?.Invoke();
        }
        public void NewPalette(List<string> _files)
        {
            this.Palette = new Palette(_files);
            OnManagerStateChanged?.Invoke();
        }

        public PaletteItem GetPaletteItem(int id)
        {
            return Palette.Items.FirstOrDefault(x => x.PaletteID == id);
        }
        public Texture2D GetPaletteTexture(int id)
        {
            return GetPaletteItem(id).Texture;
        }
    }
}


