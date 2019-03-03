using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfCircle2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (TryReadNumber(out double number))
                Console.WriteLine($"the area is {CalculateCircleArea(number):F4}.");


            /*bool finished = false;
            while(!finished)
            {
                bool success = TryReadNumber(out double number);
                if (success)
                {
                    Console.WriteLine($"the area is {CalculateCircleArea(number):F4}.");
                }
                else finished = true;
            }*/
        }

        static double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        static bool TryReadNumber(out double number)
        {
            Console.Write("please enter a number Radius: ");
            string sNumber = Console.ReadLine();
            return (double.TryParse(sNumber, out number) && number > 0);//short way to do it
            
            /*if(double.TryParse(sNumber, out number) && number>0)   long way to do it && number>0 is a check for -number
            {
                return true;
            }
            else
            {
                return false;
            }*/
            
            ////////////////////////////////////////////////////////////////
            
            /*try                           another way to do it
            {
                number = double.Parse(sNumber);
                return true;
            }
            catch
            {

            }
            number = 0;
            return false;*/

        }
    }
}
