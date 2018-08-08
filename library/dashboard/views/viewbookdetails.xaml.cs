using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using library.books;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewbookdetails.xaml
    /// </summary>
    public partial class viewbookdetails : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

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
            book_insert insert = new book_insert();
            insert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Book).ISBN;
            book_update updatemember = new book_update(id);
            updatemember.ShowDialog();
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
