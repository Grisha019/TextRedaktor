using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redaktor2.View
{
    public partial class TextView : Form
    {
        public event Action OpenFile;
        public event Action SaveFile;
        public event Action ClearText;

        private TextBox textBox;

        public TextView()
        {
            /*InitializeComponent();*/
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            textBox = new TextBox { Multiline = true, Dock = DockStyle.Fill };
            var openButton = new Button { Text = "Открыть", Dock = DockStyle.Top };
            var saveButton = new Button { Text = "Сохранить", Dock = DockStyle.Top };
            var clearButton = new Button { Text = "Очистить", Dock = DockStyle.Top };

            openButton.Click += (s, e) => OpenFile?.Invoke();
            saveButton.Click += (s, e) => SaveFile?.Invoke();
            clearButton.Click += (s, e) => ClearText?.Invoke();

            Controls.Add(textBox);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(clearButton);
        }

        public string GetText() => textBox.Text;

        public void SetText(string text) => textBox.Text = text;
    }
}
