using System;
using System.Text;

// Exercise:  Use a loop to generate a string of the alphabet (lower-case):  "abcdefghijklmnopqrstuvwxyz"

namespace Alphabet
{
	class Program
	{
		static void Main(string[] args)
		{
            StringBuilder sbuilder = new StringBuilder();

            for (int i=97; i<123;i++)
            {
                char cApha = (char)i;
                sbuilder.Append(cApha);
            }
            Console.WriteLine(sbuilder);
		}
	}
}
