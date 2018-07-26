using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesLibrary
{
    public class person
    {
        /*for better security - do not use public variables, us properties as shown here*/ 
        public string _firstname { get; set; }
        public string _lastname { get; set; }
        public string _address { get; set; }
        public string _town { get; set; }
        public string _county { get; set; }
        public string _country { get; set; }

        public String _fullname
        {
            get
            {
                return $"{_firstname} {_lastname} {_address} {_town} {_county} {_country}";
            }
        }
    }
}
