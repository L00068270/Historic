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

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewreferencebooks.xaml
    /// </summary>
    public partial class viewreferencebooks : UserControl
    {
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        //AzureLibraryEntities dc = new AzureLibraryEntities();

        public static ListView listview;

        /**************************************************************************************************
         * new instance of ReferenceBook class 
         *************************************************************************************************/
        public ReferenceBook _instanceReferenceBook = new ReferenceBook();

        public viewreferencebooks()
        {
            InitializeComponent();
            functionToLoadDatabaseToListView();
        }

        //*************************************************************************************************        
        // functionToLoadDatabaseToListView
        //*************************************************************************************************
        public void functionToLoadDatabaseToListView()
        {
            myListView.ItemsSource = dc.ReferenceBooks.ToList();
            listview = myListView;
        }
    }
}
