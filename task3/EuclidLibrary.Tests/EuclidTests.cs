using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EuclidLibrary;
 

namespace EuclidLibrary.Tests
{
    [TestClass]
    public class EuclidTests
    {
        private Euclid obj;

        [TestInitialize]
       public void TestInitialize()
        {
            obj = new Euclid();
        }
        [TestMethod]
        public void IsGcdTest()
        {
            //arrange
            int input1 = 12;
            int input2 = 6;
            int expected = 6;

            //act
            int actual = obj.gcd(input1,input2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(NegativeValueException),"Exception wasn't thrown")]
         [TestMethod]
        public void Gcd_Exception_Test()
        {
            //arrange
            int input1 = -12;
            int input2 = 6;

            //act
            int actual = obj.gcd(input1, input2);          
        }

         [TestMethod]
        public void IsGcdBinTest()
        {
            //arrange
            int input1 = 12;
            int input2 = 0;
            int expected = 12;

            //act
            int actual = obj.gcdBin(input1, input2);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
