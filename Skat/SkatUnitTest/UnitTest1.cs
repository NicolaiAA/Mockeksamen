using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skat;
using System;

namespace SkatUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Under200000() //Test: Hvis prisen er under 200.000
        {
            //Arrange
            int pris = 134000;
            int expected = 113900;


            //Act
            int actual = Skat.Afgift.BilAfgift(pris);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Over200000() //Test: hvis prisen er over 200.000
        {
            //Arrange
            int pris = 250000;
            int expected = 245000;

            //Act
            int actual = Skat.Afgift.BilAfgift(pris);

            //Assert
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void Under0() //Test af exception

        {
            //Arrange
            int pris = -5;

            //Act
            try
            {
                Afgift.BilAfgift(pris);
            }
            //Assert
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void ElBilUnder200000() //Test: hvis en elbil koster under 200000
        {
            //Arrange
            int pris = 150000;
            int expected = 25500;

            //Act
            int actual = Skat.Afgift.ElBilAfgift(pris);

            //Assert 
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void ElBilOver200000()
        {
            //Arrange
            int pris = 250000;
            int expected = 49000;

            //Act
            int actual = Skat.Afgift.ElBilAfgift(pris);

            //Assert
            Assert.AreEqual(actual, expected);
        } 
    }
}
