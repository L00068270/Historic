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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class signup : Page
    {
        //create a new data context
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public signup()
        {
            this.InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            /*
            //UserName Validation   
            if (dc.DatabaseExists()) myDataGrid.ItemsSource = dc.LibraryMembers;
            {
                MessageBox.Show("Invalid UserName");
            }

            else if (tbxPassword.Text.Length <= 6)
            {
                MessageBox.Show("Password length should be minimum of 6 characters!");
            }

            //Address Text Empty Validation   
            else if (tbxAddress.Text == "")
            {
                MessageBox.Show("Please enter your address!");
            }

            //After validation success ,store user detials in isolated storage   
            else if (TxtUserName.Text != "" && TxtPwd.Password != "" && TxtAddr.Text != "" && TxtEmail.Text != "" && gender != "" && TxtPhNo.Text != "")
            {
                UserData ObjUserData = new UserData();
                ObjUserData.UserName = TxtUserName.Text;
                ObjUserData.Password = TxtPwd.Password;
                ObjUserData.Address = TxtAddr.Text;
                ObjUserData.Email = TxtEmail.Text;
                ObjUserData.Gender = gender;
                ObjUserData.PhoneNo = TxtPhNo.Text;
                int Temp = 0;
                foreach (var UserLogin in ObjUserDataList)
                {
                    if (ObjUserData.UserName == UserLogin.UserName)
                    {
                        Temp = 1;
                    }
                }
            
                //Checking existing user names in local DB   
                if (Temp == 0)
                {
                    ObjUserDataList.Add(ObjUserData);
                    if (ISOFile.FileExists("RegistrationDetails"))
                    {
                        ISOFile.DeleteFile("RegistrationDetails");
                    }
                    using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("RegistrationDetails", FileMode.Create))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(List<UserData>));
                        serializer.WriteObject(fileStream, ObjUserDataList);
                    }
                    MessageBox.Show("Congrats! your have successfully Registered.");
                    NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Sorry! user name is already existed.");
                }
            }    
            else    
            {    
                MessageBox.Show("Please enter all details");    
            }
            */  
        }



        ///*******************************************************************************************************************************
        /// Origional Attempt
        /// 
        /// 
        /// 
        ///*******************************************************************************************************************************

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            Boolean useravailable;
            useravailable = functionToCheckUsername(tbxUsername.Text);
            if (useravailable)
            {
                if (tbxPassword.Text == tbxConfirmPassword.Text)
                {
                    String query = "insert into LibraryMember(NameFirst,NameInitial,NameLast,Username,Password,Address,Street,Town,County,Country,Postcode,Classification) values('" + tbxNameFirst.Text + "','" + tbxNameInitials.Text + "','" + tbxNameLast.Text + "','" + tbxUsername.Text + "','" + tbxPassword.Text + "','" + tbxAddress.Text + "','" + tbxStreet.Text + "','" + tbxTown.Text + "','" + tbxCounty.Text + "','" + tbxCountry.Text + "','" + tbxPostcode.Text + "','" + tbxClassification.Text + "')";
                    //String mycon = "Data Source=LibraryConnectionString; Initial Catalog=SignupDatabase; Integrated Security=true";
                    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString);
                    SqlConnection con = new SqlConnection("Data Source=lougheske.database.windows.net;Initial Catalog=library;Persist Security Info=True;User ID=teillo;Password=***********");
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Registration Successful - Thanks For Registration");

                    tbxNameFirst.Text = "";
                    tbxNameInitials.Text = "";
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
        
        public Boolean functionToCheckUsername(String username)
        {
            
            Boolean userstatus;
            //String con = "Data Source = lougheske.database.windows.net; Initial Catalog = library; Persist Security Info = True; User ID = teillo; Password = ***********";
            String myquery = "Select * from LibraryMember where username='" + tbxUsername.Text + "'";
            SqlConnection connectSql = new SqlConnection(ConfigurationManager.ConnectionStrings["datalibrary"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = connectSql;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
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
    }
}
