using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Graphics;

using MapEditor.src.TileMapData;

namespace MapEditor.src.Managers
{
    public class PaletteManager : BaseManager
    {
        public override event Action OnManagerStateChanged;

        public Palette Palette
        {
            get
            {
                return _palette;
            }
        }
        private Palette _palette;
        public PaletteItem ActivePaletteItem{get; private set;}


        public override void Load()
        {
            NewPalette();
        }


        public void NewPalette()
        {
            _palette = new Palette();
            ForceUpdate();
        }
        public void NewPalette(List<PaletteItem> items)
        {
            _palette = new Palette(items);
            ForceUpdate();
        }

        public void NewPalette(List<string> filePaths)
        {
            new Palette();

            for (int i = 0; i < filePaths.Count; i++)
            {
                string _name = Path.GetFileNameWithoutExtension(filePaths[i]);
                Texture2D _texture = Texture2D.FromFile(Loader.Instance.Game.GraphicsDevice, filePaths[i]);

                Palette.Items.Add(new PaletteItem(_texture, _name, filePaths[i], i));
            }

            ForceUpdate();
        }
        public PaletteItem GetPaletteItem(int id) => Palette.Items.FirstOrDefault(x => x.TextureID == id);
        public Texture2D GetTexture(int id) => GetPaletteItem(id).Texture;
        public void SetPaletteItem(PaletteItem item)
        {
            this.ActivePaletteItem = item;
        }
        public void SetPaletteItem(int id)
        {
            ActivePaletteItem = Palette.Items.Find(x => x.TextureID == id);
        }
        public override void ForceUpdate()
        {
            OnManagerStateChanged?.Invoke();
        }
    }
}


