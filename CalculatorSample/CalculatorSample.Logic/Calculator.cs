using Loggers;
using System;

namespace CalculatorSample.Logic
{
    public class Calculator
    {
        private ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int x, int y)
        {
            _logger.Log($"Add: x={x}, y={y}.");
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            _logger.Log($"Subtract: x={x}, y={y}.");
            return x - y;
        }

        public double Divide(int x, int y)
        {
            _logger.Log($"Divide: x={x}, y={y}.");
            return x / y;
        }

        public int Multiply(int x, int y)
        {
            _logger.Log($"Multiply: x={x}, y={y}.");
            return x * y;
        }

        public double Pow(int x, int y)
        {
            _logger.Log($"Pow: x={x}, y={y}.");
            return Math.Pow(x, y);
        }
    }
}
