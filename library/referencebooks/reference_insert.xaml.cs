using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.views;

namespace library.referencebooks
{
    /// <summary>
    /// Interaction logic for reference_insert.xaml
    /// </summary>
    public partial class reference_insert : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);


        public static DataGrid datagrid;

        public reference_insert()
        {
            InitializeComponent();
        }

        //*************************************************************************************************        
        // buttons here
        //*************************************************************************************************

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            reference_insert functionToAddRowOfDataToDataGrid = new reference_insert();
            dc.SubmitChanges();

            ReferenceBook newReferenceObject = new ReferenceBook()
            {
                RefBookID = int.Parse(this.tbxRefBookID.Text),
                Title = tbxTitle.Text,
                Author = tbxAuthor.Text,
                CopiesTotal = int.Parse(this.tbxCopiesTotal.Text),
                CopiesAvailable = int.Parse(this.tbxCopiesAvailable.Text),
                CopiesOut = int.Parse(this.tbxCopiesOut.Text),
                SubjectArea = tbxSubjectArea.Text,
                YearOfPublication = tbxYearOfPublication.Text,
                Keyword = tbxKeyword.Text,
                ShelfNumber = tbxShelfNumber.Text,
                Status = tbxStatus.Text,
            };
            dc.ReferenceBooks.InsertOnSubmit(newReferenceObject);
            dc.SubmitChanges();
            viewreferencebookdetails.datagrid.ItemsSource = dc.ReferenceBooks.ToList();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
