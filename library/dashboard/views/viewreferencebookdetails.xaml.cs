using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.referencebooks;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewreferencebookdetails.xaml
    /// </summary>
    public partial class viewreferencebookdetails : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        //AzureLibraryEntities dc = new AzureLibraryEntities();

        public static DataGrid datagrid;

        public viewreferencebookdetails()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

        
        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.ReferenceBooks.ToList();
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
            ReferenceBook newReferenceBookObject = new ReferenceBook()
            {
                RefBookID = int.Parse(this.tbxRefBookID.Text),
                Title = tbxTitle.Text,
                Author = tbxAuthor.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                ShelfNumber = tbxShelfNumber.Text,
                Status = tbxStatus.Text,
            };
            dc.ReferenceBooks.InsertOnSubmit(newReferenceBookObject);
            dc.SubmitChanges();
            viewreferencebookdetails.datagrid.ItemsSource = dc.ReferenceBooks.ToList();

            //now clear textboxes after insert
            tbxRefBookID.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxRefBookID.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ReferenceBook).RefBookID;
            var deleteReferenceBook = dc.ReferenceBooks.Where(reference => reference.RefBookID == id).Single();
            dc.ReferenceBooks.DeleteOnSubmit(deleteReferenceBook);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.ReferenceBooks.ToList();
        }
    }
}
