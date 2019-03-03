using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Hijacker
{
	/// <summary>
	/// Interaction logic for InjectedWindow.xaml
	/// </summary>
	public partial class InjectedWindow : Window
	{
		private TextBox foundTextBox;
		public InjectedWindow()
		{
			InitializeComponent();
		}

		public static void Inject()
		{
			System.Diagnostics.Debugger.Break();
			Dispatcher dispatcher;
			if (Application.Current == null)
			{
				dispatcher = Dispatcher.CurrentDispatcher;
			}
			else
			{
				dispatcher = Application.Current.Dispatcher;
			}
			if (dispatcher.CheckAccess())
			{
				InjectedWindow w = new InjectedWindow();
				string title = w.TryGetMainWindowTitle();
				w.Title = $"Injected window into: {title}";
				w.Show();
				w.Activate();
			} else
			{
				dispatcher.Invoke((Action)Inject);
			}
		}

		private string TryGetMainWindowTitle()
		{
			if (Application.Current != null && Application.Current.MainWindow != null)
			{
				Application.Current.MainWindow.Closed += (o, e) =>
				{
					this.Close();
				};
				TryFindTextBox(Application.Current.MainWindow);
				return Application.Current.MainWindow.Title;
			}
			return string.Empty;
		}

		private void TryFindTextBox(Window mainWindow)
		{
			void enumChildren(Visual v)
			{
				for(int i=0;i<VisualTreeHelper.GetChildrenCount(v);++i)
				{
					if (foundTextBox != null) return;
					Visual child = (Visual)VisualTreeHelper.GetChild(v, i);
					if (child is TextBox)
					{
						foundTextBox = (TextBox)child;
						return;
					}
					enumChildren(child);
				}
			}
			enumChildren(mainWindow);
			if (foundTextBox == null)
			{
				btnReadText.IsEnabled = false;
				btnWriteText.IsEnabled = false;
				btnQuitApp.IsEnabled = false;
				status.Text = "TextBox not found.";
			} else
			{
				status.Text = "Host TextBox found.";
			}
		}

		private void btnReadText_Click(object sender, RoutedEventArgs e)
		{
			text.Text = foundTextBox.Text;
			status.Text = "Text copied from host.";
		}

		private void btnWriteText_Click(object sender, RoutedEventArgs e)
		{
			foundTextBox.Text = text.Text;
			status.Text = "Text copied to host.";
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnQuitApp_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
