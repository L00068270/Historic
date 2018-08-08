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
    /// Interaction logic for librarymember_update.xaml
    /// </summary>
    public partial class librarymember_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        //*************************************************************************************************        
        // functions here
        //*************************************************************************************************
        private void functionPopulateLibraryMemberDetails(LibraryMember selectedLibraryMember)
        {
            tbxNameFirst.Text = selectedLibraryMember.NameFirst;
            tbxNameInitial.Text = selectedLibraryMember.NameFirst;
            tbxNameLast.Text = selectedLibraryMember.NameLast;
            tbxUsername.Text = selectedLibraryMember.Username;
            tbxPassword.Text = selectedLibraryMember.Password;
            tbxConfirmPassword.Text = selectedLibraryMember.ConfirmPassword;
            tbxAddress.Text = selectedLibraryMember.Address;
            tbxStreet.Text = selectedLibraryMember.Street;
            tbxTown.Text = selectedLibraryMember.Town;
            tbxCounty.Text = selectedLibraryMember.County;
            tbxCountry.Text = selectedLibraryMember.County;
            tbxPostcode.Text = selectedLibraryMember.Postcode;
        }

        public librarymember_update(int librarymemberid)
        {
            InitializeComponent();
            Id = librarymemberid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            LibraryMember updatemember = (from library in dc.LibraryMembers
                                          where library.MemberID == Id
                                          select library).Single();

            updatemember.MemberID = int.Parse(this.tbxMemberID.Text);
            updatemember.NameFirst = tbxNameFirst.Text;
            updatemember.NameInitial = tbxNameInitial.Text;
            updatemember.NameLast = tbxNameLast.Text;
            updatemember.Username = tbxUsername.Text;
            updatemember.Password = tbxPassword.Text;
            updatemember.ConfirmPassword = tbxConfirmPassword.Text;
            updatemember.Address = tbxAddress.Text;
            updatemember.Street = tbxStreet.Text;
            updatemember.Town = tbxTown.Text;
            updatemember.County = tbxCounty.Text;
            updatemember.Country = tbxCountry.Text;
            updatemember.Postcode = tbxPostcode.Text;
            updatemember.Classification = int.Parse(this.tbxMemberID.Text);

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
