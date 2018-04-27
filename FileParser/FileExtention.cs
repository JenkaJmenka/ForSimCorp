using System;
using System.IO;
using System.Text;

namespace FileParser
{
    public static class FileExtention
    {
        public static String ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                byte[] b = File.ReadAllBytes(path);
                UTF8Encoding temp = new UTF8Encoding(true);
                return temp.GetString(b).Replace("\0", string.Empty).Replace("\n", " ").Replace("\r", " ");
            }
            else throw new FileNotFoundException("File does not exists.");
        }

        public static void WriteToFile(string path, string initialString)
        {
            if (initialString == null)
            {
                throw new ArgumentNullException("Income string is Null");
            }
            else if (initialString.Trim() == "")
            {
                throw new ArgumentException("Income string is empty string");
            }
            if (File.Exists(path))
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(initialString);
                    fs.Write(info, 0, info.Length);
                }
            }
            else throw new FileNotFoundException("File does not exists.");
        }

    }
}
