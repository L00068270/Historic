using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.pages;
using System.Windows.Navigation;
using System.Configuration;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public LibraryMember _instanceLibraryMember = new LibraryMember();

        /**************************************************************************************************
         * global list (_libraryMemberList) of records in the database LibraryMember table
         *************************************************************************************************/

        List<LibraryMember> _libraryMemberList = new List<LibraryMember>();

        public login()
        {
            InitializeComponent();
        }

        /**************************************************************************************************
         * 1. functionToLoadLibraryMembers 
         *      - will load the SQL records from the LibraryMember table into the global _libraryMemberList
         *      
         * ***********************************************************************************************/

        //private void mtdLoadUsers()
        private void functionToLoadLibraryMembers()                                                             
        {
            _libraryMemberList.Clear();  
            foreach (var librarymember in dc.LibraryMembers)
            {
                _libraryMemberList.Add(librarymember); 
            }
        }


        /**************************************************************************************************
         * 2. functionWindowLoaded 
         *      - preload librarymembers into the global _libraryMemberList
         *      - it runs the functionToLoadLibraryMembers method once the application initialises
         *      
         *************************************************************************************************/

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        private void functionWindowLoaded(object sender, RoutedEventArgs e)
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            functionToLoadLibraryMembers();
        }


        /**************************************************************************************************
         * 3. functionToGetUserDetails
         *      - authenticate librarymember information
         *      - create a method that will take in the username and password and verify if the 
         *          librarymember exists in our global _libraryMemberList
         *      - initialises '_libraryMemberDetails'
         *      - check each user name and password in the global _libraryMemberList
         *      - if there is a match then add the details to the local librarymember account
         *      - return the user details  
         *          
         *************************************************************************************************/

        //private User mtdGetUserDetails(string username, string password)
        private LibraryMember functionToGetLibraryMemberDetails(string username, string password)
        {
            LibraryMember _libraryMemberDetails = new LibraryMember();
                        
            foreach (var _member in _libraryMemberList)
            {
                if (username == _member.Username && password == _member.Password)   
                {
                    _libraryMemberDetails = _member;
                }
            }
            return _libraryMemberDetails;
        }

        /**************************************************************************************************
        *  buttons here
        * 1. create instance of librarymember class, called _libraryMemberDetails
        * 2. get the username from the tbxUsername and emove unnecessary spaces
        * 3. get the password from the tbxPassword and remove unnecessary spaces
        * 4. run the functionToGetLibraryMemberDetails method with the inputted username and password information 
        *  
        **************************************************************************************************/

        /*
        LibraryMember _libraryMemberDetails = new LibraryMember();
        string currentLibraryMember = tbxUsername.Text.Trim();                  
        string currentPassword = tbxPassword.Text.Trim();
        _libraryMemberDetails = functionToGetLibraryMemberDetails(currentLibraryMember, currentPassword);
        */




        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            pages.register register = new pages.register();
            register.ShowDialog();
            //register is a Window
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            pages.dashboard dashboard = new pages.dashboard();
            //dashboard.ShowDialog();
            //dashboard is a Page
        }
    }
}
