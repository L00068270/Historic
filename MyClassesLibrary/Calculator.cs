using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesLibrary
{
    public class Calculator
    {
        public static int Divide(int numerator, int denominator)
        {
            int result = numerator / denominator;
            return result;
        }

        public static int Add(int firstNumber, int secondNumber)
        {
            int result = firstNumber + secondNumber;
            return result;
        }

        public static bool IsPositive(int Number)
        {
            return Number > 0;
        }
    }
}
