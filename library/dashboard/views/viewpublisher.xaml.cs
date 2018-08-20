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
using library.publisher;

namespace library.dashboard.views
{
    /// <summary>
    /// Interaction logic for viewpublisher.xaml
    /// </summary>
    public partial class viewpublisher : UserControl
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public viewpublisher()
        {
            InitializeComponent();
            functionToLoadDatabaseToDataGrid();
        }

        
        //*************************************************************************************************        
        // function here
        //*************************************************************************************************
        public void functionToLoadDatabaseToDataGrid()
        {
            myDataGrid.ItemsSource = dc.Publishers.ToList();
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
            Publisher newPublisherObject = new Publisher()
            {
                PublisherID = int.Parse(this.tbxPublisherID.Text),
                PublisherName = tbxPublisherName.Text,
                Email = tbxEmail.Text,
                ContactNumber = tbxContactNumber.Text,
                Address = tbxAddress.Text,
                Street = tbxStreet.Text,
                Town = tbxTown.Text,
                County = tbxCounty.Text,
                Country = tbxCountry.Text,
                Postcode = tbxPostcode.Text,
                Paidout = tbxPaidout.Text,
                AccountNumber = tbxAccountNumber.Text,
            };
            dc.Publishers.InsertOnSubmit(newPublisherObject);
            dc.SubmitChanges();
            viewpublisher.datagrid.ItemsSource = dc.Publishers.ToList();

            //now clear textboxes after insert
            tbxPublisherID.Text = "";
            tbxPublisherName.Text = "";
            tbxEmail.Text = "";
            tbxContactNumber.Text = "";
            tbxAddress.Text = "";
            tbxStreet.Text = "";
            tbxTown.Text = "";
            tbxCounty.Text = "";
            tbxCountry.Text = "";
            tbxPostcode.Text = "";
            tbxPaidout.Text = "";
            tbxAccountNumber.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();

            //now clear textboxes after insert
            tbxPublisherID.Text = "";
            tbxPublisherName.Text = "";
            tbxEmail.Text = "";
            tbxContactNumber.Text = "";
            tbxAddress.Text = "";
            tbxStreet.Text = "";
            tbxTown.Text = "";
            tbxCounty.Text = "";
            tbxCountry.Text = "";
            tbxPostcode.Text = "";
            tbxPaidout.Text = "";
            tbxAccountNumber.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as Publisher).PublisherID;
            var deletePublisher = dc.Publishers.Where(publisher => publisher.PublisherID == id).Single();
            dc.Publishers.DeleteOnSubmit(deletePublisher);
            dc.SubmitChanges();
            myDataGrid.ItemsSource = dc.Publishers.ToList();
        }
    }
}
