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

        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }
        public string NameFirst
        {
            get { return _nameFirst; }
            set { _nameFirst = value; }
        }
        public string NameInitial
        {
            get { return _nameInitial; }
            set { _nameInitial = value; }
        }
        public string NameLast
        {
            get { return _nameLast; }
            set { _nameLast = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }
        public string County
        {
            get { return _county; }
            set { _county = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        public int Classification
        {
            get { return _classification; }
            set { _classification = value; }
        }

    }
}
