
using MapEditor.src.Widgets;

namespace MapEditor.src
{
    public static class WidgetFactory
    {
        public static void NewMapWidget()
        {
            new NewMapWidget(Loader.Instance.Desktop, "New Map");
        }
        public static void MessageBoxWidget(string _message)
        {
            new MessageBoxWidget(Loader.Instance.Desktop, "MessageBox", _message);
        }
        public static void RenameLayerWidget(System.Action<string> CallBack)
        {
            new RenameLayerWidget(Loader.Instance.Desktop, "Rename Layer", CallBack);
        }
    }
}


