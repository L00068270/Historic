using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace library.referencebooks
{
    /// <summary>
    /// Interaction logic for reference_details.xaml
    /// </summary>
    public partial class reference_details : Page
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public reference_details()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.ReferenceBooks.ToList();
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
            reference_insert insert = new reference_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ReferenceBook).RefBookID;
            reference_update updatereferencebook = new reference_update(id);
            updatereferencebook.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ReferenceBook).RefBookID;
            var deleteReferenceBook = dc.ReferenceBooks.Where(reference => reference.RefBookID == id).Single();
            dc.ReferenceBooks.DeleteOnSubmit(deleteReferenceBook);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.ReferenceBooks.ToList();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            pages.dashboard dashboard = new pages.dashboard();
            this.NavigationService.Navigate(dashboard);
        }
    }
}
