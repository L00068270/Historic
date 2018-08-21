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

        //AzureLibraryEntities dc = new AzureLibraryEntities();

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

            //now clear textboxes after insert
            tbxConfID.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxConfNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxConfID.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxConfNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
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
