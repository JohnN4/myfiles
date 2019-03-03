using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Automation.Common
{
	public static class Messages
	{
		private const int WM_APP = 0x8000;

		public const int WM_SENDTEXT = WM_COPYDATA;
		public const int WM_REVERSETEXT = WM_APP + 2;
		public const int WM_CLEARTEXT = WM_APP + 3;
		public const int WM_CLOSECLIENT = WM_APP + 4;

		public static void SendMessage(IntPtr hwnd, int message)
		{
			NativeMethods.SendMessage(hwnd, message, 0, IntPtr.Zero);
		}

		public static void SendMessage(IntPtr hwnd, int message, string text)
		{
			
			byte[] data = Encoding.Default.GetBytes(text);
			COPYDATASTRUCT cds = new COPYDATASTRUCT
			{
				dwData = new IntPtr(100),
				cbData = data.Length + 1,
				lpData = Marshal.StringToHGlobalAnsi(text)
			};

			IntPtr ptrCDS = IntPtr.Zero;
			try
			{
				ptrCDS = Marshal.AllocCoTaskMem(Marshal.SizeOf(cds));
				Marshal.StructureToPtr(cds, ptrCDS, false);
				NativeMethods.SendMessage(hwnd, WM_COPYDATA, 0, ptrCDS);
			}
			finally
			{
				if (ptrCDS != IntPtr.Zero) Marshal.FreeCoTaskMem(ptrCDS);
			}
		}


		private const int WM_COPYDATA = 0x4A;

		/// <summary>
		/// Contains data to be passed to another application by the WM_COPYDATA message.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct COPYDATASTRUCT
		{
			/// <summary>
			/// User defined data to be passed to the receiving application.
			/// </summary>
			public IntPtr dwData;

			/// <summary>
			/// The size, in bytes, of the data pointed to by the lpData member.
			/// </summary>
			public int cbData;

			/// <summary>
			/// The data to be passed to the receiving application. This member can be IntPtr.Zero.
			/// </summary>
			public IntPtr lpData;
		}

		public static string ExtractString(IntPtr wmCopyLParam)
		{
			COPYDATASTRUCT cds = Marshal.PtrToStructure<COPYDATASTRUCT>(wmCopyLParam);
			return Marshal.PtrToStringAnsi(cds.lpData);
		}

	}
}
