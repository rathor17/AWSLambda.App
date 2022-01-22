using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainApplication
{
    public class Program
    {
        private static readonly string CalculatorSericeURL = "http://localhost:5000";
        private static readonly HttpClient client = new HttpClient() { BaseAddress = new Uri(CalculatorSericeURL)};

        public static async Task Main(string[] args)
        {
            await Calculator();
        }

        private static async Task Calculator()
        {
            try
            {
                var operation = DisplayOperationInfo();

                var firstValue = GetValidInputValues("first");
                ;
                var secondValue = GetValidInputValues("second");
                Console.WriteLine();

                var response = await client.GetAsync($"/api/Calculator?operation={operation}&firstValue={firstValue}&secondValue={secondValue}");
                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine($"Result: {response.Content.ReadAsStringAsync().Result}");
                }
                else
                {
                    Console.WriteLine(response.StatusCode.ToString());
                }
                Console.WriteLine();

                CheckContinuation();
                await Calculator();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int DisplayOperationInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Simple Calculator Application");
            Console.WriteLine("1 = Addition");
            Console.WriteLine("2 = Substraction");
            Console.WriteLine("3 = Division");
            Console.WriteLine("4 = Multiplication");
            Console.WriteLine("Please enter the operation");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int operation);
            if (operation < 1 || operation > 4)
            {
                Console.WriteLine("Invalid selection. Please try again");
                DisplayOperationInfo();
            }
            return operation;
        }

        private static decimal GetValidInputValues(string nth)
        {
            Console.WriteLine();
            Console.WriteLine($"Please enter {nth} value");
            decimal.TryParse(Console.ReadLine().ToString(), out decimal value);
            if (value < 0)
            {
                GetValidInputValues(nth);
            }
            return value;
        }

        private static async void CheckContinuation()
        {
            Console.WriteLine("Please press 'x' to exit or any other key to continue");
            var input = Console.ReadKey().Key.ToString();
            if (input.ToLower() == "x")
            {
                Environment.Exit(0);
            }
        }
    }
}
