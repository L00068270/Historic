using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_Database.pages.view;
using library;
using MyClassesLibrary;


namespace library.test
{
    [TestClass]
    public class LibraryMemberDataTest
    {
        [TestMethod]
        public void Test_GetLibraryMemberByUsername()
        {
            /*Arrange*************************************************************/
            //(1) Database entities framework reference - library SQL database
            AzureLibraryEntities dc = new AzureLibraryEntities();

            //(2) Instance of Class that contains method to be tested
            view_libMember _instanceLibraryMember = new view_libMember();

            //(3) Name of LibraryMember that will be extracted from the Database - Username
            string Sarah = "user1";

            //(4) Name of instanceLibraryMember expected from Database
            LibraryMember expected = new LibraryMember
            {
                MemberID = 2,
                NameFirst = "Sarah",
                NameInitial = "M",
                NameLast = "Leoney",
                Username = "user1",
                Password = "pass1",
                ConfirmPassword = "pass1",
                Address = "4 Whyte Field Crossgar",
                Street = "null",
                Town = "Downpatrick",
                County = "null",
                Country = "UK",
                Postcode = "BT30 9HB",
                Classification = 2
            };


            /*Act******************************************************************/
            //This is function to be tested
            //LibraryMember actual = dc.LibraryMembers.ToString(Sarah);



            /*Assert***************************************************************/
            //Assert.AreEqual<LibraryMember>(expected.Classification, actual.Classification, "Error extracting LibraryMember from Database");
        }
    }

    /**************************************************************************************************
         * (5)
         * functionToGetUserDetails
         *      - authenticate librarymember information
         *      - function that will take in the username and password and verify if the 
         *          librarymember exists in global _libraryMemberList
         *      - initialises '_libraryMemberDetails'
         *      - check each username and password in the global _libraryMemberList
         *      - if there is a match then add the details to the local librarymember account
         *      - return the library members details  
         *          
         *************************************************************************************************/
    /*private LibraryMember functionToVerifyLibraryMemberDetails(string username, string password)
    {
        LibraryMember _libraryMemberDetails = new LibraryMember();

        foreach (var _member in _libraryMemberList)
        {
            //if (username == _member.Username && password == _member.Password)
            {
                _libraryMemberDetails = _member;
            }
        }
        return _libraryMemberDetails;
    }
    */
}
