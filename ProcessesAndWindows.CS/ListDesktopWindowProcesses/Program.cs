using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

/*
 *	Use the Windows API functions EnumWindows and GetWindowThreadProcessId to list all of the Window processes on your desktop.

		Hint:  To get the address of a method (the first argument to EnumWindows), you’ll need to define a delegate with the appropriate signature.  
		If you are writing in Visual Basic, you will also need to use the Address Of operator.

		Hint:  Once you have the process id, use Process.GetProcessById to retrieve the needed process information.

		As for the ListProcesses exercise, write the application to output each unique window/process name and the number of instances running.  
		Order the output by the # running processes, descending. 3671086
*/

namespace ListDesktopWindowProcesses
{
	class Program
	{
        public delegate bool CallBackPtr(int hwnd, int lParam);
        public class EnumReport
        {
            [DllImport("user32.dll")]
            public static extern int EnumWindows(CallBackPtr callPtr, int lPar);
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);  
            
            public static Process GetWindowThreadProcess(int hwnd)
            {
                int processID;
                GetWindowThreadProcessId(hwnd, out processID);
                try
                {
                    return Process.GetProcessById(processID);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
            static Dictionary<string, int> processDict = new Dictionary<string, int>();

            public static bool Report(int hwnd, int lParam)
            {
                string procName = GetWindowThreadProcess(hwnd).ProcessName;
                if (processDict.ContainsKey(procName))
                    processDict[procName]++;
                else
                    processDict.Add(procName, 1);
                return true;
            }

            public static void PrintDict()
            {
                foreach (KeyValuePair<string, int> x in processDict.OrderByDescending(x => x.Value))
                    Console.WriteLine(x);
            }
        }
        static void Main(string[] args)
        {
            CallBackPtr callBackPtr = new CallBackPtr(EnumReport.Report);
            EnumReport.EnumWindows(callBackPtr, 0);
            EnumReport.PrintDict();
        }
    }
}