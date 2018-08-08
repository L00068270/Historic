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
    /// Interaction logic for conference_insert.xaml
    /// </summary>
    public partial class conference_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public conference_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            conference_insert functionToAddRowOfDataToDataGrid = new conference_insert();
            dc.SubmitChanges();

            ConferenceProceeding newConferenceProceedingObject = new ConferenceProceeding()
            {
                ConfID = int.Parse(this.tbxConfID.Text),
                Title = tbxTitle.Text,
                Author = tbxAuthor.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                ConfNumberID = int.Parse(this.tbxConfNumberID.Text),
                ShelfNumber = tbxShelfNumber.Text,
                Status = tbxStatus.Text,
            };
            dc.ConferenceProceedings.InsertOnSubmit(newConferenceProceedingObject);
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
