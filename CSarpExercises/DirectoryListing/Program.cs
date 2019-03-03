using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryListing
{
    class Program
    {
        const string FOLDER = @"C:\Users\John N\Desktop\flash\doc";
        static string searchWord;
        static List<string> foundFiles = new List<string>();

        static void Main(string[] args)
        {

            //Console.Write("Enter the filename to search: ");
            //searchWord = Console.ReadLine();


            //string[] files = Directory.GetFiles(FOLDER);
            //foreach (string fpath in files) Console.WriteLine(fpath);
            //string[] folders = Directory.GetDirectories(FOLDER);
            // foreach (string folder in folders) Console.WriteLine(folder);

            /* ListFilesInFolder(FOLDER);
             if(foundFiles.Count>0)
             {

                 Console.WriteLine($"Found {foundFiles.Count} matching file(s): ");
                 foreach (string fpath in foundFiles) Console.WriteLine(fpath);
             }*/

            FindFile(FOLDER, CompareLargest);
            Console.WriteLine($"The largest file is {fileToFind.FullName}");

            FindFile(FOLDER, (fx, fy) =>
                    {
                if (fx.Length < fy.Length) return 1;
                if (fx.Length > fy.Length) return -1;
                return 0;
            });
            Console.WriteLine($"The smallest file is {fileToFind.FullName}");

        }

        static void ListFilesInFolder(string folder)
        {
            Console.WriteLine();
            Console.WriteLine($"List for folder '{folder}':");

            foreach (string filePath in Directory.GetFiles(folder))
            {

                string fileName = Path.GetFileName(filePath);
                Console.WriteLine("\t" + fileName);
                //Console.WriteLine("\t" + Path.GetFileName(filePath));
                if (fileName.Contains(searchWord))
                {
                    foundFiles.Add(filePath);
                }

            }

            foreach (string subFolder in Directory.GetDirectories(folder))
            {
                ListFilesInFolder(subFolder);
            }


        }

        static FileInfo largestFileInfo = null;
        static void FindLargestFIle(string folder)
        {
            foreach (string fpath in Directory.GetFiles(folder))
            {
                if(largestFileInfo==null)
                {
                    largestFileInfo = new FileInfo(fpath);
                }else
                {
                    FileInfo test = new FileInfo(fpath);
                    if(test.Length>largestFileInfo.Length)
                    {
                        largestFileInfo = test;
                    }
                }


            }

            foreach (string subFolder in Directory.GetDirectories(folder))
                FindLargestFIle(subFolder);
        }

        static FileInfo fileToFind;
        static void FindFile(string folder, Comparison<FileInfo>test)
        {
            foreach (string fpath in Directory.GetFiles(folder))
            {
                if (fileToFind == null) fileToFind = new FileInfo(fpath); else
                {
                    FileInfo nextFile = new FileInfo(fpath);
                    if (test(nextFile, fileToFind) > 0) fileToFind = nextFile;

                    
                }
            }

            foreach (string subFolder in Directory.GetDirectories(folder))
                FindFile(subFolder, test);
        }

        static int CompareLargest(FileInfo x, FileInfo y)
        {
            if (x.Length > y.Length) return 1;
            if (x.Length < y.Length) return -1;
            return 0;
        }
    }
}
