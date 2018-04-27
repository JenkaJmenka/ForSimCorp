using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FileParser.UnitTests
{
    [TestClass]
    public class FileExtentionTests
    {
        [TestMethod]

        public void ReadFromFile_FileExists_ReturnsString()
        {
            //Arrange
            var filePath = "sample.txt";
            //Act
            var result = FileExtention.ReadFromFile(filePath);
            //Assert
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(result.IndexOfAny(new char[] { '\n', '\r', '\0' }), -1);
        }

        [TestMethod]
        public void ReadFromFile_FileDoesNotExists_ReturnsFileNotFoundException()
        {
            //Arrange
            var filePath = "sample_of_non_existing_file.txt";
            //Act

            //Act => Assert
            Assert.ThrowsException<FileNotFoundException>(() => FileExtention.ReadFromFile(filePath));
        }

        [TestMethod]
        public void WriteToFile_FileDoesNotExists_ReturnsFileNotFoundException()
        {
            //Arrange
            var filePath = "sample_of_non_existing_file.txt";
            var str = "Test string";
            //Act

            //Act => Assert
            Assert.ThrowsException<FileNotFoundException>(() => FileExtention.WriteToFile(filePath, str));
        }

        [TestMethod]
        public void WriteToFile_StringIsNull_ReturnsArgumentNullException()
        {
            //Arrange
            var filePath = "sample.txt";
            string str = null;
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => FileExtention.WriteToFile(filePath, str));
        }

        [TestMethod]
        public void WriteToFile_StringIsNull_ReturnsArgumentException()
        {
            //Arrange
            var filePath = "sample.txt";
            string str = "";
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentException>(() => FileExtention.WriteToFile(filePath, str));
        }
    }
}
