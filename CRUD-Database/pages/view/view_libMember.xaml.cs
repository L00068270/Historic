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

namespace CRUD_Database.pages.view
{
    /// <summary>
    /// Interaction logic for view_libMember.xaml
    /// </summary>
    public partial class view_libMember : UserControl
    {
        /**************************************************************************************************
         * (1)
         * database entities framework reference - library SQL database
         *************************************************************************************************/
        AzureLibraryEntities dc = new AzureLibraryEntities();


        /**************************************************************************************************
         * (2)
         * global list (_libraryMemberList) of records in the database LibraryMember table
         *************************************************************************************************/
        List<LibraryMember> _libraryMemberList = new List<LibraryMember>();

        public view_libMember()
        {
            InitializeComponent();
            // (3) setting the item source of the ListView to the global '_libraryMemberList' list
            myListView.ItemsSource = _libraryMemberList;
        }

        /**************************************************************************************************
         * (4)
         * functionToLoadLibraryMembers 
         *      - will load the SQL records from the LibraryMember table into the global _libraryMemberList
         *      - clears contents of _bookList
         *      - then add all books to global list
         * ***********************************************************************************************/
        public void functionToLoadLibraryMembers()
        {
            _libraryMemberList.Clear();
            foreach (var _librarymember in dc.LibraryMembers)
            {
                _libraryMemberList.Add(_librarymember);
            }
        }

        /**************************************************************************************************
        * (5)
        * Window_Loaded 
        *      - preload LibraryMember table into the global _libraryMemberList
        *      - it runs the functionToLoadBooks method once the application initialises
        *      
        *************************************************************************************************/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            functionToLoadLibraryMembers();
            functionToShowAdministratorButtons(_currentLibraryMember.Classification);
        }


        /**************************************************************************************************
        * (6)
        * public library member called '_currentLibraryMember'
        *      
        *************************************************************************************************/
        public LibraryMember _currentLibraryMember = new LibraryMember();



        /**************************************************************************************************
        * (7)
        * myViewList_SelectedChanged
        * this selects the library member at its position in myListView   
        *************************************************************************************************/
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //see if user exists in the database
            if (_libraryMemberList.Count > 0)
            {
                //get the library member from _libraryMemberList at the same position it is in the myViewList
                _currentLibraryMember = _libraryMemberList.ElementAt(this.myListView.SelectedIndex);
                functionToPopulateLibraryMemberDetails(_currentLibraryMember);
            }

        }


        /**************************************************************************************************
        * (8)
        * functionToPopulateLibraryMemberDetails
        * this method will populate the Library Member information within the DockPanel  
        *************************************************************************************************/
        private void functionToPopulateLibraryMemberDetails(LibraryMember selectedLibraryMember)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbxMemberID.Text = selectedLibraryMember.MemberID.ToString();
            tbxNameFirst.Text = selectedLibraryMember.NameFirst;
            tbxNameInitial.Text = selectedLibraryMember.NameInitial;
            tbxNameLast.Text = selectedLibraryMember.NameLast;
            tbxUsername.Text = selectedLibraryMember.Username;
            tbxPassword.Text = selectedLibraryMember.Password;
            tbxConfirmPassword.Text = selectedLibraryMember.ConfirmPassword;
            tbxAddress.Text = selectedLibraryMember.Address;
            tbxStreet.Text = selectedLibraryMember.Street;
            tbxTown.Text = selectedLibraryMember.Town;
            tbxCounty.Text = selectedLibraryMember.County;
            tbxCountry.Text = selectedLibraryMember.Country;
            tbxPostcode.Text = selectedLibraryMember.Postcode;
            {
                //setting the index of the compo box
                if(selectedLibraryMember.Classification == 1)
                {
                    cboClassification.SelectedIndex = 0;
                    
                }
                if(selectedLibraryMember.Classification == 2)
                {
                    cboClassification.SelectedIndex = 1;
                }
            }
        }

        /**************************************************************************************************
        * (9)
        * Updating the library members details
        *     
        *************************************************************************************************/
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _currentLibraryMember.NameFirst = tbxNameFirst.Text.Trim();
            _currentLibraryMember.NameInitial = tbxNameInitial.Text.Trim();
            _currentLibraryMember.NameLast = tbxNameLast.Text.Trim();
            _currentLibraryMember.Username = tbxUsername.Text.Trim();
            _currentLibraryMember.Password = tbxPassword.Text.Trim();
            _currentLibraryMember.ConfirmPassword = tbxConfirmPassword.Text.Trim();
            _currentLibraryMember.Address = tbxAddress.Text.Trim();
            _currentLibraryMember.Street = tbxStreet.Text.Trim();
            _currentLibraryMember.Town = tbxTown.Text.Trim();
            _currentLibraryMember.County = tbxCounty.Text.Trim();
            _currentLibraryMember.Country = tbxCountry.Text.Trim();
            _currentLibraryMember.Postcode = tbxPostcode.Text.Trim();
            _currentLibraryMember.Classification = cboClassification.SelectedIndex;

            bool _libraryMemberVerified = functionToVerifyLibraryMemberDetails(_currentLibraryMember);

            if(_libraryMemberVerified)
            {
                functionToUpdateLibraryMember(_currentLibraryMember, _entityState);
                functionToPopulateLibraryMemberDetails(_currentLibraryMember);
                myListView.Items.Refresh();
            }           
        }

        /**************************************************************************************************
        * (10)
        * functionToUpdateLibraryMember
        *             
        *************************************************************************************************/
        private void functionToUpdateLibraryMember(LibraryMember _librarymember, string modifyState)
        {
            try
            {
                if (modifyState == "Add")
                {
                    _librarymember.MemberID = new Int32();
                    dc.Configuration.AutoDetectChangesEnabled = false;
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.Entry(_librarymember).State = System.Data.Entity.EntityState.Added;
                    MessageBox.Show("New Library Member Added");
                }
                if (modifyState == "Modify")
                {
                    foreach (var _LibraryMemberRecord in dc.LibraryMembers.Where(t => t.MemberID == _librarymember.MemberID))
                    {
                        _LibraryMemberRecord.NameFirst = _librarymember.NameFirst;
                        _LibraryMemberRecord.NameInitial = _librarymember.NameInitial;
                        _LibraryMemberRecord.NameLast = _librarymember.NameLast;
                        _LibraryMemberRecord.Username = _librarymember.Username;
                        _LibraryMemberRecord.Password = _librarymember.Password;
                        _LibraryMemberRecord.ConfirmPassword = _librarymember.ConfirmPassword;
                        _LibraryMemberRecord.Address = _librarymember.Address;
                        _LibraryMemberRecord.Street = _librarymember.Street;
                        _LibraryMemberRecord.Town = _librarymember.Town;
                        _LibraryMemberRecord.County = _librarymember.County;
                        _LibraryMemberRecord.Country = _librarymember.Country;
                        _LibraryMemberRecord.Postcode = _librarymember.Postcode;
                        _LibraryMemberRecord.Classification = _librarymember.Classification;

                        MessageBox.Show("Library Member Modified");
                    }
                }
                if (modifyState == "Delete")
                {
                    dc.LibraryMembers.RemoveRange(
                    dc.LibraryMembers.Where(t => t.MemberID == _librarymember.MemberID));
                    MessageBox.Show("Library Member Deleted");
                }
                dc.SaveChanges();
                dc.Configuration.AutoDetectChangesEnabled = true;
                dc.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem writing to database");
            }
        }

        /**************************************************************************************************
        * (11)
        * global value to control the value of the entity state
        *             
        *************************************************************************************************/
        string _entityState = "Modify";



        /**************************************************************************************************
        * (12)
        * button btnAddLibraryMember
        *             
        *************************************************************************************************/
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            functionToClearLibraryMemberDetails();
            _entityState = "Add";
        }
        


        /**************************************************************************************************
        * (13)
        * functionToClearLibraryMemberDetails
        *              
        *************************************************************************************************/
        private void functionToClearLibraryMemberDetails()
        {
            tbxMemberID.Text = "";
            tbxNameFirst.Text = "";
            tbxNameInitial.Text = "";
            tbxNameLast.Text = "";
            tbxUsername.Text = "";
            tbxPassword.Text = "";
            tbxConfirmPassword.Text = "";
            tbxAddress.Text = "";
            tbxStreet.Text = "";
            tbxTown.Text = "";
            tbxCounty.Text = "";
            tbxCountry.Text = "";
            tbxPostcode.Text = "";
            cboClassification.SelectedIndex = 0;
        }


        /**************************************************************************************************
        * (14)
        * 
        *   function to take the contents of the textboxes and add them to global user list          
        *************************************************************************************************/
        private bool functionToVerifyLibraryMemberDetails(LibraryMember _librarymember)
        {
            bool _libraryMemberVerified = false;
            try
            {
                if (_librarymember.NameFirst == null)
                {
                    _librarymember.NameFirst = "";
                }
                if (_librarymember.NameInitial == null)
                {
                    _librarymember.NameInitial = "";
                }
                if (_librarymember.NameLast == null)
                {
                    _librarymember.NameLast = "";
                }
                if (_librarymember.Username == null)
                {
                    _librarymember.Username = "";
                }
                if (_librarymember.Password == null)
                {
                    _librarymember.Password = "";
                }
                if (_librarymember.ConfirmPassword == null)
                {
                    _librarymember.ConfirmPassword = "";
                }
                if (_librarymember.Address == null)
                {
                    _librarymember.Address = "";
                }
                if (_librarymember.Street == null)
                {
                    _librarymember.Street = "";
                }
                if (_librarymember.Town == null)
                {
                    _librarymember.Town = "";
                }
                if (_librarymember.County == null)
                {
                    _librarymember.County = "";
                }
                if (_librarymember.Country == null)
                {
                    _librarymember.Country = "";
                }
                if (_librarymember.Postcode == null)
                {
                    _librarymember.Postcode = "";
                }
                if (_librarymember.Classification == -1)
                {
                    _librarymember.Classification = 2;
                }
                _libraryMemberVerified = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem verifying user");
            }
            return _libraryMemberVerified;
        }


        /**************************************************************************************************
        * (15)
        * delete the library members details
        *      
        *            
        *************************************************************************************************/
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _entityState = "Delete";
            functionToUpdateLibraryMember(_currentLibraryMember, _entityState);
            functionToPopulateLibraryMemberDetails(_currentLibraryMember);
            myListView.Items.Refresh();
            dockUserPanel.Visibility = Visibility.Collapsed;
        }



        /**************************************************************************************************
        * (16)
        * Button Access for Administrator Classification
        *      
        *            
        *************************************************************************************************/
        private void functionToShowAdministratorButtons(int Classification)
        {
            if (Classification == 1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
        }
    }
}
