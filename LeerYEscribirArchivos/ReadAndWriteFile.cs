using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ReadWriteProgram
{
    class ReadAndWriteFile
    {
        public static void Result(string content, string routeFile, bool overwrite = true)
        {

            // Read a file into a string (this file must live in the same directory as the executable)
            string filename = "fileToAnalyze.txt";
            string inputString = File.ReadAllText(filename);

            // Convert our input to lowercase
            inputString = inputString.ToLower();

            // Define characters to strip from the input and do it
            string[] stripChars = { ";", ",", ".",":","-", "_", "^", "(", ")", "[", "]",
                        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };
            foreach (string character in stripChars)
            {
                inputString = inputString.Replace(character, "");
            }
            // Split on spaces into a List of strings
            List<string> wordList = inputString.Split(' ').ToList();
           
            // Create a new Dictionary object
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Loop over all over the words in our wordList...
            foreach (string word in wordList)
            {
                // ...check if the dictionary already has the word.
                if (dictionary.ContainsKey(word))
                {
                    // If we already have the word in the dictionary, increment the count of how many times it appears
                    dictionary[word]++;
                }
                else
                {
                    // Otherwise, if it's a new word then add it to the dictionary with an initial count of 1
                    dictionary[word] = 1;
                }  
            } // End of loop over each word in our input

            // Create a dictionary sorted by value (i.e. how many times a word occurs)
            var sortedDict = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            
            //Create a new file with results
            int totalCount = 1;
            StreamWriter sw = new StreamWriter(routeFile, !overwrite);
            sw.WriteLine("########################################################");           
            sw.WriteLine("################### Analysis results ###################");
            sw.WriteLine("########################################################");
            sw.WriteLine("  ");
            sw.WriteLine("   Nº  //   word   //  count  ");

			//Show the result in console
            Console.WriteLine("########################################################");
            Console.WriteLine("################### Analysis results ###################");
            Console.WriteLine("########################################################");
            Console.WriteLine("  ");
            Console.WriteLine("   Nº  //   word   //  count  ");

            //Puting the result into file and into the console
            foreach (KeyValuePair<string, int> pair in sortedDict)
            {                              
                sw.WriteLine(totalCount + "\t" + "    " + pair.Key + "\t" + "      " + pair.Value);
                Console.WriteLine(totalCount + "\t" + "    " + pair.Key + "\t" + "      " + pair.Value);
                totalCount++;
            }
			
			
            sw.WriteLine("  ");
            sw.WriteLine("########################################################");
            sw.WriteLine("########################################################");
            sw.Close();

            Console.WriteLine("  ");
            Console.WriteLine("########################################################");
            Console.WriteLine("########################################################");
        }       
    }
}
