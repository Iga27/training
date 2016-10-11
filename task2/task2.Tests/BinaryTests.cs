using System;
using BinLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task2.Tests
{
    [TestClass]
    public class BinaryTests
    {
        [TestMethod]
        public void RightConvertingTest()
        {

            //arrange
           int dec=10;
           string expected = "1010";

            //act
           string actual = Binary.ToBinaryString(dec);

            //assert
           Assert.AreEqual(expected, actual);     
        }
    }
}
