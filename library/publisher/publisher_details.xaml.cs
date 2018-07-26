using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace library.publisher
{
    /// <summary>
    /// Interaction logic for publisher_details.xaml
    /// </summary>
    public partial class publisher_details : Page
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public publisher_details()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.Publishers.ToList();
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
            publisher_insert insert = new publisher_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Publisher).PublisherID;
            publisher_update updatemember = new publisher_update(id);
            updatemember.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Publisher).PublisherID;
            var deletePublisher = dc.Publishers.Where(publisher => publisher.PublisherID == id).Single();
            dc.Publishers.DeleteOnSubmit(deletePublisher);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.Publishers.ToList();
        }

        

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            pages.dashboard dashboard = new pages.dashboard();
            this.NavigationService.Navigate(dashboard);
        }        
    }
}
