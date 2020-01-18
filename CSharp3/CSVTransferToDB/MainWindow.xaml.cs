using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSVTransferToDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleEntitiesContainer container = new PeopleEntitiesContainer();
        public ObservableCollection<Person> Peoples { get; set; } = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "CSV файлы (*.csv)|*.csv" };
            if (dialog.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        Peoples.Add(new Person { FIO = line[0], Email = line[1], Phone = line[2] });
                    }
                }
            }
        }

        private void btnSendToDB_Click(object sender, RoutedEventArgs e)
        {
            container.People.AddRange(Peoples);
            container.SaveChanges();
        }
    }

    public class PersonVM
    {
        private Person person;

        public Person Person => person;
        public string PersonFIO { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhone { get; set; }

        public PersonVM(Person person)
        {
            this.person = person;
        }
    }
}
