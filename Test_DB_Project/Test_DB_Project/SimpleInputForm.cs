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
            this.Size = new Size(350, 100 + labels.Length * 35);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBoxes = new TextBox[labels.Length];
            Values = new string[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new Point(10, 10 + i * 35),
                    Size = new Size(80, 25)
                };

                textBoxes[i] = new TextBox
                {
                    Location = new Point(100, 10 + i * 35),
                    Size = new Size(200, 25)
                };

                this.Controls.Add(lbl);
                this.Controls.Add(textBoxes[i]);
            }

            btnOk = new Button
            {
                Text = "OK",
                Location = new Point(120, 10 + labels.Length * 35),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnOk.Click += (s, e) => {
                for (int i = 0; i < labels.Length; i++)
                    Values[i] = textBoxes[i].Text;
            };

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(210, 10 + labels.Length * 35),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }
    }
}