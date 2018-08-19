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
    /// Interaction logic for viewbookdetails.xaml
    /// </summary>
    public partial class viewbookdetails : UserControl
    {
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public viewbookdetails()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }
        

        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.Books.ToList();
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
            Book newBookObject = new Book()
            {
                ISBN = int.Parse(this.tbxISBN.Text),
                Title = tbxTitle.Text,
                Author = tbxAuthor.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                BookID = int.Parse(this.tbxBookID.Text),
                ShelfNumber = tbxShelfNumber.Text,
                Status = tbxStatus.Text,
                PublisherID = int.Parse(this.tbxPublisherID.Text),
            };
            dc.Books.InsertOnSubmit(newBookObject);
            dc.SubmitChanges();
            viewbookdetails.datagrid.ItemsSource = dc.Books.ToList();

            //now clear textboxes after insert
            tbxISBN.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxBookID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
            tbxPublisherID.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxISBN.Text = "";
            tbxTitle.Text = "";
            tbxAuthor.Text = "";
            tbxCopiesTotal.Text = "";
            tbxCopiesAvailable.Text = "";
            tbxCopiesOut.Text = "";
            tbxSubjectArea.Text = "";
            tbxYearOfPublication.Text = "";
            tbxKeyword.Text = "";
            tbxBookID.Text = "";
            tbxShelfNumber.Text = "";
            tbxStatus.Text = "";
            tbxPublisherID.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Book).ISBN;
            var deleteBook = dc.Books.Where(book => book.ISBN == id).Single();
            dc.Books.DeleteOnSubmit(deleteBook);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.Books.ToList();
        }
    }
}
