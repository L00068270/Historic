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
using library.publisher;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewpublisher.xaml
    /// </summary>
    public partial class viewpublisher : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public viewpublisher()
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
    }
}
