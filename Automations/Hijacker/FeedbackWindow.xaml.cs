using System.Windows;
using System.Windows.Media;

namespace Hijacker
{
	/// <summary>
	/// Interaction logic for FeedbackWindow.xaml
	/// </summary>
	public partial class FeedbackWindow : Window
	{
		public FeedbackWindow()
		{
			InitializeComponent();
		}

		public string TargetName
		{
			get => target.Text;
			set
			{
				target.Text = value;
			}
		}

		public bool IsTargetValid
		{
			set
			{
				grid.Background = (value) ? Brushes.White : Brushes.LightGray;
			}
		}
	}
}
