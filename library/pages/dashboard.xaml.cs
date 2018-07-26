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
using MyClassesLibrary;

namespace library.pages
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Page
    {
        public LibraryMember currentUser;
       
        public dashboard()
        {
            InitializeComponent();
            functionSetUpSampleData();
        }

        /*all functions below*/
        private static List<person> people = new List<person>();

        public login O { get; internal set; }

        private void functionSetUpSampleData()
        {
            people.Add(new person { _firstname = "Aimee", _lastname = "Thomas", _address = "Finadoose", _town = "Donegal", _county = "County Donegal", _country = "Ireland" });
            people.Add(new person { _firstname = "Katie", _lastname = "Thomas", _address = "Finadoose", _town = "Donegal", _county = "County Donegal", _country = "Ireland" });
            people.Add(new person { _firstname = "Joanne", _lastname = "Thomas", _address = "Finadoose", _town = "Donegal", _county = "County Donegal", _country = "Ireland" });
            people.Add(new person { _firstname = "Ollie", _lastname = "Thomas", _address = "Finadoose", _town = "Donegal", _county = "County Donegal", _country = "Ireland" });
            peopleListBox.ItemsSource = people;
        }

        private void functionGreetAllThePeople()
        {
            foreach(person person in people)
            {
                Console.WriteLine($"Hello {0} {1}", person._firstname, person._lastname);
            }
        }
    }    
}
