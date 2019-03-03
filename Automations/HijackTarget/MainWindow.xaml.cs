using System.Windows;

namespace HijackTarget
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			close.Click += (o, e) =>
			{
				Close();
			};
		}
	}
}
