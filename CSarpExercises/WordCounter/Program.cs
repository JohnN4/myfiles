using System;
using System.IO;
using TextAnalzers.Lib;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
           string document = File.ReadAllText("mobydick.txt");
            
            WordSearcher searcher = new WordSearcher(document);

            while (PromptForSeachWord(out string searchWord))
            // CountWord(document, searchWord);
            {
                int count = searcher.GetWordCount(searchWord, false);
                Console.WriteLine($"the word {searchWord} was found {count} time(s).");
            }
        }

       /* static void CountWord(string document, string searchWord)
        {
            int count = 0;
            int ndx = document.IndexOf(searchWord);
            while (ndx >=0)
            {
                count++;
                ndx = document.IndexOf(searchWord, ndx + searchWord.Length);
            }
            Console.WriteLine($"the word {searchWord} was found {count} times.");
        }*/
        static bool PromptForSeachWord (out string searchWord)
        {
            Console.Write("Please enter a word to search for: ");
            searchWord = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(searchWord);
        }
    }
}
