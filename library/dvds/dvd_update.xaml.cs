using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using library.dashboard.views;

namespace library.dvds
{
    /// <summary>
    /// Interaction logic for dvd_update.xaml
    /// </summary>
    public partial class dvd_update : Window
    {
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        public static DataGrid datagrid;

        int Id;

        public dvd_update(int dvdid)
        {
            InitializeComponent();
            Id = dvdid;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DVD _updatedvd = (from dvd in dc.DVDs
                                      where dvd.DVDID == Id
                                      select dvd).Single();

            _updatedvd.DVDID = int.Parse(this.tbxDVDID.Text);
            _updatedvd.Title = tbxTitle.Text;
            _updatedvd.Producer = tbxProducer.Text;
            _updatedvd.CopiesTotal = int.Parse(tbxCopiesTotal.Text);
            _updatedvd.CopiesAvailable = int.Parse(tbxCopiesAvailable.Text);
            _updatedvd.CopiesOut = int.Parse(tbxCopiesOut.Text);
            _updatedvd.SubjectArea = tbxSubjectArea.Text;
            _updatedvd.YearOfPublication = tbxYearOfPublication.Text;
            _updatedvd.Keyword = tbxKeyword.Text;
            _updatedvd.DVDNumberID = int.Parse(tbxDVDNumberID.Text);
            _updatedvd.Status = tbxStatus.Text;

            dc.SubmitChanges();
            viewdvddetails.datagrid.ItemsSource = dc.DVDs.ToList();
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
