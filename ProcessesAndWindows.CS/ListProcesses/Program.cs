using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListProcesses
{
	class Program
	{
		/*
		 * Write a Console application that lists the names of all active processes.
		 * 
		 * You may notice that many processes occur numerous times.
		 * 
		 * Modify the application to output each unique process name and the number of instances running.  Order the output by the # running processes, descending.
		*/

		static void Main(string[] args)
		{


            Process[] localAll = Process.GetProcesses();


            Dictionary<string, int> pcs = new Dictionary<string, int>();


            foreach (Process c in localAll)
            {

                string holder = c.ProcessName;

                if (!pcs.ContainsKey(holder))
                {
                    pcs.Add(holder, 1);
                }
                else
                {
                    pcs[holder]++;
                }
                foreach (string key in pcs.Keys)
                {
                    //Console.WriteLine($"{key}: {pcs[key]}");
                }
                foreach (KeyValuePair<string, int> decs in pcs.OrderByDescending(k => k.Value))
                {
                    Console.WriteLine($"{decs.Key}: {decs.Value}");
                }


                //Console.WriteLine(c);


                //Console.WriteLine("{0},{1}", c,
                // c.ToString().Count());

            }
        }
	}
}
