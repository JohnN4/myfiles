using System.Windows;
using System.Windows.Controls;

namespace ControlHierarchy.WPF
{
	public class BlockChild : ContentControl
	{
		static BlockChild()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BlockChild), new FrameworkPropertyMetadata(typeof(BlockChild)));
		}
	}
}
