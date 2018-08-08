using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.journals;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewjournaldetails.xaml
    /// </summary>
    public partial class viewjournaldetails : UserControl
    {
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public viewjournaldetails()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

        
        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.Journals.ToList();
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
            journal_insert insert = new journal_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Journal).JournalID;
            journal_update updatejournal = new journal_update(id);
            updatejournal.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Journal).JournalID;
            var deleteJournal = dc.Journals.Where(journal => journal.JournalID == id).Single();
            dc.Journals.DeleteOnSubmit(deleteJournal);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.Journals.ToList();
        }
    }
}
