using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomgame1
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int randomN = rand.Next(1, 1001);
            int count = 1;
            int N = count;
           
            Console.WriteLine("Guess a Number Between 1 and 1000");
            
            
            while(true)
            {
                int guess = Convert.ToInt32(Console.ReadLine());

               
                 if (guess > randomN)
                {
                    Console.WriteLine("Too Big. try again");
                        ++N;          
                }else if (guess < randomN)
                {
                    Console.WriteLine("Too Small. try again");
                    N++;
                }else if (guess == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"That's Correct. the number was {randomN}");
                    Console.WriteLine($" You Found the Number in Just {N} try(ies)");
                    return;
                }
                
            }


          
        }
    }
}