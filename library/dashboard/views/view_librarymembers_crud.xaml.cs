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
    /// Interaction logic for view_librarymembers_crud.xaml
    /// </summary>
    public partial class view_librarymembers_crud : UserControl
    {
        //https://www.youtube.com/watch?v=ueWI3AsKit4
        /**************************************************************************************************
         * database framework reference
         *************************************************************************************************/

        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static ListView listview;

        /**************************************************************************************************
         * new instance of LibraryMember class 
         *************************************************************************************************/
        public LibraryMember _instanceLibraryMember = new LibraryMember();


        public view_librarymembers_crud()
        {
            InitializeComponent();
            functionToLoadDatabaseToListView();
        }


        //*************************************************************************************************        
        // functionToLoadDatabaseToListView
        //*************************************************************************************************
        public void functionToLoadDatabaseToListView()
        {
            //myListView.ItemsSource = dc.LibraryMembers.ToList();
            //listview = myListView;
        }
        //*************************************************************************************************        
        // functionToPopulateSelectedLineDetails
        //*************************************************************************************************
        public void functionToPopulateSelectedLineDetails(LibraryMember selectLibraryMember)
        {
            dockDetails.Visibility = Visibility.Visible;
            tbxNameFirst.Text = selectLibraryMember.NameFirst;
            tbxNameInitial.Text = selectLibraryMember.NameInitial;
            tbxNameLast.Text = selectLibraryMember.NameLast;
            tbxUsername.Text = selectLibraryMember.Username;
            tbxPassword.Text = selectLibraryMember.Password;
            tbxConfirmPassword.Text = selectLibraryMember.ConfirmPassword;
            tbxAddress.Text = selectLibraryMember.Address;
            tbxStreet.Text = selectLibraryMember.Street;
            tbxTown.Text = selectLibraryMember.Town;
            tbxCounty.Text = selectLibraryMember.County;
            tbxCountry.Text = selectLibraryMember.Country;
            tbxPostcode.Text = selectLibraryMember.Postcode;
        }

        


        //https://www.youtube.com/results?search_query=C%23+view+listview+details+in+textbox
        //*************************************************************************************************        
        // listview here
        //*************************************************************************************************
        private void myListView_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListView lv = (ListView)sender;
            //ListView.ViewProperty 

        }



        //*************************************************************************************************        
        // buttond here
        //*************************************************************************************************
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
