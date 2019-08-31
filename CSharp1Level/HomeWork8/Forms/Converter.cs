using HomeWork8.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HomeWork8.Forms
{
    public partial class Converter : Form
    {
        public MainForm Main { get; set; }
        List<Student> list = new List<Student>();
        public Converter()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Main.Close();
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void BtnLoadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Все файлы|*.*|XML files|*.XML";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dialog.FileName);
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        //Добавляем в список новый экземляр класса Student
                        Student t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                        list.Add(t);
                        //Одновременно подсчитываем кол-во бакалавров и магистров

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                sr.Close();
            }
            
        }

        private void BtnSaveXML_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Все файлы|*.*|XML files|*.XML";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                    Stream fStream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                    xmlFormat.Serialize(fStream, list);
                    fStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
