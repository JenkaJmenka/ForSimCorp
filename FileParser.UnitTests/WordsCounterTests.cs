using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FileParser.UnitTests
{
    [TestClass]
    public class WordsCounterTests
    {
        [TestMethod]
        public void CountWords_CountWordsFromPreparedString_ReturnsDictionary()
        {
            //Arrange
            string str = "One Two Two Two Three Four Five";
            Dictionary<string, int> outcome = new Dictionary<string, int>();
            int wordsCountInString = 0;
            int wordsCountInOutcome = 0;
            //Act
            WordsCounter.CountWords(str, outcome);
            //Assert
            Assert.IsInstanceOfType(outcome, typeof(Dictionary<string,int>));
            foreach(var item in outcome)
            {
                wordsCountInOutcome+=item.Value;
            }
            int index = 0;
            while (index < str.Length)
            {
                // check if current char is part of a word
                while (index < str.Length && !char.IsWhiteSpace(str[index]))
                    index++;

                wordsCountInString++;

                // skip whitespace until next word
                while (index < str.Length && char.IsWhiteSpace(str[index]))
                    index++;
            }
            Assert.AreEqual(wordsCountInOutcome, wordsCountInString);
        }

        [TestMethod]
        public void CountWords_StringIsEmptyString_ArgumentException()
        {
            //Arrange
            var str = "";
            Dictionary<string, int> outcome = new Dictionary<string, int>();
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentException>(() => WordsCounter.CountWords(str,outcome));
        }

        [TestMethod]
        public void CountWords_StringIsNull_ArgumentNullException()
        {
            //Arrange
            string str = null;
            Dictionary<string, int> outcome = new Dictionary<string, int>();
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => WordsCounter.CountWords(str, outcome));
        }

        [TestMethod]
        public void CountWords_DictionaryIsNull_ArgumentNullException()
        {
            //Arrange
            string str = "Test String";
            Dictionary<string, int> outcome = null;
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => WordsCounter.CountWords(str, outcome));
        }


        [TestMethod]
        public void CountWords_CountWordsFromPreparedString_ReturnsList()
        {
            //Arrange
            string str = "One Two Three Three Three Three Four Five";
            List<KeyValuePair<string, int>> outcome = new List<KeyValuePair<string, int>>();
            int wordsCountInString = 0;
            int wordsCountInOutcome = 0;
            //Act
            WordsCounter.CountWords(str, outcome);
            //Assert
            Assert.IsInstanceOfType(outcome, typeof(List<KeyValuePair<string, int>>));
            foreach (KeyValuePair<string, int> item in outcome)
            {

                wordsCountInOutcome+=item.Value;
            }
            int index = 0;
            while (index < str.Length)
            {
                // check if current char is part of a word
                while (index < str.Length && !char.IsWhiteSpace(str[index]))
                    index++;

                wordsCountInString++;

                // skip whitespace until next word
                while (index < str.Length && char.IsWhiteSpace(str[index]))
                    index++;
            }
            Assert.AreEqual(wordsCountInOutcome, wordsCountInString);
        }

        [TestMethod]
        public void CountWords_StringIsEmptyStringList_ArgumentException()
        {
            //Arrange
            var str = "";
            Dictionary<string, int> outcome = new Dictionary<string, int>();
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentException>(() => WordsCounter.CountWords(str, outcome));
        }

        [TestMethod]
        public void CountWords_StringIsNullList_ArgumentNullException()
        {
            //Arrange
            string str = null;
            List<KeyValuePair<string, int>> outcome = new List<KeyValuePair<string, int>>();
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => WordsCounter.CountWords(str, outcome));
        }

        [TestMethod]
        public void CountWords_ListIsNullList_ArgumentNullException()
        {
            //Arrange
            string str = "Test String";
            List<KeyValuePair<string, int>> outcome = null;
            //Act

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => WordsCounter.CountWords(str, outcome));
        }
    }
}
