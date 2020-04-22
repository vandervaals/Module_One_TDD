using Numbers.Logic;
using NUnit.Framework;
using System;

namespace NumbersTests
{
    [TestFixture]
    public class NumbersFunctionsTests
    {
        [Test]
        public void InvalidCapacityParam()
        {
            Assert.Throws<ArgumentException>(() => NumbersFunctions.SearchNumbers(10, -1));
        }

        [Test]
        public void InvalidSumParam()
        {
            Assert.Throws<ArgumentException>(() => NumbersFunctions.SearchNumbers(-10, 10));
        }

        [Test]
        public void ValidParam()
        {
            var result = NumbersFunctions.SearchNumbers(6, 3);
            Assert.AreEqual(expected: new int[] { 21, 105, 600 }, result);
        }

        [Test]
        public void SearchNumbersWithOneResult()
        {
            var result = NumbersFunctions.SearchNumbers(1, 2);
            Assert.AreEqual(expected: new int[] { 1, 10, 10 }, result);
        }

        [Test]
        public void SearchNumbersWithEmptyResult()
        {
            var result = NumbersFunctions.SearchNumbers(30, 2);
            Assert.AreEqual(expected: new int[] { }, result);
        }
    }
}
