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
    /// Interaction logic for publisher_update.xaml
    /// </summary>
    public partial class publisher_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public publisher_update(int publisherid)
        {
            InitializeComponent();
            Id = publisherid;
        }
        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Publisher _updatepublisher = (from publisher in dc.Publishers
                                          where publisher.PublisherID == Id
                                          select publisher).Single();

            _updatepublisher.PublisherID = int.Parse(this.tbxPublisherID.Text);
            _updatepublisher.PublisherName = tbxPublisherName.Text;
            _updatepublisher.Email = tbxEmail.Text;
            _updatepublisher.ContactNumber = tbxContactNumber.Text;
            _updatepublisher.Address = tbxAddress.Text;
            _updatepublisher.Street = tbxStreet.Text;
            _updatepublisher.Town = tbxTown.Text;
            _updatepublisher.County = tbxCounty.Text;
            _updatepublisher.Country = tbxCountry.Text;
            _updatepublisher.Postcode = tbxPostcode.Text;
            _updatepublisher.Paidout = tbxPaidout.Text;
            _updatepublisher.AccountNumber = tbxAccountNumber.Text;

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
