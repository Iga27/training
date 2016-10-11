using System;
using RootLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task2.Tests
{
    [TestClass]
    public class RootTests
    {
        [TestMethod]
        public void CalculateRoot_7and3_returned1_9129()
        {
            //arrange
            double a = 7;
            int n = 3;
            double delta = 0.001; 
            double expected = 1.9129;

            //act
            double actual = Root.CalculateRoot(a, n);

            //assert
            Assert.AreEqual(expected, actual,delta,"Root of {0} should have been {1}",a,expected);
        }

        [TestMethod]
        public void CalculateRoot_IsEqualToMathPow()
        {
            //arrange
            double a = 7.0;
            int n = 3;
            double delta = 0.001;
            double expected = Math.Pow(a, (1.0 / n));

            //act
            double actual = Root.CalculateRoot(a, n);

            //assert
            Assert.AreEqual(expected, actual,delta);
        }

    }
}
