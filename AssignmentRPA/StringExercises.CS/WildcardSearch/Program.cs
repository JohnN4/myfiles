using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WildcardSearch
{
    //Use Regex To perform wildcard searches
    //	Again, use mobydick.txt as the search document.
    // In a loop, ask the user to enter a search phrase.
    // Provide instructions :    _ (underscore) represents a single character; * (asterisk) represents zero Or more characters.
    // Run the search. If no results are found output “No results found.”
    // Otherwise, output the number of results found followed by the position in the document And the matched text for each match.

    class Program
    {
        static void Main(string[] args)
        {
            string mobyDick = File.ReadAllText("mobydick.txt");


            //_os used to match a single charact like wh_le(while/ it would search how many times it appear on the text
            //* is use when when miss 2 or more character like (wh*e)=>(while).

            Console.WriteLine("Enter serach term. Use _ for a single character, * for a zero Or more characters: ");
            string uInput = Console.ReadLine();
            int count = 0;

            uInput = uInput.Replace("_", ".");
            uInput = uInput.Replace("%", ".*");

            Regex myReg = new Regex(uInput, RegexOptions.Compiled);

            //copy from GroupCollection example from microsoft
            MatchCollection matches = myReg.Matches(mobyDick);
            foreach (Match match in matches)
            {
                count++;
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at {1}", groups[0].Value, groups[0].Index);
            }



            if (count == 0)
            {
                Console.WriteLine("No results found");
            }
            else
            {
                Console.WriteLine($"It was found: {count} time(s)");
            }

        }
    }
}