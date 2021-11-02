using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile002
{
    public class FileDemo
    {
        public static void ReadDemo(string file = "jamaica.txt")
        {
            string path = "C:/Users/pgmar/Downloads";

            string fileToRead = $"{path}/{file}";

            //  Console.WriteLine($"Reading File: {fileToRead}");

            try
            {
                using (StreamReader sr = new StreamReader(fileToRead))
                {

                    //  Console.WriteLine($"Starting to read {fileToRead}");

                    string line;

                    while ((line = sr.ReadLine()) is not null)
                    {
                        string[] splitData = line.Split(":");
                        // Console.WriteLine($"{splitData[0]}\t\t\t{splitData[1]}");

                        string heroName = String.Format("{0,-20}", splitData[0]);
                        Console.WriteLine($"{heroName}\t{splitData[1]}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToRead} file could not be read:");
                Console.WriteLine(e.Message);
            }

            FileDemo.OutputSeparator();

        }

        public static void WriteDemo(string file, string[] heroes)
        {

            string path = "C:/Users/pgmar/Downloads";

            string fileToWrite = $"{path}/{file}";

            try
            {
                using (StreamWriter sw = new StreamWriter(fileToWrite))
                {
                    foreach (string hero in heroes)
                    {

                        sw.WriteLine(hero);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} file could not be written");
                Console.WriteLine(e.Message);

            }

        }


        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/padding
        public static void OutputSeparator()
        {
            Console.WriteLine("=".PadRight(80, '='));
        }

        public static char[] SplitAsString(string stringToSplit)
        {

            char[] characters = stringToSplit.ToCharArray();

            foreach (char c in characters)
            {
                Console.Write($" {c} ");

            }
            Console.WriteLine();


            return characters;

            // faster way is to just write:
            //return stringToSplit.ToCharArray();


        }

    }
}
