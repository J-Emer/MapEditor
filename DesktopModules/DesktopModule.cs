using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.TileMapData;

namespace MapEditor.DesktopModules
{
    public abstract class DesktopModule
    {
        protected Desktop _desktop;

        public DesktopModule(Desktop _desktop)
        {
            this._desktop = _desktop;
        }
        public abstract void Load();
    }
}


