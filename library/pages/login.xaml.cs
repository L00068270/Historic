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
using System.Data;
using System.Windows.Navigation;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);


        //*************************************************************************************************
        // global list (_userList) that will contain all the users in the database
        //
        //*************************************************************************************************
        List<LibraryMember> _userList = new List<LibraryMember>();

        public login()
        {
            InitializeComponent();
        }



        //*************************************************************************************************
        // functions here
        //
        //*************************************************************************************************

        private void functionToLoadLibraryMembers()         //Create function that will load records from the 
                                                            //LibraryMember table into the global user list
        {
            _userList.Clear();                              //This clears contents of the _userList
            foreach (var user in dc.LibraryMembers)
            {
                _userList.Add(user);                        //This is add all LibraryMembers to the global userlist
            }
        }



        public LibraryMember functionToGetUserDetails(string username, string password)
        {
            LibraryMember _userDetails = new LibraryMember();   //This is variable called 'userDetails'new initialisea 'userDetails
            foreach (var _user in _userList)                    //Check each user name and password in the global 
                                                                //list (_userList)to see if it matches
            {
                if (username == _user.Username && password == _user.Password)   
                {
                    _userDetails = _user;                       //If there is a match then add the details to the local user account
                }
            }
            return _userDetails;                                //Return the user details
        }

        
        private void functionWindowLoaded(object sender, RoutedEventArgs e)
        {
            functionToLoadLibraryMembers();
            //This updates functionWindowLoaded so it runs the mtdLoadUsers 
            //function once. The application initialises: Pre-load users into the User global listt*/
        }


        //*************************************************************************************************
        // buttons here
        //
        //*************************************************************************************************

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LibraryMember _userDetails = new LibraryMember();
            string currentUser = tbxUsername.Text.Trim();       //To get the username from tbxUsername
            string currentPassword = tbxPassword.Text.Trim();
            _userDetails = functionToGetUserDetails(currentUser, currentPassword);
            if (_userDetails.Classification > 0)                   // if user exists
            {                
                dashboard dashboard = new dashboard();          //create a new instance of the Dashboard window
                //dashboard.Owner = this;
                dashboard.currentUser = _userDetails;
                dashboard.BringIntoView();
                this.Hide();
            }
            else
            {               
                MessageBox.Show("Your user details are invalid");//User does not exist, show message.
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return");
            this.Close();
        }
    }
}
