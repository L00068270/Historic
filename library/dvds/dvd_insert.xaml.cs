using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace library.dvds
{
    /// <summary>
    /// Interaction logic for dvd_insert.xaml
    /// </summary>
    public partial class dvd_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        public dvd_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            dvd_insert functionToAddRowOfDataToDataGrid = new dvd_insert();
            dc.SubmitChanges();

            DVD newDVDObject = new DVD()
            {
                DVDID = int.Parse(this.tbxDVDID.Text),
                Title = tbxTitle.Text,
                Producer = tbxProducer.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                DVDNumberID = int.Parse(this.tbxDVDNumberID.Text),
                ShelfNumber = int.Parse(this.tbxShelfNumber.Text),
                Status = tbxStatus.Text,
            };
            dc.DVDs.InsertOnSubmit(newDVDObject);
            dc.SubmitChanges();
            dvd_details.datagrid.ItemsSource = dc.DVDs.ToList();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
