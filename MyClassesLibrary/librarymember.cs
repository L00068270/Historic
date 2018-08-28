using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesLibrary
{
    public class LibraryMember
    {
        /*for better security - do not use public variables, as properties as shown here*/
        private int _memberID;
        private string _nameFirst;
        private string _nameInitial;
        private string _nameLast;
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _address;
        private string _street;
        private string _town;
        private string _county;
        private string _country;
        private string _postcode;
        private int _classification;

       


        /**************************************************************************************************
         * (2)
         * global list (_libraryMemberList) of records in the database LibraryMember table
         *************************************************************************************************/
        List<LibraryMember> _libraryMemberList = new List<LibraryMember>();




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
        private LibraryMember functionToVerifyLibraryMemberDetails(string username, string password)
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

        

    }
}
