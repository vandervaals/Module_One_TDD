using CalculatorSample.Logic;
using Loggers;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CalculatorSample.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        Expression<Action<ILogger>> expression = l => l.Log(It.IsAny<string>());

        private Mock<ILogger> InitMock()
        {
            var mock = new Mock<ILogger>();
            mock.Setup(expression).Callback<string>(s => Debug.WriteLine(s));
            return mock;
        }

        private void CheckResult(Mock<ILogger> mock, int expectedResult, double result)
        {
            mock.Verify(expression, Times.Exactly(1));
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SumPositiveNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Add(5, 5);
            CheckResult(mock, expectedResult: 10, result);
        }

        [Test]
        public void SumNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Add(-5, -10);
            CheckResult(mock, expectedResult: -15, result);
        }

        [Test]
        public void SumPositiveAndNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Add(11, -10);
            CheckResult(mock, expectedResult: 1, result);
        }

        [Test]
        public void SumZeroAndNumber()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Add(11, 0);
            CheckResult(mock, expectedResult: 11, result);
        }

        [Test]
        public void SubtractPositiveNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(12, 7);
            CheckResult(mock, expectedResult: 5, result);
        }

        [Test]
        public void SubtractNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(-12, -7);
            CheckResult(mock, expectedResult: -5, result);
        }

        [Test]
        public void SubtractPositiveAndNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(12, -7);
            CheckResult(mock, expectedResult: 19, result);
        }

        [Test]
        public void SubtractZeroAndNegativeNumber()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(0, -7);
            CheckResult(mock, expectedResult: 7, result);
        }

        [Test]
        public void SubtractZeroAndPositiveNumber()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(0, 7);
            CheckResult(mock, expectedResult: -7, result);
        }

        [Test]
        public void SubtractNumberAndZero()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Subtract(7, 0);
            CheckResult(mock, expectedResult: 7, result);
        }

        [Test]
        public void DividePositiveNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Divide(15, 3);
            CheckResult(mock, expectedResult: 5, result);
        }

        [Test]
        public void DivideNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Divide(-15, -3);
            CheckResult(mock, expectedResult: 5, result);
        }

        [Test]
        public void DividePositiveAndNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Divide(15, -3);
            CheckResult(mock, expectedResult: -5, result);
        }

        [Test]
        public void DivideZero()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Divide(0, 3);
            CheckResult(mock, expectedResult: 0, result);
        }

        [Test]
        public void DivideNumberByZero()
        {
            var mock = InitMock();
            try
            {
                var result = new Calculator(mock.Object).Divide(3, 0);
            }
            catch (DivideByZeroException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [Test]
        public void MultiplyPositiveNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Multiply(15, 3);
            CheckResult(mock, expectedResult: 45, result);
        }

        [Test]
        public void MultiplyNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Multiply(-15, -3);
            CheckResult(mock, expectedResult: 45, result);
        }

        [Test]
        public void MultiplyPositiveAndNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Multiply(15, -3);
            CheckResult(mock, expectedResult: -45, result);
        }

        [Test]
        public void MultiplyNumberAndZero()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Multiply(15, 0);
            CheckResult(mock, expectedResult: 0, result);
        }

        [Test]
        public void PowPositiveNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Pow(15, 2);
            CheckResult(mock, expectedResult: 225, result);
        }

        [Test]
        public void PowNegativeNumbers()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Pow(-15, -2);
            mock.Verify(expression, Times.Exactly(1));
            Assert.AreEqual(Math.Pow(-15, -2), result);
        }

        [Test]
        public void NumberInZeroPow()
        {
            var mock = InitMock();
            var result = new Calculator(mock.Object).Pow(15, 0);
            CheckResult(mock, expectedResult: 1, result);
        }
    }
}
