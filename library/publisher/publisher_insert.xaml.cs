using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace library.publisher
{
    /// <summary>
    /// Interaction logic for publisher_insert.xaml
    /// </summary>
    public partial class publisher_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public publisher_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            publisher_insert functionToAddRowOfDataToDataGrid = new publisher_insert();
            dc.SubmitChanges();

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
                AccountNumber = tbxAccountNumber.Text
            };
            dc.Publishers.InsertOnSubmit(newPublisherObject);
            dc.SubmitChanges();
            publisher_details.datagrid.ItemsSource = dc.Publishers.ToList();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
