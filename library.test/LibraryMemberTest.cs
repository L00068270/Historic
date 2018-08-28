using library;
using library.pages;
using library.librarymember;
using System;
using System.Windows;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;

namespace library.pages.Tests
{
    [TestClass()]
    public class LibraryMemberTest
    {
        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }
          



        private object username;

        //******************************************************************************************
        // .....................................Test Notes.........................................
        // 'TestiIitialise' initialises L1 for all the following LibraryMamber tests
        // L1 is reference type
        // L2 is reference type
        // L1 and L2 are pointing to two different objects if nor otherwise established ie. L1 = L2
        //
        //******************************************************************************************


        [TestInitialize]
        public void functionTestDataForLibraryMember()
        {
            LibraryMember L1 = new LibraryMember();

            L1.MemberID = Convert.ToInt32(1000);
            L1.NameFirst = "John";
            L1.NameFirst = "J";
            L1.NameLast = "Smith";
            L1.Username = "john";
            L1.Password = "smith";
            L1.ConfirmPassword = "smith";
            L1.Address = "Donegal";
            L1.Street = "Donegal";
            L1.Town = "Donegal";
            L1.County = "Donegal";
            L1.County = "Ireland";
            L1.Postcode = "PPP ppp";
            L1.Classification = Convert.ToInt32(1);
        }

        //******************************************************************************************
        //
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]

        public void areTheSameLoginTest()
        {
            // Arrange
            // from above - call L1
            LibraryMember L1 = new LibraryMember();

            LibraryMember L2 = new LibraryMember()
            {
                MemberID = 1000,
                NameFirst = "John",
                NameInitial = "J",
                NameLast = "Smith",
                Username = "john",
                Password = "smith",
                ConfirmPassword = "smith",
                Address = "Donegal",
                Street = "Donegal",
                Town = "Donegal",
                County = "Donegal",
                Country = "Ireland",
                Postcode = "PPP ppp",
                Classification = 1
            };

            // Act
            // this points L1 and L2 to the same place in memory - statemrnt shoult be 'AreSame' 
            L1 = L2;

            // Assert
            Assert.AreSame(L1, L2);
        }


        //******************************************************************************************
        //
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]

        public void areNotTheSameLoginTest()
        {
            // Arrange
            // from above - call L1
            LibraryMember L1 = new LibraryMember();

            LibraryMember L2 = new LibraryMember()
            {
                MemberID = 1000,
                NameFirst = "John",
                NameInitial = "J",
                NameLast = "smith",
                Username = "johndifferent",
                Password = "smithdifferent",
                ConfirmPassword = "smithdifferent",
                Address = "Donegal",
                Street = "Donegal",
                Town = "Donegal",
                County = "Donegal",
                Country = "Ireland",
                Postcode = "PPP ppp",
                Classification = 1
            };

            // Act
            L1 = L2; 

            // Assert
            Assert.AreNotSame(L1, L2, "L1 is the same as L2");
        }


        //******************************************************************************************
        //
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        public void functionToLoadLibraryMembersTest()
        {
            // Arrange
            // L1 from above
            LibraryMember L1 = new LibraryMember();

            LibraryMember L2 = new LibraryMember()
            {
                MemberID = 1000,
                NameFirst = "John",
                NameInitial = "J",
                NameLast = "smith",
                Username = "john",
                Password = "smith",
                ConfirmPassword = "smith",
                Address = "Donegal",
                Street = "Donegal",
                Town = "Donegal",
                County = "Donegal",
                Country = "Ireland",
                Postcode = "PPP ppp",
                Classification = 1
            };

            // Assert
            Assert.AreNotSame(L1, L2, "L1 and L2 are not the same");
        }

        //******************************************************************************************
        //
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        public void isInstanceOfTypeLibraryMembersTest()
        {
            // Arrange
            LibraryMember L2 = new LibraryMember()
            {
                MemberID = 1000,
                NameFirst = "John",
                NameInitial = "J",
                NameLast = "smith",
                Username = "john",
                Password = "smith",
                ConfirmPassword = "smith",
                Address = "Donegal",
                Street = "Donegal",
                Town = "Donegal",
                County = "Donegal",
                Country = "Ireland",
                Postcode = "Ireland",
                Classification = 1
            };

            // Assert
            Assert.IsInstanceOfType(L2, typeof(LibraryMember));
        }

        //******************************************************************************************
        //
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        public void isInstanceOfTypeLibraryMembersTest2()
        {
            // Arrange
            LibraryMember L1 = new LibraryMember();

            // Assert
            Assert.IsInstanceOfType(L1, typeof(LibraryMember));
        }


        //******************************************************************************************
        // test if the two objects L1 and L2 have equal properties
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        public void isPropertiesSameLibraryMembersTest()
        {
            // Arrange
            LibraryMember L1 = new LibraryMember();

            LibraryMember L2 = new LibraryMember()
            {
                MemberID = 1000,
                NameFirst = "John",
                NameInitial = "J",
                NameLast = "smith",
                Username = "john",
                Password = "smith",
                ConfirmPassword = "smith",
                Address = "Donegal",
                Street = "Donegal",
                Town = "Donegal",
                County = "Donegal",
                Country = "Ireland",
                Postcode = "PPP ppp",
                Classification = 1
            };

            // Assert
            Assert.IsTrue(areObjectPropertiesEqual(L1,L2));

        }
        // this method will return true of false
        private static bool areObjectPropertiesEqual(LibraryMember expected, LibraryMember actual)
        {
            return
                expected.MemberID == actual.MemberID &&
                expected.NameFirst == actual.NameFirst &&
                expected.NameInitial == actual.NameInitial&&
                expected.NameLast == actual.NameLast &&
                expected.Username == actual.Username &&
                expected.Password == actual.Password &&
                expected.ConfirmPassword == actual.ConfirmPassword &&
                expected.Address == actual.Address &&
                expected.Street == actual.Street &&
                expected.Town == actual.Town &&
                expected.County == actual.County &&
                expected.Country == actual.Country &&
                expected.Postcode == actual.Postcode &&
                expected.Classification == actual.Classification;
        }


        //******************************************************************************************
        // test if the two objects L1 and L2 have equal properties
        //https://docs.microsoft.com/en-gb/visualstudio/test/how-to-create-a-data-driven-unit-test
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        [DataSource("UnitTestDataSource")]
        public void allUsernameAreUniqueTest()
        {

            // Arrange

            // Act
            string a = context.DataRow["NameFirst"].ToString();
            string b = context.DataRow["NameLast"].ToString();


            //Assert
            Assert.AreNotEqual(a, b, "A value was equal");
            /*
            public void functionToLoadLibraryMembers()
            {
                _libraryMemberList.Clear();
                foreach (var librarymember in dc.LibraryMembers)
                {
                    _libraryMemberList.Add(librarymember);
                }
            }
            */

        }
        /*
        //******************************************************************************************
        // test if the two objects L1 and L2 have equal properties
        //******************************************************************************************
        [TestMethod()]
        [TestCategory("LibraryMember")]
        public void allUsernamesAreUniqueTest()
        {
            List<LibraryMember> _libraryMemberList = new List<LibraryMember>();

            private TestContext _instanceTestContext;

            public TestContext TestContext
            {
                get { return _instanceTestContext; }
                set { _instanceTestContext = value; }
            }

            [DataSource("UnitTestDataSource")]

            _libraryMemberList.Username = TestContext.DataRow["Username"].ToString();

            //Assert
            CollectionAssert.AllItemsAreUnique(Username);

        }
        */
    }


    //**********************************************************************************************************************
    //
    //**********************************************************************************************************************

    /*

    [TestMethod()]
    [TestCategory("LibraryMember")]
    public void functionToLoadLibraryMembersTest()
    {
        // Arrange
        // initialise objects to be passed to the Divide function being tested
        var expected = 
        var actual = 

        // Act 
        // invoke functionto be tested
        // result will be stored in variable called 'Actual'
        bool actual = MyClassesLibrary.Calculator.IsPositive(18);

        // Assert
        // verify if the function is acting as expected
        Assert.IsTrue(actual);
    }
    */
}


//**********************************************************************************************************************
//
//**********************************************************************************************************************

namespace library.test
{
    [TestClass]
    public class LibraryMemberTest
    {
         /*  
        LinqAzureDatabaseDataContext dc = new LinqAzureDatabaseDataContext
            (Properties.Settings.Default.libraryConnectionString);

        // creates a TestContext object to store the data source information for a data-driven test
        private TestContext _instanceTestContext;


        public TestContext TestContext
        {
            get { return _instanceTestContext; }
            set { _instanceTestContext = value; }
        }


        [DataSource(
            @"lougheske.database.windows.net",
            "Server=tcp:lougheske.database.windows.net,1433;Initial Catalog=library;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
            "LibraryMember",
            DataAccessMethod.Sequential
            )]


                [DataSource("UnitTestDataSource")]

        [TestMethod]
        [TestCategory("LibraryMember")]
        public void DataDrivenLibraryMemberTest()
        {
            // Arrange
            // initialise objects to be passed to the Divide function being tested


            // Act 
            // invoke functionto be tested
            // result will be stored in variable called 'Actual'
            // LibraryMember _libraryMember = new LibraryMember();
            int MemberID = Convert.ToInt32(_instanceTestContext.DataRow["MemberID"]);
            string NameFirst = _instanceTestContext.DataRow["NameFirst"].ToString();


            //_libraryMember.MemberID = int.Parse(TestContext.DataRow["MemberID"].ToString());
            //string NameFirst = TestContext.DataRow["NameFirst"].ToString();
            //_libraryMember.NameInitial = TestContext.DataRow["NameInitial"].ToString();
            //_libraryMember.NameLast = TestContext.DataRow["NameLast"].ToString();
            //_libraryMember.Username = TestContext.DataRow["Username"].ToString();
            //_libraryMember.Password = TestContext.DataRow["Password"].ToString();
            //_libraryMember.ConfirmPassword = TestContext.DataRow["ConfirmPassword"].ToString();
            //_libraryMember.Address = TestContext.DataRow["Address"].ToString();
            //_libraryMember.Street = TestContext.DataRow["Street"].ToString();
            //_libraryMember.Town = TestContext.DataRow["Town"].ToString();
            //_libraryMember.County = TestContext.DataRow["County"].ToString();
            //_libraryMember.Country = TestContext.DataRow["Country"].ToString();
            //_libraryMember.Postcode = TestContext.DataRow["Postcode"].ToString();
            //_libraryMember.Classification = int.Parse(TestContext.DataRow["MemberID"].ToString());

            // Assert
            // verify if the function is acting as expected
            //Assert.IsNotNull(_instanceTextContext.MemberID);
            //Assert.IsNotNull(_libraryMember.NameFirst);
            //Assert.IsNotNull(_libraryMember.NameInitial);
            //Assert.IsNotNull(_libraryMember.NameLast);
            //Assert.IsNotNull(_libraryMember.Username);
            //Assert.IsNotNull(_libraryMember.Password);
            //Assert.IsNotNull(_libraryMember.ConfirmPassword);
            //Assert.IsNotNull(_libraryMember.Address);
            //Assert.IsNotNull(_libraryMember.Street);
            //Assert.IsNotNull(_libraryMember.Town);
            //Assert.IsNotNull(_libraryMember.County);
            //Assert.IsNotNull(_libraryMember.Country);
            //Assert.IsNotNull(_libraryMember.Postcode);
            //Assert.IsNotNull(_libraryMember.Classification);
        } 
        */          
    } 
}
