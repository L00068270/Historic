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
using library.dashboard.viewmodels;

namespace library.dashboard
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        public LibraryMember currentLibraryMember;

        public LibraryMember _LibraryMember = new LibraryMember();

        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);




        public dashboard()
        {
            InitializeComponent();
        }



        /***************************************************************************************************
         * buttons here
         * 
         **************************************************************************************************/

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
        }

        private void btnabout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            pages.register register = new pages.register();
            register.ShowDialog();           
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            pages.login login = new pages.login();
            login.ShowDialog();            
        }

        private void btndashboard_Click(object sender, RoutedEventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.ShowDialog();
        }

        /***************************************************************************************************
         * hyperlinks here
         * 
         **************************************************************************************************/

        private void hyperlink_books_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_books();
        }

        private void hyperlink_journals_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_journals();
        }

        private void hyperlink_dvds_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_dvds();
        }

        private void hyperlink_conferenceproceedings_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_conferenceproceedings();
        }

        private void hyperlink_referencebooks_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_referencebooks();
        }

        private void hyperlink_booksdetails_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_bookdetails();
        }

        private void hyperlink_conferencedetails_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_conferencedetails();
        }

        private void hyperlink_dvddetails_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_dvddetails();
        }

        private void hyperlink_journaldetails_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_journaldetails();
        }

        private void hyperlink_referencebooksdetails_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_referencebookdetails();
        }

        private void hyperlink_librarymember_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_librarymember();
        }

        private void hyperlink_publisher_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_publisher();
        }
    }
}
