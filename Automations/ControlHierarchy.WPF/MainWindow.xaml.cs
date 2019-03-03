using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlHierarchy.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CreateBorderContent();
			//CreateBlockChildContent();
			//CreateTextBoxContent();
			//CreateListBoxContent();
		}

		private void CreateBorderContent()
		{
			Content = new Border
			{
				Height = 400,
				Width = 400,
				Background = Brushes.Black
			};
			Border lastBorder = (Border)Content;
			for(int i=0;i<12;++i)
			{
				double dim = lastBorder.Width / 1.3;
				Border nextBorder = new Border
				{
					Height = dim,
					Width = dim,
					Background = (i % 2 == 0) ? Brushes.White : Brushes.Black
				};
				lastBorder.Child = nextBorder;
				lastBorder = nextBorder;
			}
		}

		private void CreateBlockChildContent()
		{
			BlockChild child = new BlockChild
			{
				Background = Brushes.Black,
				Width = 400,
				Height = 400
			};
			Content = child;
			for(int i=0;i<12;++i)
			{
				double dim = child.Width / 1.3;
				BlockChild nextChild = new BlockChild
				{
					Width = dim,
					Height = dim,
					Background = (i % 2 == 0) ? Brushes.White : Brushes.Black
				};
				child.Content = nextChild;
				child = nextChild;
			}
		}

		private void CreateTextBoxContent()
		{
			Content = new TextBox
			{
				Width = 400,
				Height = 400,
				AcceptsReturn = true,
				AcceptsTab = true
			};
		}

		private void CreateListBoxContent()
		{
			ListBox lb = new ListBox
			{
				Width = 400,
				Height = 400
			};
			for(int i=0;i<12;++i)
			{
				lb.Items.Add(new ListBoxItem
				{
					Content = $"Item {i + 1}"
				});
			}
			Content = lb;
		}

	}
}
