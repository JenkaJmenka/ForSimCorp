using System;
using System.Collections.Generic;

namespace FileParser
{
    public static class WordsCounter
    {
        private static IEnumerable<string> SplitStringIntoWords(string str)
        {
            foreach (var word in str.Split(' '))
            {
                yield return word;
            }
        }

        private static void AddOrReplace<T, U>(List<KeyValuePair<T, U>> list, KeyValuePair<T, U> item) where T : IEquatable<T>
        {
            var target_idx = list.FindIndex(n => n.Key.Equals(item.Key));
            if (target_idx != -1)
            {
                list[target_idx] = item;
            }
            else
            {
                list.Add(item);
            }
        }

        public static void CountWords(string str, Dictionary<string, int> wordsCombinations)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Income string parameter is null");
            }
            else if (str.Trim() == "")
            {
                throw new ArgumentException("Income string is empty string");
            }
            if (wordsCombinations == null)
            {
                throw new ArgumentNullException("Dictionary for storing the result of counting is null");
            }

            var listOfWords = SplitStringIntoWords(str);
            foreach (string word in listOfWords)
            {
                if (wordsCombinations.ContainsKey(word))
                {
                    wordsCombinations[word] += 1;
                }
                else
                {
                    wordsCombinations.Add(word, 1);
                }
            }
        }

        public static void CountWords(string str, List<KeyValuePair<string, int>> wordsCombinations)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Income string parameter is null");
            }
            else if (str.Trim() == "")
            {
                throw new ArgumentException("Income string is empty string");
            }
            if (wordsCombinations == null)
            {
                throw new ArgumentNullException("List for storing the result of counting is null");
            }

            var listOfWords = SplitStringIntoWords(str);
            KeyValuePair<string, int> combination;

            foreach (string word in listOfWords)
            {
                combination = wordsCombinations.Find(x => x.Key == word);
                if (combination.Value == 0)
                {
                    wordsCombinations.Add(new KeyValuePair<string, int>(word, 1));
                }
                else
                {
                    int count = combination.Value + 1;
                    AddOrReplace(wordsCombinations, new KeyValuePair<string, int>(combination.Key, count));
                }

            }
        }
    }
}
