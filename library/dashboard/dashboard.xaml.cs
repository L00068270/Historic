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
using System.Windows.Navigation;
using CRUD_Database.pages.view;
using CRUD_Database.pages.viewmodel;

namespace library.dashboard
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        public LibraryMember currentLibraryMember;

        //new instance of library member. 'LOGIN' refers to this
        public LibraryMember _instanceLibraryMember = new LibraryMember();

        /**************************************************************************************************
         * database framework reference. link to SQL database
         *************************************************************************************************/
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);


        //set the dashboard to load the user details
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblCurrentUser.Content = _instanceLibraryMember.NameFirst;
        }


        public dashboard()
        {
            InitializeComponent();
            DataContext = new viewmodel_books();
        }

        /***************************************************************************************************
         * buttons here for Main Window. This allows for navagating the website.
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

        private void hyperlink_book_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodel_book();           
        }


        /***************************************************************************************************
         * Library Member user buttons here for Main Window. 
         * 
         **************************************************************************************************/

        private void btnSearchText_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnResetSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuilding_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}
