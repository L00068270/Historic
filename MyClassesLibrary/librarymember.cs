using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesLibrary
{
    public partial class LibraryMember
    {
        /*for better security - do not use public variables, as properties as shown here*/
        public int MemberID { get; set; }
        public string NameFirst { get; set; }
        public string NameInitials { get; set; }
        public string NameLast { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; } 
        public string Postcode { get; set; }
        public int Classification { get; set; }

        public String _fullname
        {
            get
            {
                return $"{MemberID} {NameFirst} {NameInitials} {NameLast} {Username} {Password} {Address} {Town} {County} {Country} {Postcode} {Classification}";
            }
        }
    }
}
