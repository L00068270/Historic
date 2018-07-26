using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MyClassesLibrary;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for old_login.xaml
    /// </summary>
    public partial class old_login : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["datalibrary"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public old_login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            index index = new index();
            this.NavigationService.Navigate(index);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        ///*******************************************************************************************************************************
        /// Attempt 4 - this work with aspx
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************

        private void btnLogin4_Click(object sender, RoutedEventArgs e)
        {
            
            cmd = new SqlCommand("SELECT Password from LibraryMember where Username='" + tbxUsername.Text + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            bool flag = false;
            while (dr.Read())
            {
                if (dr[0].Equals(tbxPassword.Text))
                {
                    //Session["username"] = tbxUsername.Text;
                    MessageBox.Show("You Have Successfully Logged In"); 
                    //Response.Redirect(@"C:\C# Website\Library\library\library\pages\dashboard.xaml");
                    flag = true;
                }
            }
            if (!false)
            {
                MessageBox.Show("Username or Password is Incorrect, Try Again");
            }
            con.Close();            
        }










        ///*******************************************************************************************************************************
        /// Origional Attempt
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************
        ///
        /*
        List<LibraryMember> _userList = new List<LibraryMember>();

        private void functionToLoadLibraryMembers()
        {
            _userList.Clear();
            foreach (var user in databaseConnection.LibraryMembers)
            {
                _userList.Add(user);
            }
        }

        public LibraryMember functionToGetUserDetails(string username, string password)
        {
            LibraryMember _userDetails = new LibraryMember();
   
            foreach (var _user in _userList)
            {
                if (username == _user.Username && password == _user.Password)
                {
                    _userDetails = _user;
                }
            }
            return _userDetails;
        }
        */


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*
            LibraryMember _userDetails = new LibraryMember();

            string currentUser = tbxUsername.Text.Trim();
            string currentPassword = tbxPassword.Text.Trim();

            _userDetails = functionToGetUserDetails(currentUser, currentPassword);

            if (_userDetails.Classification > 0)
            {
                MessageBox.Show("Username & Password are correct, Welcome.");
                dashboard instanceOfDashboard = new dashboard();
                instanceOfDashboard.DataContext = this;
                instanceOfDashboard.currentUser = _userDetails;
                //dashboard dashboard = new dashboard();
                this.NavigationService.Navigate(instanceOfDashboard);
                //instanceOfDashboard.ShowDialog();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect, please try again");
            }
            */
        }


        ///*******************************************************************************************************************************
        /// Attempt 2 - not working
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************

        
        //SqlConnection con = new SqlConnection(@"Data Source=lougheske.database.windows.net;Initial Catalog=library;Persist Security Info=True;User ID=teillo;Password=***********");

        private void btnLogin2_Click(object sender, RoutedEventArgs e)
        {
            /*
            string check = "select count (*) from [LibraryMember] where Username = '" + tbxUsername.Text + "', Password = '" + tbxPassword.Text + "' ";
            SqlCommand com = new SqlCommand(check, con);
            con.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if(temp > 0)
            {
                dashboard dash = new dashboard();
                this.NavigationService.Navigate(dash);
            }
            else
            {
                MessageBox.Show("Your Username or Password is incorrect, Please try again");
            }
            */
        }
        

        ///*******************************************************************************************************************************
        /// Attempt 3 - not working
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************


        SqlConnection sqlCon = new SqlConnection(@"Data Source=lougheske.database.windows.net;Initial Catalog=library;Persist Security Info=True;User ID=teillo;Password=***********");


        private void btnLogin3_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                //check if sql connection is open or not
                //if closed open
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                //declare database query here
                String query = "SELECT COUNT(1) FROM tbxUsername WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", tbxUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", tbxPassword.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    index index = new index();
                    this.NavigationService.Navigate(index);
                }
            }
            catch (Exception ex)
            {
                //show error (exception) message using message box
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            } 
            */          
        }


        



        ///*******************************************************************************************************************************
        /// Attempt 4 - this work with aspx
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************


        private void btnLogin5_Click(object sender, RoutedEventArgs e)
        {
            

        }
        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(@"C:\C# Website\Library\library\library\pages\dashboard.xaml", UriKind.Relative));

        }



        ///*******************************************************************************************************************************
        /// Attempt 4 - this work with aspx
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************
        private void btnLogin6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin7_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
