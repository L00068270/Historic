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
    /// Interaction logic for viewjournals.xaml
    /// </summary>
    public partial class viewjournals : UserControl
    {
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static ListView listview;

        /**************************************************************************************************
         * new instance of Journal class 
         *************************************************************************************************/
        public Journal _instanceJournal = new Journal();

        public viewjournals()
        {
            InitializeComponent();
            functionToLoadDatabaseToListView();
        }
        
        //*************************************************************************************************        
        // functionToLoadDatabaseToListView
        //*************************************************************************************************
        public void functionToLoadDatabaseToListView()
        {
            myListView.ItemsSource = dc.Journals.ToList();
            listview = myListView;
        }
    }
}
