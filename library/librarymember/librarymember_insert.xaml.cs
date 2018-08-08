using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.views;

namespace library.librarymember
{
    /// <summary>
    /// Interaction logic for librarymember_insert.xaml
    /// </summary>
    public partial class librarymember_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public librarymember_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            librarymember_insert functionToAddRowOfDataToDataGrid = new librarymember_insert();
            dc.SubmitChanges();

            LibraryMember newLibraryMemberObject = new LibraryMember()
            {
                MemberID = int.Parse(this.tbxMemberID.Text),
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
                Classification = int.Parse(this.tbxClassification.Text)
            };
            dc.LibraryMembers.InsertOnSubmit(newLibraryMemberObject);
            dc.SubmitChanges();
            viewlibrarymember.datagrid.ItemsSource = dc.LibraryMembers.ToList();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
