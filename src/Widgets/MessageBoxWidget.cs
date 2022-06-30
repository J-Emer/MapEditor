using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;


namespace MapEditor.src.Widgets
{
    public class MessageBoxWidget : Widget
    {
        public MessageBoxWidget(Desktop _desktop, string _title, string _message) : base(_desktop, _title)
        {
            Label _label = new Label(_desktop)
            {
                Text = _message
            };
            Controls.Add(_label);

            this.Layout = new Stretch_Layout();
            this.Padding = new Padding(10);
            this.Size = new Vector2_Int(400,200);
            this.Position = new Vector2_Int(500,400);
        }
    }
}


