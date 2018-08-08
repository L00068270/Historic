using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.views;

namespace library.conference_proceedings
{
    /// <summary>
    /// Interaction logic for conference_update.xaml
    /// </summary>
    public partial class conference_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public conference_update(int conferenceproceedingid)
        {
            InitializeComponent();
            Id = conferenceproceedingid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ConferenceProceeding _updateconferenceproceeding = (from conferenceproceeding in dc.ConferenceProceedings
                                      where conferenceproceeding.ConfID == Id
                                      select conferenceproceeding).Single();

            _updateconferenceproceeding.ConfID = int.Parse(this.tbxConfID.Text);
            _updateconferenceproceeding.Title = tbxTitle.Text;
            _updateconferenceproceeding.Author = tbxAuthor.Text;
            _updateconferenceproceeding.CopiesTotal = int.Parse(tbxCopiesTotal.Text);
            _updateconferenceproceeding.CopiesAvailable = int.Parse(tbxCopiesAvailable.Text);
            _updateconferenceproceeding.CopiesOut = int.Parse(tbxCopiesOut.Text);
            _updateconferenceproceeding.SubjectArea = tbxSubjectArea.Text;
            _updateconferenceproceeding.YearOfPublication = tbxYearOfPublication.Text;
            _updateconferenceproceeding.Keyword = tbxKeyword.Text;
            _updateconferenceproceeding.ConfNumberID = int.Parse(tbxConfNumberID.Text);
            _updateconferenceproceeding.Status = tbxStatus.Text;

            dc.SubmitChanges();
            viewconferencedetails.datagrid.ItemsSource = dc.ConferenceProceedings.ToList();
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
