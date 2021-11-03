using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PuteshestviePoRossii4433.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditHotelInfoWindow.xaml
    /// </summary>
    public partial class EditHotelInfoWindow : Window
    {
        private TESTDBSecondEntities _context;
        private Hotel _hotel;
        private HotelWindow _window;
        public EditHotelInfoWindow(TESTDBSecondEntities context, object o, HotelWindow hotelWindow)
        {
            InitializeComponent();
            _hotel = (o as Button).DataContext as Hotel;
            _context = context;
            _window = hotelWindow;

            CmbNameCountry.ItemsSource = _context.Country.ToList();

            TxtNameHotel.Text = _hotel.Name;
            TxtCountStars.Text = Convert.ToString(_hotel.CountOfStars);
            TxtDescriptionHotel.Text = _hotel.Description;
        }

        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(_hotel.Name, "Хотите удалить отель?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _context.Hotel.Remove(_hotel);
                _context.SaveChanges();

                _window.RefreshHotels();
                this.Close();
            }
        }

        private void BtnUpdateHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            _hotel.Name = TxtNameHotel.Text;
            _hotel.CountOfStars = Convert.ToInt32(TxtCountStars.Text);
            _hotel.Description = TxtDescriptionHotel.Text;
            _hotel.Country = CmbNameCountry.SelectedItem as Country;

            _window.RefreshHotels();
            _context.SaveChanges();
            this.Close();
        }
    }
}
