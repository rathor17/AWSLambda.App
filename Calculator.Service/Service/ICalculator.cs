namespace Calculator.Service.Service
{
    public interface ICalculator
    {
        decimal Sum(decimal fisrtValue, decimal secondValue);

        decimal Diff(decimal fisrtValue, decimal secondValue);

        decimal Multiply(decimal fisrtValue, decimal secondValue);

        decimal Divide(decimal fisrtValue, decimal secondValue);
    }
}
