using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.dvds;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewdvddetails.xaml
    /// </summary>
    public partial class viewdvddetails : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public viewdvddetails()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }
        

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.DVDs.ToList();
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
            dvd_insert insert = new dvd_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as DVD).DVDID;
            dvd_update updatedvd = new dvd_update(id);
            updatedvd.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as DVD).DVDID;
            var deletedvd = dc.DVDs.Where(dvd => dvd.DVDID == id).Single();
            dc.DVDs.DeleteOnSubmit(deletedvd);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.DVDs.ToList();
        }
    }
}
