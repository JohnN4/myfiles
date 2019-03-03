using Automation.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace Hijacker
{
	/// <summary>
	/// Interaction logic for WindowFinder.xaml
	/// </summary>
	public partial class WindowFinder : UserControl
	{
		private bool IsDragging { get; set; }
		private Cursor _crosshairsCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Hijacker.Resources.CrosshairsCursor.cur"));
		private WindowInfo _windowUnderCursor;
		private IntPtr _feedbackWindowHandle;
		private FeedbackWindow _visualFeedback;
		Point _myOffset;

		public WindowFinder()
		{
			InitializeComponent();
		}

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			BeginSearch();
			e.Handled = true;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (!IsDragging) return;
			if (Mouse.LeftButton == MouseButtonState.Released)
			{
				EndSearch();
				return;
			}
			IntPtr hwnd = NativeMethods.GetWindowUnderMouse();
			if (hwnd != _windowUnderCursor.Hwnd)
			{
				System.Diagnostics.Debug.WriteLine(hwnd);
				_windowUnderCursor = new WindowInfo(hwnd);
			}
			ShowVisualFeedback();
			UpdateFeedbackWindowPosition(e.GetPosition(this));
		}

		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			WindowInfo w = _windowUnderCursor;
			EndSearch();
			if (w != null && !w.IsCurrentProcess)
			{
				WindowedProcessType type = GetProcessType(w);
				Type winType = null;
				switch(type)
				{
					case WindowedProcessType.WPF:
						winType = typeof(InjectedWindow);
						break;
					case WindowedProcessType.Forms:
						winType = typeof(InjectedFormsWindow);
						break;
				}
				Inject(w.Hwnd, winType);
			}
		}

		private void BeginSearch()
		{
			CaptureMouse();
			IsDragging = true;
			Cursor = _crosshairsCursor;
			_windowUnderCursor = new WindowInfo(NativeMethods.GetWindowUnderMouse());
			finder.Visibility = Visibility.Hidden;
			_myOffset = TransformToAncestor(Application.Current.MainWindow).Transform(new Point());
			System.Diagnostics.Debug.WriteLine(WindowInfo.CurrentProcessId);
		}

		private void EndSearch()
		{
			ReleaseMouseCapture();
			IsDragging = false;
			Cursor = Cursors.Arrow;
			finder.Visibility = Visibility.Visible;
			RemoveVisualFeedback();
			_windowUnderCursor = null;
		}

		private void ShowVisualFeedback()
		{
			if (_visualFeedback == null)
			{
				_visualFeedback = new FeedbackWindow();
				_visualFeedback.Owner = Application.Current.MainWindow;
			}
			if (!_visualFeedback.IsVisible)
			{
				_visualFeedback.Show();
				if (_feedbackWindowHandle == IntPtr.Zero)
				{
					_feedbackWindowHandle = new WindowInteropHelper(_visualFeedback).Handle;
				}
			}
			_visualFeedback.TargetName = _windowUnderCursor.Title;
			_visualFeedback.IsTargetValid = !_windowUnderCursor.IsCurrentProcess;
		}

		private void RemoveVisualFeedback()
		{
			if (_visualFeedback != null && _visualFeedback.IsVisible) _visualFeedback.Hide();
		}

		private void UpdateFeedbackWindowPosition(Point p)
		{
			if (_visualFeedback != null)
			{
				_visualFeedback.Left = p.X + _myOffset.X + 30;
				_visualFeedback.Top = p.Y + _myOffset.Y + 30;
			}
		}

		private enum WindowedProcessType { Win32, Forms, WPF };

		private WindowedProcessType GetProcessType(WindowInfo info)
		{
			bool hasWPF = false, hasForms = false;
			foreach (var module in info.Modules)
			{
				if
							(
								module.szModule.StartsWith("PresentationFramework", StringComparison.OrdinalIgnoreCase) ||
								module.szModule.StartsWith("PresentationCore", StringComparison.OrdinalIgnoreCase) ||
								module.szModule.StartsWith("wpfgfx", StringComparison.OrdinalIgnoreCase)
							)
					hasWPF = true;
				if (module.szModule.StartsWith("System.Windows.Forms", StringComparison.OrdinalIgnoreCase)) hasForms = true;
			}
			if (!hasForms && !hasWPF) return WindowedProcessType.Win32;
			if (hasWPF && !hasForms) return WindowedProcessType.WPF;
			if (hasForms && !hasWPF) return WindowedProcessType.Forms;
			// crap shoot.  WPF and Forms can co-exist:
			return WindowedProcessType.WPF;
		}

		private void Inject(IntPtr hwnd, Type winType)
		{
			Assembly a = winType.Assembly;
			string className = winType.FullName;
			string location = a.Location;
			if (location.IndexOf(" ") > 0) location = string.Concat("\"", location, "\"");
			string args = string.Concat(hwnd, " ", location, " ", className, " ", "Inject");
			RunManagedInjector(args);
		}

		private static void RunManagedInjector(string arguments)
		{
			const string ManagedInjectorRunner = "ManagedInjectorRunner";
			string runnerFolder = Path.Combine(Environment.CurrentDirectory, $"../../../{ManagedInjectorRunner}/bin/Debug");
			runnerFolder = Path.GetFullPath(runnerFolder);
			string runner = Path.Combine(runnerFolder, ManagedInjectorRunner + ".exe");
			ProcessStartInfo psi = new ProcessStartInfo
			{
				Arguments = arguments,
				FileName = runner,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden
			};
			Process.Start(psi);
		}
	}
}
