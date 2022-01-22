using App.Library.Model;
using Calculator.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Calculator.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator calculator;
        private readonly ILogger<CalculatorController> logger;
        public CalculatorController(ICalculator _calculator, ILogger<CalculatorController> _logger)
        {
            this.calculator = _calculator;
            this.logger = _logger;
        }

        [HttpGet]
        public IActionResult Get(int operation, decimal firstValue, decimal secondValue)
        {
            logger.LogInformation("Simple Calculator");
            try
            {
                decimal result;
                Operation op;
                Enum.TryParse(operation.ToString(), out op);
                switch (op)
                {
                    case Operation.Add:
                        logger.LogInformation($"Addition of {firstValue} and {secondValue}");
                        result = calculator.Sum(firstValue, secondValue);
                        break;
                    case Operation.Substract:
                        logger.LogInformation($"Substraction of {firstValue} and {secondValue}");
                        result = calculator.Diff(firstValue, secondValue);
                        break;
                    case Operation.Multiply:
                        logger.LogInformation($"Multiplication of {firstValue} and {secondValue}");
                        result = calculator.Multiply(firstValue, secondValue);
                        break;
                    case Operation.Divide:
                        logger.LogInformation($"Division of {firstValue} and {secondValue}");
                        result = calculator.Divide(firstValue, secondValue);
                        break;
                    default:
                        logger.LogInformation($"Operation currently not defined");
                        throw new ArgumentOutOfRangeException("Operation not defined");

                }
                return Ok(result);
            }
            catch (DivideByZeroException ex)
            {
                logger.LogInformation($"Divided by 0 request is not possible");
                return BadRequest("Error: Cannot Divide by 0");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
