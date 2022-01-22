using System;
using Xunit;
using Calculator.Service;
using Calculator.Service.Service;

namespace Calculator.Service.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2, 3, 5)]
        [InlineData(2, 10, 15, -5)]
        [InlineData(3, 50, 5, 10)]
        [InlineData(4, 10, 3, 30)]

        public void TestCalculator_Success(int operation, decimal firstValue, decimal secondValue, decimal expected)
        {
            decimal result =0;
            Service.Calculator calculator = new Service.Calculator();
            switch (operation)
            {
                case 1:
                    result = calculator.Sum(firstValue, secondValue);
                    break;
                case 2:
                    result = calculator.Diff(firstValue, secondValue);
                    break;
                case 3:
                    result = calculator.Divide(firstValue, secondValue);
                    break;
                case 4:
                    result = calculator.Multiply(firstValue, secondValue);
                    break;

            }
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(50, 0)]
        public void TestCalculator_Exception(decimal firstValue, decimal secondValue)
        {
            // Invoke the lambda function and confirm the string was upper cased.
            Service.Calculator calculator = new Service.Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(firstValue, secondValue));
        }
    }
}
