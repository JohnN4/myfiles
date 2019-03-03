using Automation.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AutomationController
{
	public partial class MainForm : Form
	{
		private List<ProcessHwnd> _processes = new List<ProcessHwnd>();
		private static readonly string WPFClientPath, FormsClientPath;
		static MainForm()
		{
			string curFolder = Environment.CurrentDirectory;
			string baseFolder = Path.GetFullPath(Path.Combine(curFolder, "..\\..\\..\\"));
			WPFClientPath = Path.Combine(baseFolder, "AutomationClient.WPF\\bin\\Debug\\AutomationClient.WPF.exe");
			FormsClientPath = Path.Combine(baseFolder, "AutomationClient.Forms\\bin\\Debug\\AutomationClient.Forms.exe");
		}
		public MainForm()
		{
			InitializeComponent();
			btnExit.Click += BtnExit_Click;
			btnSendMessage.Click += BtnSendMessage_Click;
			btnOpenForms.Click += BtnOpenForms_Click;
			btnOpenWPF.Click += BtnOpenWPF_Click;
			EnableStuff();
			Visible = false;
			Load += (o, e) =>
			{
				Visible = true;
				int left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
				DesktopLocation = new System.Drawing.Point(left, 0);
			};
		}

		private void BtnOpenWPF_Click(object sender, EventArgs e)
		{
			OpenClient(ClientType.WPF);			
		}

		private void BtnOpenForms_Click(object sender, EventArgs e)
		{
			OpenClient(ClientType.Forms);
		}

		private void BtnSendMessage_Click(object sender, EventArgs e)
		{
			foreach(var p in _processes)
			{
				if (rbClearText.Checked) Messages.SendMessage(p.Hwnd, Messages.WM_CLEARTEXT);
				if (rbSendText.Checked) Messages.SendMessage(p.Hwnd, Messages.WM_SENDTEXT, textBox1.Text);
				if (rbReverseText.Checked) Messages.SendMessage(p.Hwnd, Messages.WM_REVERSETEXT);
				if (rbCloseClient.Checked) Messages.SendMessage(p.Hwnd, Messages.WM_CLOSECLIENT);
			}
		}


		private void BtnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OpenClient(ClientType type)
		{
			string path = (type == ClientType.WPF) ? WPFClientPath : FormsClientPath;
			Process p = new Process();
			p.StartInfo.FileName = path;
			p.EnableRaisingEvents = true;
			p.Start();
			_processes.Add(new ProcessHwnd(type, p, this));
			EnableStuff();
		}

		private void RemoveClient(ProcessHwnd ph)
		{
			_processes.Remove(ph);
			EnableStuff();
		}

		private void EnableStuff()
		{
			btnSendMessage.Enabled = _processes.Count > 0;
		}
		
		private enum ClientType { WPF, Forms }


		private class ProcessHwnd
		{
			public ProcessHwnd(ClientType type, Process p, MainForm owner)
			{
				Type = type;
				Process = p;
				Owner = owner;
				Process.Exited += (o, e) =>
				{
					Owner.RemoveClient(this);
				};
			}
			public IntPtr Hwnd => Process.MainWindowHandle;
			public ClientType Type { get; private set; }
			private Process Process { get; set; }
			private MainForm Owner { get; set; }
		}
	}
}
