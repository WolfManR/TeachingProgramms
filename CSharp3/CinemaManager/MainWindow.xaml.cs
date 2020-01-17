using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CinemaManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess dataAccess = new DataAccess(new CinemaEntitiesContainer());
        public ObservableCollection<FilmShow> Films { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public FilmShow CurrentFilmShow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Films = new ObservableCollection<FilmShow>(dataAccess.GetFilmShows());
            Orders = new ObservableCollection<Order>(dataAccess.GetOrders());
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNewOrder();
                ReloadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddNewOrder()
        {
            if (int.TryParse(tbTicketsCount.Text, out int tickets))
            {
                dataAccess.AddOrder(new Order { SellTime = DateTime.Now, TicketsCount = tickets, FilmShowId = (lvFilmShows.SelectedItem as FilmShow)?.Id ?? throw new Exception("FilmShow not selected") });
            }
        }

        void ReloadFilms()
        {
            Films.Clear();
            dataAccess.GetFilmShows().ToList().ForEach(x => Films.Add(x));
        }
        void ReloadOrders()
        {
            Orders.Clear();
            dataAccess.GetOrders().ToList().ForEach(x => Orders.Add(x));
        }
    }
}
