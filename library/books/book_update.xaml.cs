using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace library.books
{
    /// <summary>
    /// Interaction logic for book_update.xaml
    /// </summary>
    public partial class book_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public book_update(int isbn)
        {
            InitializeComponent();
            Id = isbn;
        } 
        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Book _updatebook = (from book in dc.Books
                                          where book.ISBN == Id
                                          select book).Single();

            _updatebook.ISBN = int.Parse(this.tbxISBN.Text);
            _updatebook.Title = tbxTitle.Text;
            _updatebook.Author = tbxAuthor.Text;
            _updatebook.CopiesTotal = int.Parse(tbxCopiesTotal.Text);
            _updatebook.CopiesAvailable = int.Parse(tbxCopiesAvailable.Text);
            _updatebook.CopiesOut = int.Parse(tbxCopiesOut.Text);
            _updatebook.SubjectArea = tbxSubjectArea.Text;
            _updatebook.YearOfPublication = tbxYearOfPublication.Text;
            _updatebook.Keyword = tbxKeyword.Text;
            _updatebook.BookID = int.Parse(tbxBookID.Text);
            _updatebook.Status = tbxStatus.Text;
            _updatebook.PublisherID = int.Parse(tbxPublisherID.Text);

            dc.SubmitChanges();
            book_details.datagrid.ItemsSource = dc.Books.ToList();
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
