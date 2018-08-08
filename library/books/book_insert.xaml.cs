using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.viewmodels;
using library.dashboard.views;

namespace library.books
{
    /// <summary>
    /// Interaction logic for book_insert.xaml
    /// </summary>
    public partial class book_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public book_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            book_insert functionToAddRowOfDataToDataGrid = new book_insert();
            dc.SubmitChanges();

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
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
