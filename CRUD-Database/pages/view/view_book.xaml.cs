using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD_Database.pages.view
{
    /// <summary>
    /// Interaction logic for view_book.xaml
    /// </summary>
    public partial class view_book : UserControl
    {
        /**************************************************************************************************
         * database entities framework reference - library SQL database
         *************************************************************************************************/
        AzureLibraryEntities dc = new AzureLibraryEntities();


        /**************************************************************************************************
         * global list (_bookList) of records in the database Book table
         *************************************************************************************************/
        List<Book> _bookList = new List<Book>();

        public view_book()
        {
            InitializeComponent();
            //setting the item source of the ListView to the global book list
            myListView.ItemsSource = _bookList;
        }

        /**************************************************************************************************
         * 1. functionToLoadBooks 
         *      - will load the SQL records from the Book table into the global _bookList
         *      - clears contents of _bookList
         *      - then add all books to global list
         * ***********************************************************************************************/
        public void functionToLoadBooks()
        {
            _bookList.Clear();
            foreach (var book in dc.Books)
            {
                _bookList.Add(book);
            }
        }

        /**************************************************************************************************
         * 2. Window_Loaded 
         *      - preload books into the global _bookList
         *      - it runs the functionToLoadBooks method once the application initialises
         *      
         *************************************************************************************************/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            functionToLoadBooks();
        }
    }
}
