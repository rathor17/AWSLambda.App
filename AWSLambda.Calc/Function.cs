using System;
using System.Text.Json;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda.Calc
{
    public class Function
    {

        /// <summary>
        /// Calculator
        /// </summary>
        /// <param name="operation">1 = Addition, 2 = substraction, 3 = division, 4 = multiplication</param>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public decimal FunctionHandler(JsonDocument calcInput, ILambdaContext context)
        {
            CalcInputClass calc = JsonSerializer.Deserialize<CalcInputClass>(calcInput);

            if (calc.OperationType < 0 || calc.OperationType > 4)
            {
                throw new ArgumentOutOfRangeException("Error: Operation not supported");
            }
            switch (calc.OperationType)
            {
                case 1:
                    return calc.FirstValue + calc.SecondValue;
                case 2:
                    return calc.FirstValue - calc.SecondValue;
                case 3:
                    return calc.FirstValue / calc.SecondValue;
                case 4:
                    return calc.FirstValue * calc.SecondValue;

                default: throw new ApplicationException("Error processing your request");

            }
        }
    }

    public class CalcInputClass
    {
        public int OperationType { get; set; }
        public decimal FirstValue { get; set; }
        public decimal SecondValue { get; set; }
    }
}
