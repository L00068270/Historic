using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.conference_proceedings;
using library.dashboard.views;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewconferencedetails.xaml
    /// </summary>
    public partial class viewconferencedetails : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public viewconferencedetails()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }
        

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.ConferenceProceedings.ToList();
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
            conference_insert insert = new conference_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ConferenceProceeding).ConfID;
            conference_update updateconference = new conference_update(id);
            updateconference.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ConferenceProceeding).ConfID;
            var deleteConference = dc.ConferenceProceedings.Where(conference => conference.ConfID == id).Single();
            dc.ConferenceProceedings.DeleteOnSubmit(deleteConference);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.ConferenceProceedings.ToList();
        }
    }
}
