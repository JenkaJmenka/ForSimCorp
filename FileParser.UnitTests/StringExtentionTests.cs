using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileParser.UnitTests
{
    [TestClass]
    public class StringExtentionTests
    {
        [TestMethod]
        public void ReduceWhiteSpace_StringIsNotNull_ReturnsStringWithoutExtraSpaces()
        {
            //Arrange
            var str = "Go   do that     thing that you   do so well.";
            //Act
            var result = StringExtension.ReduceWhiteSpace(str);
            //Assert
            Assert.AreEqual(result.IndexOf("  "), -1);
        }

        [TestMethod]
        public void ReduceWhiteSpace_StringIsEmptyString_ArgumentException()
        {
            //Arrange
            var str = "";
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentException>(() => StringExtension.ReduceWhiteSpace(str));
        }

        [TestMethod]
        public void ReduceWhiteSpace_StringIsNull_ArgumentNullException()
        {
            //Arrange
            string str = null;
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => StringExtension.ReduceWhiteSpace(str));
        }

        [TestMethod]
        public void RemovePunctuations_StringIsNull_ArgumentNullException()
        {
            //Arrange
            string str = null;
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => StringExtension.RemovePunctuations(str));
        }

        [TestMethod]
        public void RemovePunctuations_StringIsEmptyString_ArgumentException()
        {
            //Arrange
            string str = "";
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentException>(() => StringExtension.RemovePunctuations(str));
        }

        [TestMethod]
        public void RemovePunctuations_StringContainsPunctuations_ReturnsStringWithoutPunctuations()
        {
            //Arrange
            string str = "Test string, which contains some !@#$$%^&*()_}{\'|}{?>< punktuation...!";
            //Act
            var result = StringExtension.RemovePunctuations(str);
            //Act => Assert
            Assert.IsFalse(result.Any(char.IsPunctuation));
        }
    }
}
