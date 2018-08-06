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

namespace library.pages
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public register()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            LibraryMember newLibraryMemberObject = new LibraryMember()
            {
                NameFirst = tbxNameFirst.Text,
                NameInitial = tbxNameInitial.Text,
                NameLast = tbxNameLast.Text,
                Username = tbxUsername.Text,
                Password = tbxPassword.Text,
                EnterPassword = tbxEnterPassword.Text,
                Address = tbxAddress.Text,
                Street = tbxStreet.Text,
                Town = tbxTown.Text,
                County = tbxCounty.Text,
                Country = tbxCountry.Text,
                Postcode = tbxPostcode.Text,
            };
            dc.LibraryMembers.InsertOnSubmit(newLibraryMemberObject);
            dc.SubmitChanges();            
            this.Hide();
            MessageBox.Show("Regristration Complete - Thank You");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
