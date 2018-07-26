using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data;
using MyClassesLibrary;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for old_register.xaml
    /// </summary>
    /// 
    public partial class old_register : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["datalibrary"].ConnectionString);
        SqlConnection cmd = new SqlConnection();
        SqlDataReader dr = null;

        public old_register()
        {
            InitializeComponent();
        }

        ///****************************************************************************************************************************************
        /// function here
        ///
        /// 
        ///****************************************************************************************************************************************
        
        public Boolean functionToCheckUsername(String username)
        {
            Boolean userstatus;
            //String mycon = "Data Source = lougheske.database.windows.net; Initial Catalog = library; Persist Security Info = True; User ID = teillo; Password = ***********";
            String myquery = "Select * from LibraryMember where username='" + tbxUsername.Text + "'";
            SqlConnection connectSql = new SqlConnection(ConfigurationManager.ConnectionStrings["datalibrary"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = connectSql;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet dset = new DataSet();
            da.Fill(dset);
            if (dset.Tables[0].Rows.Count > 0)
            {
                userstatus = false;
            }
            else
            {
                userstatus = true;
            }
            connectSql.Close();
            return userstatus;
        }


        ///****************************************************************************************************************************************
        /// buttons here
        ///
        /// 
        ///****************************************************************************************************************************************
        
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Boolean useravailable;
            useravailable = functionToCheckUsername(tbxUsername.Text);
            if (useravailable)
            {
                if (tbxPassword.Text == tbxConfirmPassword.Text)
                {
                    String query = "insert into LibraryMember(NameFirst,NameInitial,NameLast,Username,Password,Address,Street,Town,County,Country,Postcode,Classification) values('" + tbxNameFirst.Text + "','" + tbxNameInitial.Text + "','" + tbxNameLast.Text + "','" + tbxUsername.Text + "','" + tbxPassword.Text + "','" + tbxAddress.Text + "','" + tbxStreet.Text + "','" + tbxTown.Text + "','" + tbxCounty.Text + "','" + tbxCountry.Text + "','" + tbxPostcode.Text + "','" + tbxClassification.Text + "')";
                    //String mycon = "Data Source=LibraryConnectionString; Initial Catalog=SignupDatabase; Integrated Security=true";
                    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["datalibrary"].ConnectionString);
                    SqlConnection con = new SqlConnection("Data Source=lougheske.database.windows.net;Initial Catalog=library;Persist Security Info=True;User ID=teillo;Password=***********");
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Registration Successful - Thanks For Registration");

                    tbxNameFirst.Text = "";
                    tbxNameInitial.Text = "";
                    tbxNameLast.Text = "";
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
                    tbxAddress.Text = "";
                    tbxStreet.Text = "";
                    tbxTown.Text = "";
                    tbxCounty.Text = "";
                    tbxCountry.Text = "";
                    tbxPostcode.Text = "";
                    tbxClassification.Text = "";
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password Not Matched - ReEnter Password");
                }
            }
            else
            {
                MessageBox.Show("UserName Not Available");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            index homePage = new index();
            this.NavigationService.Navigate(homePage);
        }
    }
}
