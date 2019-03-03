using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlHierarchy
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			ClientSize = new Size(400, 400);
			Size lastSize = ClientSize;
			BlockChild lastChild = new BlockChild
			{
				BackColor = Color.Black,
				Dock = DockStyle.Fill
			};
			Controls.Add(lastChild);
			for(int i=0;i<12;++i)
			{
				int w = (int)(lastSize.Width * 0.8), h = (int)(lastSize.Height * 0.8);
				BlockChild child = new BlockChild
				{
					BackColor = (i % 2 == 0) ? Color.White : Color.Black,
					Size = new Size(w, h),
					Left = (lastSize.Width - w) / 2,
					Top = (lastSize.Height - h) / 2
				};
				lastChild.Controls.Add(child);
				lastChild = child;
				lastSize = child.Size;
			}
		}
	}
}
