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
        private List<Tour> _tours = new List<Tour>();
        private string _SelectedType;
        private string _FindedName;
        public MainWindow()
        {
            InitializeComponent();
            ListTours.ItemsSource = _context.Tour.OrderBy(tour => tour.Name).ToList();

            List<Type> types = new List<Type>();
            types.Add(new Type() { Name = "Все типы" });
            types.AddRange(_context.Type.OrderBy(t => t.Name).ToList());

            CmbType.ItemsSource = types;

            this._tours = _context.Tour.ToList();
        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _FindedName = TxtFindedTourName.Text;

            _tours = _context.Tour.OrderBy(t => t.Name).ToList();

            RefreshTours();
        }

        private void RefreshTours()
        {
            if (CmbType.SelectedItem != null)
            {
                if ((CmbType.SelectedItem as Type).Name != "Все типы")
                {
                    Type type = CmbType.SelectedItem as Type;
                    _SelectedType = type.Name;
                    _tours = (from t in _tours
                              from tn in t.Type
                              where tn.Name == _SelectedType
                              select t).ToList();
                }
                else if ((CmbType.SelectedItem as Type).Name == "Все типы")
                {
                    _tours = _context.Tour.OrderBy(t => t.Name).ToList();
                }
            }

            if (TxtFindedTourName.Text != "")
            {
                _tours = _tours.OrderBy(t => t.Name).Where(t => t.Name.ToLower().Contains(_FindedName)).ToList();
            }

            if ((bool)ChbActual.IsChecked)
            {
                _tours = _tours.OrderBy(t => t.Name).Where(t => t.IsActual == true).ToList();
            }

            ListTours.ItemsSource = _tours;
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tours = _context.Tour.OrderBy(t => t.Name).ToList();

            RefreshTours();
        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {
            _tours = _context.Tour.OrderBy(t => t.Name).ToList();
            RefreshTours();
        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {
            _tours = _context.Tour.OrderBy(t => t.Name).ToList();
            RefreshTours();
        }
    }
}
