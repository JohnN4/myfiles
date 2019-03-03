using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Automation.Common
{
	public class WindowInfo
	{
		public static readonly int CurrentProcessId = Process.GetCurrentProcess().Id;
		private List<NativeMethods.MODULEENTRY32> _modules;
		private string _title;
		public WindowInfo(IntPtr hwnd)
		{
			Hwnd = hwnd;

			Process = NativeMethods.GetWindowThreadProcess(Hwnd);
			ProcessId = Process.Id;
			if (Process != null)
			{
				_title = Process.MainWindowTitle;
			}
			if (string.IsNullOrEmpty(_title))
			{
				_title = Process.ProcessName;
			}
		}

		public IntPtr Hwnd { get; private set; }
		public int ProcessId { get; private set; }
		public string Title => _title;
		public bool IsCurrentProcess => Process == null ? false : Process.Id == CurrentProcessId;

		private Process Process { get; set; }
		public IEnumerable<NativeMethods.MODULEENTRY32> Modules
		{
			get
			{
				if (_modules == null) LoadModules();
				return _modules.AsReadOnly();
			}
		}

		private void LoadModules()
		{
			_modules = new List<NativeMethods.MODULEENTRY32>();
			NativeMethods.GetWindowThreadProcessId(Hwnd, out int processId);
			var hModuleSnap = NativeMethods.CreateToolhelp32Snapshot(NativeMethods.SnapshotFlags.Module | NativeMethods.SnapshotFlags.Module32, processId);
			if (!hModuleSnap.IsInvalid)
			{
				using (hModuleSnap)
				{
					var me32 = new NativeMethods.MODULEENTRY32();
					me32.dwSize = (uint)Marshal.SizeOf(me32);
					if (NativeMethods.Module32First(hModuleSnap, ref me32))
					{
						do
						{
							_modules.Add(me32);
						} while (NativeMethods.Module32Next(hModuleSnap, ref me32));
					}
				}
			}
		}

		public override string ToString() => Title;

	}
}
