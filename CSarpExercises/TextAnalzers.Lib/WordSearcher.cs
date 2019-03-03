using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalzers.Lib
{
    public class WordSearcher
    {
        public static WordSearcher FromFile(string filePath)
        {
            return new WordSearcher(File.ReadAllText(filePath));
        }

        public WordSearcher(string document)
        {
            if (string.IsNullOrEmpty(document)) throw new ArgumentNullException(nameof(document));
            Document = document;
        }

        public string Document { get; private set; }

        public int GetWordCount(string searchText, bool isCaseSensitive = true) // optional method
        {
            StringComparison scomp = isCaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            int count = 0;
            int ndx = Document.IndexOf(searchText, scomp);
            while(ndx >=0)
            {
                count++;
                ndx = Document.IndexOf(searchText, ndx + searchText.Length, scomp);
            }
            return count;
        }


    }
   
}
