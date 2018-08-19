using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;

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

        int Id;

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
            Journal newJournalObject = new Journal()
            {
                JournalID = int.Parse(this.tbxJournalId.Text),
                Title = tbxTitle.Text,
                ResearchSociety = tbxResearchSociety.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                JournalNumberID = int.Parse(this.tbxJournalNumberID.Text),
                ShelfNumber = tbxShelfNumber.Text,
                Status = tbxStatus.Text,
            };
            dc.Journals.InsertOnSubmit(newJournalObject);
            dc.SubmitChanges();
            viewjournaldetails.datagrid.ItemsSource = dc.Journals.ToList();

            //now clear textboxes after insert
            tbxJournalId.Text = "";
            tbxTitle.Text = "";
            tbxResearchSociety.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxJournalNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxJournalId.Text = "";
            tbxTitle.Text = "";
            tbxResearchSociety.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxJournalNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
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
