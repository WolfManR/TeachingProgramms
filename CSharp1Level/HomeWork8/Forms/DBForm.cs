using HomeWork8.Code;
using System;
using System.Windows.Forms;

namespace HomeWork8.Forms
{
    public partial class DBForm : Form
    {
        public MainForm Main { get; set; }
        BelieveOrNotBelieve database;
        public DBForm()
        {
            InitializeComponent();
            BelieveOrNotBelieve.changeName += (s) => tsslFileName.Text = s;
            database = new BelieveOrNotBelieve("data.txt");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Main.Close();
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Main.Show();
            Program.DataBase = database;
            Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Все файлы|*.*|XML files|*.XML";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = dialog.FileName;
                if (dialog.FileName.Length > 60)
                {
                    ttFileName.SetToolTip(statusStrip1, dialog.FileName);
                    tsslFileName.Text = "путь оказался слишком длинным, наведите мышку для отображения пути";
                }
                database.Load();
                nudDBElementIndex.Maximum = database.Count;
                if (nudDBElementIndex.Value > database.Count-1)
                {
                    nudDBElementIndex.Value = 0;
                    tbQuestion.Text = database.List[0].text;
                    chbAnswer.Checked = database.List[0].trueFalse;
                }
                else
                {
                    tbQuestion.Text = database.List[(int)nudDBElementIndex.Value].text;
                    chbAnswer.Checked = database.List[(int)nudDBElementIndex.Value].trueFalse;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Все файлы|*.*|XML files|*.XML";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = dialog.FileName;
                if (dialog.FileName.Length > 60)
                {
                    ttFileName.SetToolTip(statusStrip1, dialog.FileName);
                    tsslFileName.Text = "путь оказался слишком длинным, наведите мышку для отображения пути";
                }
                database.Save();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            database.Add(tbQuestion.Text, chbAnswer.Checked);
            nudDBElementIndex.Maximum = database.Count-1;
            nudDBElementIndex.Value = nudDBElementIndex.Maximum;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Удалить вопрос?", "Удаление", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    database.Remove((int)nudDBElementIndex.Value);
                    nudDBElementIndex.Maximum = database.Count - 1;
                    if ((int)nudDBElementIndex.Value > database.Count - 1) nudDBElementIndex.Value = database.Count - 1;
                    tbQuestion.Text = database[(int)nudDBElementIndex.Value].text;
                    chbAnswer.Checked = database[(int)nudDBElementIndex.Value].trueFalse;
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void NudDBElementIndex_ValueChanged(object sender, EventArgs e)
        {
            if (nudDBElementIndex.Value < database.Count)
            {
                tbQuestion.Text = database.List[(int)nudDBElementIndex.Value].text;
                chbAnswer.Checked = database.List[(int)nudDBElementIndex.Value].trueFalse;
            }
            else 
            {
                nudDBElementIndex.Value = database.Count-1;
                nudDBElementIndex.Maximum = database.Count-1;
            }
        }

        private void ChbAnswer_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)sender).Checked)
            {
                case true:
                    chbAnswer.Text = "да";
                    break;
                case false:
                    chbAnswer.Text = "нет";
                    break;
            }
        }
    }
}
