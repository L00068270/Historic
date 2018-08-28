using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using library;

namespace library.test
{
    [TestClass]
    public class CalculatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Calculator")]
        public void Test_Divide_PositiveNumbers_ReturnsPositiveAnswer()
        {
            // Arrange
            // initialise objects to be passed to the Divide function being tested
            int expected = 6;
            int numerator = 18;
            int denominator = 3;

            // Act 
            // invoke function to be tested
            // result will be stored in variable called 'Actual'
            int actual = MyClassesLibrary.Calculator.Divide(numerator, denominator);

            // Assert
            // verify if the function is acting as expected
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        public void Test_Divide_PositiveNumeratorAndNegativeDenominator_ReturnsNegativeAnswer()
        {
            // Arrange
            // initialise objects to be passed to the Divide function being tested
            int expected = -6;
            int numerator = 18;
            int denominator = -3;

            // Act 
            // invoke functionto be tested
            // result will be stored in variable called 'Actual'
            int actual = MyClassesLibrary.Calculator.Divide(numerator, denominator);

            // Assert
            // verify if the function is acting as expected
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        public void Test_Divide_NegativeNumeratorAndNegativeDenominator_ReturnsPositiveAnswer()
        {
            // Arrange
            // initialise objects to be passed to the Divide function being tested
            int expected = 6;
            int numerator = -18;
            int denominator = -3;

            // Act 
            // invoke functionto be tested
            // result will be stored in variable called 'Actual'
            int actual = MyClassesLibrary.Calculator.Divide(numerator, denominator);

            // Assert
            // verify if the function is acting as expected
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);

        }
        

        [TestMethod]
        [TestCategory("Calculator")]
        public void Test_IsPositive_PositiveNumber_ReturnsTrue()
        {
            // Arrange
            // initialise objects to be passed to the Divide function being tested


            // Act 
            // invoke function to be tested
            // result will be stored in variable called 'Actual'
            bool actual = MyClassesLibrary.Calculator.IsPositive(18);

            // Assert
            // verify if the function is acting as expected
            Assert.IsTrue(actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
        }
        [TestCleanup]
        public void Cleanup()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
    }
}
