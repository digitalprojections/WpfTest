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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string tag = button.Tag.ToString();
            if (button != null)
            {
                int param = int.Parse(tag);
                switch (param)
                {
                    case 1:
                        frame.NavigationService.Navigate(new Uri("Views/FirstPage.xaml", UriKind.Relative));
                        break;
                    case 2:
                        frame.NavigationService.Navigate(new Uri("Views/SecondPage.xaml", UriKind.Relative));
                        break;
                    case 3:
                        frame.NavigationService.Navigate(new Uri("Views/InventoryPage.xaml", UriKind.Relative));
                        break;
                    case 4:
                        frame.NavigationService.Navigate(new Uri("Views/SettingsPage.xaml", UriKind.Relative));
                        break;
                }
            }
        }
    }
}
