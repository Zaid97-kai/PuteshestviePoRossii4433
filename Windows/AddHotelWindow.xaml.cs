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
    /// Логика взаимодействия для AddHotelWindow.xaml
    /// </summary>
    public partial class AddHotelWindow : Window
    {
        private TESTDBSecondEntities _context;
        private HotelWindow _window;
        public AddHotelWindow(TESTDBSecondEntities tESTDBSecondEntities, HotelWindow hotelWindow)
        {
            InitializeComponent();
            this._context = tESTDBSecondEntities;
            this._window = hotelWindow;

            CmbNameCountry.ItemsSource = _context.Country.ToList();
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            _context.Hotel.Add(new Hotel()
            {
                Name = TxtNameHotel.Text,
                CountOfStars = Convert.ToInt32(TxtCountStars.Text),
                Description = TxtDescriptionHotel.Text,
                Country = CmbNameCountry.SelectedItem as Country
            });
            _context.SaveChanges();
            _window.RefreshHotels();

            this.Close();
        }
    }
}
