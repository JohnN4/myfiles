using Automation.Common;
using System;
using System.Windows.Forms;

namespace AutomationClient.Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void HandleMessage(Message m)
		{
			string status = "";
			switch(m.Msg)
			{
				case Messages.WM_SENDTEXT:
					txtOutput.Text = Messages.ExtractString(m.LParam);
					status = "WM_SENDTEXT";
					break;
				case Messages.WM_REVERSETEXT:
					char[] data = txtOutput.Text.ToCharArray();
					Array.Reverse(data);
					txtOutput.Text = new string(data);
					status = "WM_REVERSETEXT";
					break;
				case Messages.WM_CLEARTEXT:
					txtOutput.Text = string.Empty;
					status = "WM_CLEARTEXT";
					break;
				case Messages.WM_CLOSECLIENT:
					Close();
					return;
			}
			lblStatus.Text = $"Message '{status}' processed.";
		}

		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				case Messages.WM_SENDTEXT:
				case Messages.WM_REVERSETEXT:
				case Messages.WM_CLEARTEXT:
				case Messages.WM_CLOSECLIENT:
					HandleMessage(m);
					return;
			}
			base.WndProc(ref m);
		}
	}
}
