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
using System.IO;

namespace library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new pages.index();
        }

        private void btnIndex(object sender, RoutedEventArgs e)
        {
            Main.Content = new pages.index();
        }

        private void btnAbout(object sender, RoutedEventArgs e)
        {
            Main.Content = new pages.about();
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {
            //this is a window
            pages.register register = new pages.register();
            register.ShowDialog();
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {
            //this is a window
            pages.login login = new pages.login();
            login.ShowDialog();
        }

        private void btnDashboard(object sender, RoutedEventArgs e)
        {
            //this is a window            
            dashboard.dashboard dashboard = new dashboard.dashboard();
            dashboard.ShowDialog();
        }
    }
}
