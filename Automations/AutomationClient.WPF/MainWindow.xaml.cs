using Automation.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace AutomationClient.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += (o, e) =>
			{
				HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
				source.AddHook(new HwndSourceHook(WndProc));
			};
		}

		private void ProcessMessage(int message, IntPtr lParam)
		{
			string msg = "";
			switch(message)
			{
				case Messages.WM_SENDTEXT:
					output.Text = Messages.ExtractString(lParam);
					msg = "WM_SENDTEXT";
					break;
				case Messages.WM_CLEARTEXT:
					output.Text = string.Empty;
					msg = "WM_CLEARTEXT";
					break;
				case Messages.WM_REVERSETEXT:
					char[] letters = output.Text.ToCharArray();
					Array.Reverse(letters);
					output.Text = new string(letters);
					msg = "WM_REVERSETEXT";
					break;
				case Messages.WM_CLOSECLIENT:
					Close();
					return;
			}
			status.Text = $"Message '{msg}' processed.";
		}

		private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			switch(msg)
			{
				case Messages.WM_SENDTEXT:
				case Messages.WM_CLEARTEXT:
				case Messages.WM_REVERSETEXT:
				case Messages.WM_CLOSECLIENT:
					ProcessMessage(hwnd, msg, lParam);
					handled = true;
					break;
			}
			return IntPtr.Zero;
		}

		private static void ProcessMessage(IntPtr hwnd, int msg, IntPtr lParam)
		{
			MainWindow w = (MainWindow)HwndSource.FromHwnd(hwnd).RootVisual;
			w.ProcessMessage(msg, lParam);
		}

		private void SetText(IntPtr txtPtr)
		{
			string text = Marshal.PtrToStringUni(txtPtr);
			//output.Text = text;
		}
	}
}
