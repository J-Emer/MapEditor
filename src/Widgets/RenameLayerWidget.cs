using System;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using MapEditor.src.Contexts;
using MapEditor.src.Managers;

using MapEditor.src.TileMapData;

namespace MapEditor.src.Widgets
{
    public class RenameLayerWidget : Widget
    {
        private Action<string> CallBack;

        private TextBox _textBox;

        public RenameLayerWidget(Desktop _desktop, string _title, Action<string> _callBack) : base(_desktop, _title)
        {
            this.CallBack = _callBack;

            _textBox = new TextBox(_desktop)
            {
                Size = new Vector2_Int(250, 30),
                Text = "New Name"
            };
            Controls.Add(_textBox);
            _textBox.OnTextSubmitted += TextSubmitted;

            Button _button = new Button(_desktop)
            {
                Size = new Vector2_Int(150, 30),
                Text = "Update"
            };
            Controls.Add(_button);

            _button.OnMouseDown += UpdateName;



            this.Padding = new Padding(15);
            this.Layout = new Vertical_Layout();
            this.Size = new Vector2_Int(300, 150);
            this.Position = new Vector2_Int(500, 500);
        }
        private void TextSubmitted(object sender, string text)
        {
            HandleName();
        }   
        private void UpdateName(MouseEventArgs e)
        {
            HandleName();
        }
        private void HandleName()
        {
            if(_textBox.Text != string.Empty)
            {
                CallBack.Invoke(_textBox.Text);
                this.Close();
            }
        }
    }
}


