using HomeWorkLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class Task1 : Form,IHWTaskData
    {
        public Task1()
        {
            InitializeComponent();
        }

        public string Title => throw new NotImplementedException();

        public int TaskNumber => throw new NotImplementedException();

        public string ToDo => throw new NotImplementedException();

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
}
