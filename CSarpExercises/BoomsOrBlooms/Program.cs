using System;
using System.Threading;

namespace BoomsOrBlooms
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Please Enter boom or bloom: ");
                string input = Console.ReadLine(). ToLower();
                if (input != "boom" && input != "bloom") continue;
                Countdown(5);
                if (input == "boom") FlashScreen(ConsoleColor.Red, ConsoleColor.Yellow);
                else FlashScreen(ConsoleColor.Green, ConsoleColor.Blue);

            }
           
        }

        static void Countdown(int nSeconds)
        {
            while(nSeconds >0)
            {
                Console.WriteLine(nSeconds--);
                Thread.Sleep(1000);

            }
        }

        static void FlashScreen( ConsoleColor color1, ConsoleColor color2)
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.BackgroundColor = color1;
                Console.Clear();
                Thread.Sleep(500);
                Console.BackgroundColor = color2;
                Console.Clear();
                Thread.Sleep(500);
            }
            Console.ResetColor();
            Console.Clear();
        }
    }
}
