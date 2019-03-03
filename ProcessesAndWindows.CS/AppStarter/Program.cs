using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppStarter
{
	class Program
	{
		// Write a Console application that starts another application, optionally passing arguments to it.

		// Your Console application will require that at least one argument is passed to it - the path to the executable that it will start.
		// If additional arguments are passed to your console application, those will be passed as a group to the executable that is being started.

		// Running your program like this:
		// AppStarter "c:\windows\system32\notepad.exe" "c:\Users\Joseph\Documents\Jabberwocky.txt" /A
		// Would cause notepad to run with Jabberwocky.txt opened as ANSI.
	
		static int Main(string[] args)
		{
            // we are opening a app and using that app to open a word doc. the first arg is the app, the sound arg is the one we pass it.
            //process.start(look up)

			//throw new NotImplementedException();

            if (args.Length < 1)
            {
                Console.WriteLine("No Argument Provided.");
                return -1;
            }try
            {
                if (args.Length==1)
                {
                    Process.Start(args[0]);
                    return 0;
                }
                else
                {
                    
                   
                    //Process.Start(args[0], args[1]);
                    Process.Start(args[0],string.Join(" ",args.Skip(1)));
                }
              

                return 0;
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return -1;
            }
		}
	}
}
