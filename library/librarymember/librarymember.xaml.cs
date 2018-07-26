using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace library.librarymember
{
    /// <summary>
    /// Interaction logic for librarymember.xaml
    /// </summary>
    public partial class librarymember : Page
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public librarymember()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
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
            librarymember_insert insert = new librarymember_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as LibraryMember).MemberID;
            librarymember_update updatemember = new librarymember_update(id);
            updatemember.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as LibraryMember).MemberID;
            var deleteMember = dc.LibraryMembers.Where(library => library.MemberID == id).Single();
            dc.LibraryMembers.DeleteOnSubmit(deleteMember);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.LibraryMembers.ToList();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            pages.dashboard dashboard = new pages.dashboard();
            this.NavigationService.Navigate(dashboard);
        }

        
    }
}
