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

        public viewlibrarymember()
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
    }
}
