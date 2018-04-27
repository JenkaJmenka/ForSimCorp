using System;
using System.Collections.Generic;
using System.IO;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetTempFileName();
            string initialString = "Go   do that     thing that you   do so well.";
            string resultString = null;

            List<KeyValuePair<string, int>> wordsCombinations_List = new List<KeyValuePair<string, int>>();
            Dictionary<string, int> wordsCombinations_Dictionary = new Dictionary<string, int>();

            try
            {
                FileExtention.WriteToFile(path, initialString);
                resultString = FileExtention.ReadFromFile(path);
                resultString = StringExtension.RemovePunctuations(resultString);
                resultString = StringExtension.ReduceWhiteSpace(resultString);
                WordsCounter.CountWords(resultString, wordsCombinations_Dictionary);
                WordsCounter.CountWords(resultString, wordsCombinations_List);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("The income string is: " + "'" + initialString + "'");
            Console.WriteLine("This is the result of using Dictionary");
            DisplayCollection(wordsCombinations_Dictionary);
            Console.WriteLine("This is the result of using List");
            DisplayCollection(wordsCombinations_List);

            Console.WriteLine("Below the example of using this methods for parsing small text!");
            wordsCombinations_List.Clear();
            wordsCombinations_Dictionary.Clear();

            resultString = null;

            try
            {
                resultString = FileExtention.ReadFromFile(@"sample.txt");
                resultString = StringExtension.RemovePunctuations(resultString);
                resultString = StringExtension.ReduceWhiteSpace(resultString);
                WordsCounter.CountWords(resultString, wordsCombinations_Dictionary);
                WordsCounter.CountWords(resultString, wordsCombinations_List);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("This is the result of using Dictionary");
            DisplayCollection(wordsCombinations_Dictionary);
            Console.WriteLine("This is the result of using List");
            DisplayCollection(wordsCombinations_List);
        }

        static void DisplayCollection<T, U>(IEnumerable<KeyValuePair<T, U>> collection) where T : IEquatable<T>
        {
            foreach (var item in collection)
                Console.WriteLine(item.Value + ": " + item.Key);
        }
    }
}