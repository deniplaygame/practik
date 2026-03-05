using System;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleLibrary
{
    public class SimpleInputForm : Form
    {
        private TextBox[] textBoxes;
        private Button btnOk;
        private Button btnCancel;
        public string[] Values { get; private set; }

        public SimpleInputForm(string title, string[] labels)
        {
            this.Text = title;
            this.Size = new Size(300, 100 + labels.Length * 30);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            textBoxes = new TextBox[labels.Length];
            Values = new string[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new Point(10, 10 + i * 30),
                    Size = new Size(80, 20)
                };

                textBoxes[i] = new TextBox
                {
                    Location = new Point(100, 10 + i * 30),
                    Size = new Size(150, 20)
                };

                this.Controls.Add(lbl);
                this.Controls.Add(textBoxes[i]);
            }

            btnOk = new Button
            {
                Text = "OK",
                Location = new Point(100, 10 + labels.Length * 30),
                Size = new Size(70, 30),
                DialogResult = DialogResult.OK
            };
            btnOk.Click += (s, e) => {
                for (int i = 0; i < labels.Length; i++)
                    Values[i] = textBoxes[i].Text;
            };

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(180, 10 + labels.Length * 30),
                Size = new Size(70, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }
    }
}