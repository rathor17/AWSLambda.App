namespace Calculator.Service.Service
{
    public class Calculator : ICalculator
    {
        public decimal Diff(decimal fisrtValue, decimal secondValue)
        {
            return fisrtValue - secondValue;
        }

        public decimal Divide(decimal fisrtValue, decimal secondValue)
        {
            return fisrtValue / secondValue;
        }

        public decimal Multiply(decimal fisrtValue, decimal secondValue)
        {
            return fisrtValue * secondValue;
        }

        public decimal Sum(decimal fisrtValue, decimal secondValue)
        {
            return fisrtValue + secondValue;
        }
    }
}
