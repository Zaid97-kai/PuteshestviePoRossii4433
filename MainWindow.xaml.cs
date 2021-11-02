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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PuteshestviePoRossii4433
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TESTDBSecondEntities _context = new TESTDBSecondEntities();
        public MainWindow()
        {
            InitializeComponent();
            ListTours.ItemsSource = _context.Tour.OrderBy(tour => tour.Name).ToList();
        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
