using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//Find all Of the unique characters In Moby Dick.
//Use the above To create a simple cypher
//1. Randomize the array of unique characters
//2. Rewrite Moby Dick using the randomized array as a map.
//3. Demonstrate the you can also decode the encrypted text.

namespace Cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string document = File.ReadAllText("mobydick.txt");
            char[] unique = FindUniqueCharacters(document);
            char[] copy = unique.Clone() as char[];
            Shuffle(copy);
            Dictionary<char, char> key = new Dictionary<char, char>(), revKey = new Dictionary<char, char>();
            for (int i = 0; i < unique.Length; i++)
            {
                key.Add(unique[i], copy[i]);
                revKey.Add(copy[i], unique[i]);
            }
            StringBuilder translation = new StringBuilder(document.Length);
            foreach (char c in document)
            {
                translation.Append(key[c]);
                //translation.Append(revKey[c]);
                //translation.Replace(key[c], revKey[c]);
            }
            File.WriteAllText("encryptded.txt", translation.ToString());
            
            string encryptdoc = File.ReadAllText("encryptded.txt");


            StringBuilder revtranslation = new StringBuilder(document.Length);
            foreach (char x in encryptdoc)
            {
                revtranslation.Append(revKey[x]);
            }

            File.WriteAllText("decryptded.txt", revtranslation.ToString());


            //StringBuilder revtranslation = new StringBuilder(document.Length);
            //foreach (char x in encryptdoc)
            //{
            //    revtranslation.Append(revKey[x]);
            //}

            //File.WriteAllText("decryptded.txt", translation.ToString());
        }





        static void Shuffle(char[] array)
        {
            Random r = new Random();
            for (int i = array.Length - 1; i > 0; --i)
            {
                int j = r.Next(0, i + 1);
                char c = array[i];
                array[i] = array[j];
                array[j] = c;

            }


        }
        static char[] FindUniqueCharacters(string document)
        {
            HashSet<char> unique = new HashSet<char>();
            foreach (char c in document) unique.Add(c);
            return unique.ToArray();
        }
    }
}