using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace library.referencebooks
{
    /// <summary>
    /// Interaction logic for reference_update.xaml
    /// </summary>
    public partial class reference_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public reference_update(int referencebookid)
        {
            InitializeComponent();
            Id = referencebookid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ReferenceBook _updatereferencebook = (from referencebook in dc.ReferenceBooks
                                                                where referencebook.RefBookID == Id
                                                                select referencebook).Single();

            _updatereferencebook.RefBookID = int.Parse(this.tbxRefBookID.Text);
            _updatereferencebook.Title = tbxTitle.Text;
            _updatereferencebook.Author = tbxAuthor.Text;
            _updatereferencebook.CopiesTotal = int.Parse(tbxCopiesTotal.Text);
            _updatereferencebook.CopiesAvailable = int.Parse(tbxCopiesAvailable.Text);
            _updatereferencebook.CopiesOut = int.Parse(tbxCopiesOut.Text);
            _updatereferencebook.SubjectArea = tbxSubjectArea.Text;
            _updatereferencebook.YearOfPublication = tbxYearOfPublication.Text;
            _updatereferencebook.Keyword = tbxKeyword.Text;
            _updatereferencebook.Status = tbxStatus.Text;

            dc.SubmitChanges();
            reference_details.datagrid.ItemsSource = dc.ReferenceBooks.ToList();
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return to Administration Page");
            this.Close();
        }
    }
}
