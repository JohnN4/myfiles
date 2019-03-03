using ManagedInjector;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedInjectorRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			Injector.LogMessage("Starting the injection process...", false);
			var windowHandle = (IntPtr)Int64.Parse(args[0]);
			var assemblyName = args[1];
			var className = args[2];
			var methodName = args[3];
			Injector.Launch(windowHandle, assemblyName, className, methodName);
		}

		private static Process GetProcessFromWindowHandle(IntPtr windowHandle)
		{
			int processId;
			GetWindowThreadProcessId(windowHandle, out processId);
			if (processId == 0)
			{
				Injector.LogMessage(string.Format("could not get process for window handle {0}", windowHandle), true);
				return null;
			}

			var process = Process.GetProcessById(processId);
			if (process == null)
			{
				Injector.LogMessage(string.Format("could not get process for PID = {0}", processId), true);
				return null;
			}
			return process;
		}

		private static bool CheckInjectedStatus(Process process)
		{
			bool containsFile = false;
			process.Refresh();
			foreach (ProcessModule module in process.Modules)
			{
				if (module.FileName.Contains("ManagedInjector"))
				{
					containsFile = true;
				}
			}
			if (containsFile)
			{
				Injector.LogMessage(string.Format("Successfully injected into process {0} (PID = {1})", process.ProcessName, process.Id), true);
			}
			else
			{
				Injector.LogMessage(string.Format("Failed to inject for process {0} (PID = {1})", process.ProcessName, process.Id), true);
			}
			return containsFile;
		}

		[DllImport("user32.dll")]
		public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int processId);

	}
}
