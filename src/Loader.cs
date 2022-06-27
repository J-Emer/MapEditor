using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EditorUI_DX;



namespace MapEditor.src
{
    public class Loader
    {
        public static Loader Instance;

        public MainDesktop Desktop{get; private set;}
        public Game Game{get; private set;}

        public Loader(MainDesktop _desktop, Game _game)
        {
            this.Game = _game;
            this.Desktop = _desktop;
            Instance = this;
        }




    }
}


