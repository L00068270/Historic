using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace library.journals
{
    /// <summary>
    /// Interaction logic for journal_insert.xaml
    /// </summary>
    public partial class journal_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public journal_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            journal_insert functionToAddRowOfDataToDataGrid = new journal_insert();
            dc.SubmitChanges();

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
            journal_details.datagrid.ItemsSource = dc.Journals.ToList();
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
