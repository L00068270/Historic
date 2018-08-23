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
         *      - clears contents of _libraryMemberList
         *      - then add all users to global list
         * ***********************************************************************************************/
        public void functionToLoadLibraryMembers()                                                             
        {
            _libraryMemberList.Clear();  
            foreach (var librarymember in dc.LibraryMembers)
            {
                _libraryMemberList.Add(librarymember); 
            }
        }



        /**************************************************************************************************
         * 2. Window_Loaded 
         *      - preload librarymembers into the global _libraryMemberList
         *      - it runs the functionToLoadLibraryMembers method once the application initialises
         *      
         *************************************************************************************************/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            functionToLoadLibraryMembers();
        }



        /**************************************************************************************************
         * 3. functionToGetUserDetails
         *      - authenticate librarymember information
         *      - function that will take in the username and password and verify if the 
         *          librarymember exists in global _libraryMemberList
         *      - initialises '_libraryMemberDetails'
         *      - check each user name and password in the global _libraryMemberList
         *      - if there is a match then add the details to the local librarymember account
         *      - return the library members details  
         *          
         *************************************************************************************************/
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
        * 1. instance of librarymember class, called _libraryMemberDetails
        * 2. gets the username from the tbxUsername and remove unnecessary spaces
        * 3. gets the password from the tbxPassword and remove unnecessary spaces
        * 4. runs 'functionToGetLibraryMemberDetails' method with the inputted username and password information 
        *  
        **************************************************************************************************/
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LibraryMember _libraryMemberDetails = new LibraryMember();
            string currentLibraryMember = tbxUsername.Text.Trim();
            string currentPassword = tbxPassword.Password;

            _libraryMemberDetails = functionToGetLibraryMemberDetails(currentLibraryMember, currentPassword);

            if (_libraryMemberDetails.Classification > 0)
            {
                this.Hide();
                //new Dashboard page
                dashboard.dashboard dashboard = new dashboard.dashboard();
                dashboard.Owner = this;

                //_instanceLibraryMember links user to the Dashboard
                dashboard._instanceLibraryMember = _libraryMemberDetails;  
                dashboard.ShowDialog();
                
            }
            else
            {
                //output message if details are incorrect and clear out boxes
                MessageBox.Show("Your user details are invalid, please try again");
                tbxUsername.Text = "";
                tbxPassword.Password = "";
                tbxUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
