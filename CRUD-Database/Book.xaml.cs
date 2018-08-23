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

namespace CRUD_Database
{
    /// <summary>
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        /**************************************************************************************************
         * database framework reference connect to SQL dataabase
         *************************************************************************************************/
        AzureLibraryEntities dc = new AzureLibraryEntities();




        /**************************************************************************************************
         * global list (_bookList) of records in the database LibraryMember table
         *************************************************************************************************/
        List<Book> _bookList = new List<Book>();

        public Book()
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
