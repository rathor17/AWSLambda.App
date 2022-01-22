using System;
using System.Text.Json;
using Xunit;
using Amazon.Lambda.TestUtilities;

namespace AWSLambda.Calc.Tests
{
    public class FunctionTest
    {
        [Theory]
        [InlineData(1, 2, 3, 5)]
        [InlineData(2, 10, 15, -5)]
        [InlineData(3, 50, 5, 10)]
        [InlineData(4, 10, 3, 30)]
        public void TestCalculator_Success(int operation, decimal firstValue, decimal secondValue, decimal expected)
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            CalcInputClass calcInput = new CalcInputClass();
            calcInput.OperationType = operation;
            calcInput.FirstValue = firstValue;
            calcInput.SecondValue = secondValue;
            var jDocString = System.Text.Json.JsonSerializer.Serialize(calcInput);
            var jDoc = JsonDocument.Parse(jDocString);
            var result = function.FunctionHandler(jDoc, context);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 50, 0)]
        public void TestCalculator_Exception(int operation, decimal firstValue, decimal secondValue)
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            CalcInputClass calcInput = new CalcInputClass();
            calcInput.OperationType = operation;
            calcInput.FirstValue = firstValue;
            calcInput.SecondValue = secondValue;
            var jDocString = System.Text.Json.JsonSerializer.Serialize(calcInput);
            var jDoc = JsonDocument.Parse(jDocString);
            //var result = function.FunctionHandler(jDoc, context);
            Assert.Throws<DivideByZeroException>(() => function.FunctionHandler(jDoc, context));
        }
    }
}
