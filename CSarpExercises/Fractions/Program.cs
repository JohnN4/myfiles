using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(25, 7);
            Fraction f2 = new Fraction(19, 14);
            Fraction f3 = f1.Add(f2);

            Console.WriteLine(f3);

            try
            {
                Fraction f4 = new Fraction(10, 0);//this throws an exception
                Console.WriteLine(f4);// skips
            }
            catch(Exception ex)// this catch it
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Finished");
            f3 = f1 + f2;
            Console.WriteLine(f1 * f2);
            Console.WriteLine(f1 / f2);
        }
    }
}
