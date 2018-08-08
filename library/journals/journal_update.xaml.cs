using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.views;

namespace library.journals
{
    /// <summary>
    /// Interaction logic for journal_update.xaml
    /// </summary>
    public partial class journal_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public journal_update(int journalid)
        {
            InitializeComponent();
            Id = journalid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Journal _updatejournal = (from journal in dc.Journals
                                where journal.JournalID == Id
                                select journal).Single();

            _updatejournal.JournalID = int.Parse(this.tbxJournalId.Text);
            _updatejournal.Title = tbxTitle.Text;
            _updatejournal.ResearchSociety = tbxResearchSociety.Text;
            _updatejournal.CopiesTotal = int.Parse(tbxCopiesTotal.Text);
            _updatejournal.CopiesAvailable = int.Parse(tbxCopiesAvailable.Text);
            _updatejournal.CopiesOut = int.Parse(tbxCopiesOut.Text);
            _updatejournal.SubjectArea = tbxSubjectArea.Text;
            _updatejournal.YearOfPublication = tbxYearOfPublication.Text;
            _updatejournal.Keyword = tbxKeyword.Text;
            _updatejournal.JournalNumberID = int.Parse(tbxJournalNumberID.Text);
            _updatejournal.Status = tbxStatus.Text;

            dc.SubmitChanges();
            viewjournaldetails.datagrid.ItemsSource = dc.Journals.ToList();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
