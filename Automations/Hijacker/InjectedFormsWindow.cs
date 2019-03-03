using System;
using System.Windows.Forms;

namespace Hijacker
{
	public partial class InjectedFormsWindow : Form
	{
		private TextBox foundTextBox;
		public InjectedFormsWindow()
		{
			InitializeComponent();
		}

		public static void Inject()
		{
			Form f = Application.OpenForms[0];
			if (f.InvokeRequired)
			{
				f.Invoke((Action)Inject);
				return;
			}

			InjectedFormsWindow w = new InjectedFormsWindow();
			w.FindTextBox(f);
			w.Text = $"Injected Window into: {f.Text}";
			w.Show();
		}

		private void FindTextBox(Form f)
		{
			void enumControls(Control parent)
			{
				foreach(Control child in parent.Controls)
				{
					if (foundTextBox != null) return;
					if (child is TextBox)
					{
						foundTextBox = (TextBox)child;
						return;
					}
					enumControls(child);
				}
			}
			enumControls(f);
			if (foundTextBox == null)
			{
				btnQuitApp.Enabled = btnReadText.Enabled = btnWriteText.Enabled = false;
				status.Text = "TextBox not found.";
			} else
			{
				btnQuitApp.Enabled = btnReadText.Enabled = btnWriteText.Enabled = true;
				status.Text = "TextBox found.";

			}
		}

		private void btnReadText_Click(object sender, EventArgs e)
		{
			text.Text = foundTextBox.Text;
		}

		private void btnWriteText_Click(object sender, EventArgs e)
		{
			foundTextBox.Text = text.Text;
		}

		private void btnQuitApp_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
