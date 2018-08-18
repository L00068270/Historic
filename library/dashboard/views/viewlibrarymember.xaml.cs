using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.librarymember;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewlibrarymember.xaml
    /// </summary>
    public partial class viewlibrarymember : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public viewlibrarymember()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

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

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        private void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.LibraryMembers.ToList();
            datagrid = myDataGrid;
        }


        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            LibraryMember newLibraryMemberObject = new LibraryMember()
            {
                MemberID = int.Parse(this.tbxMemberID.Text),
                NameFirst = tbxNameFirst.Text,
                NameInitial = tbxNameInitial.Text,
                NameLast = tbxNameLast.Text,
                Username = tbxUsername.Text,
                Password = tbxPassword.Text,
                ConfirmPassword = tbxConfirmPassword.Text,
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

            //now clear textboxes after insert
            tbxMemberID.Text = "";
            tbxNameFirst.Text = "";
            tbxNameInitial.Text = "";
            tbxNameLast.Text = "";
            tbxUsername.Text = "";
            tbxPassword.Text = "";
            tbxConfirmPassword.Text = "";
            tbxAddress.Text = "";
            tbxStreet.Text = "";
            tbxTown.Text = "";
            tbxCounty.Text = "";
            tbxCountry.Text = "";
            tbxPostcode.Text = "";
            tbxClassification.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            //LibraryMember updatemember = (from library in dc.LibraryMembers
            //                              where library.MemberID == Id
            //                              select library).Single();

            //updatemember.MemberID = int.Parse(this.tbxMemberID.Text);
            //updatemember.NameFirst = tbxNameFirst.Text;
            //updatemember.NameInitial = tbxNameInitial.Text;
            //updatemember.NameLast = tbxNameLast.Text;
            //updatemember.Username = tbxUsername.Text;
            //updatemember.Password = tbxPassword.Text;
            //updatemember.ConfirmPassword = tbxConfirmPassword.Text;
            //updatemember.Address = tbxAddress.Text;
            //updatemember.Street = tbxStreet.Text;
            //updatemember.Town = tbxTown.Text;
            //updatemember.County = tbxCounty.Text;
            //updatemember.Country = tbxCountry.Text;
            //updatemember.Postcode = tbxPostcode.Text;
            //updatemember.Classification = int.Parse(this.tbxMemberID.Text);

            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxMemberID.Text = "";
            tbxNameFirst.Text = "";
            tbxNameInitial.Text = "";
            tbxNameLast.Text = "";
            tbxUsername.Text = "";
            tbxPassword.Text = "";
            tbxConfirmPassword.Text = "";
            tbxAddress.Text = "";
            tbxStreet.Text = "";
            tbxTown.Text = "";
            tbxCounty.Text = "";
            tbxCountry.Text = "";
            tbxPostcode.Text = "";
            tbxClassification.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as LibraryMember).MemberID;
            var deleteMember = dc.LibraryMembers.Where(library => library.MemberID == id).Single();
            dc.LibraryMembers.DeleteOnSubmit(deleteMember);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.LibraryMembers.ToList();
        }
    }
}
