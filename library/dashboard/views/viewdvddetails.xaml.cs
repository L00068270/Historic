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

        //AzureLibraryEntities dc = new AzureLibraryEntities();

        public static DataGrid datagrid;

        int Id;

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
            DVD newDVDObject = new  DVD()
            {
                DVDID = int.Parse(this.tbxDVDID.Text),
                Title = tbxTitle.Text,
                Producer = tbxProducer.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                DVDNumberID = int.Parse(this.tbxDVDNumberID.Text),
                ShelfNumber = int.Parse(this.tbxShelfNumber.Text),
                Status = tbxStatus.Text,
            };
            dc.DVDs.InsertOnSubmit(newDVDObject);
            dc.SubmitChanges();
            viewdvddetails.datagrid.ItemsSource = dc.DVDs.ToList();

            //now clear textboxes after insert
            tbxDVDID.Text = "";
            tbxTitle.Text = "";
            tbxProducer.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxDVDNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();


            //now clear textboxes after insert
            tbxDVDID.Text = "";
            tbxTitle.Text = "";
            tbxProducer.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxDVDNumberID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
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
