using System;
using System.Text;

namespace FileParser
{
    public static class StringExtension
    {
        public static String ReduceWhiteSpace(this String value)
        {
            var newString = new StringBuilder();
            bool previousIsWhitespace = false;

            if (value == null)
            {
                throw new ArgumentNullException("Income string is Null");
            }
            else if (value.Trim() == "")
            {
                throw new ArgumentException("Income string is empty string");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsWhiteSpace(value[i]))
                {
                    if (previousIsWhitespace)
                    {
                        continue;
                    }

                    previousIsWhitespace = true;
                }
                else
                {
                    previousIsWhitespace = false;
                }

                newString.Append(value[i]);
            }
            return newString.ToString();
        }

        public static String RemovePunctuations(this String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Income string is Null");
            }
            else if (value.Trim() == "")
            {
                throw new ArgumentException("Income string is empty string");
            }

            var newString = new StringBuilder();

            foreach (char c in value)
            {
                if (!char.IsPunctuation(c))
                {
                    newString.Append(c);
                }
            }

            return newString.ToString();
        }
    }
}
