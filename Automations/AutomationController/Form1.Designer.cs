namespace AutomationController
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbCloseClient = new System.Windows.Forms.RadioButton();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnSendMessage = new System.Windows.Forms.Button();
			this.rbClearText = new System.Windows.Forms.RadioButton();
			this.rbReverseText = new System.Windows.Forms.RadioButton();
			this.rbSendText = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnOpenWPF = new System.Windows.Forms.Button();
			this.btnOpenForms = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnOpenForms);
			this.groupBox1.Controls.Add(this.btnOpenWPF);
			this.groupBox1.Location = new System.Drawing.Point(19, 19);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(476, 369);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Automation Clients";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbCloseClient);
			this.groupBox2.Controls.Add(this.btnExit);
			this.groupBox2.Controls.Add(this.btnSendMessage);
			this.groupBox2.Controls.Add(this.rbClearText);
			this.groupBox2.Controls.Add(this.rbReverseText);
			this.groupBox2.Controls.Add(this.rbSendText);
			this.groupBox2.Location = new System.Drawing.Point(546, 35);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(900, 353);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Automations";
			// 
			// rbCloseClient
			// 
			this.rbCloseClient.AutoSize = true;
			this.rbCloseClient.Location = new System.Drawing.Point(45, 269);
			this.rbCloseClient.Name = "rbCloseClient";
			this.rbCloseClient.Size = new System.Drawing.Size(206, 36);
			this.rbCloseClient.TabIndex = 5;
			this.rbCloseClient.Text = "Close Client";
			this.rbCloseClient.UseVisualStyleBackColor = true;
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(417, 209);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(403, 102);
			this.btnExit.TabIndex = 4;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// btnSendMessage
			// 
			this.btnSendMessage.Location = new System.Drawing.Point(417, 59);
			this.btnSendMessage.Name = "btnSendMessage";
			this.btnSendMessage.Size = new System.Drawing.Size(403, 102);
			this.btnSendMessage.TabIndex = 3;
			this.btnSendMessage.Text = "Send Message";
			this.btnSendMessage.UseVisualStyleBackColor = true;
			// 
			// rbClearText
			// 
			this.rbClearText.AutoSize = true;
			this.rbClearText.Location = new System.Drawing.Point(45, 198);
			this.rbClearText.Name = "rbClearText";
			this.rbClearText.Size = new System.Drawing.Size(182, 36);
			this.rbClearText.TabIndex = 2;
			this.rbClearText.Text = "Clear Text";
			this.rbClearText.UseVisualStyleBackColor = true;
			// 
			// rbReverseText
			// 
			this.rbReverseText.AutoSize = true;
			this.rbReverseText.Location = new System.Drawing.Point(45, 130);
			this.rbReverseText.Name = "rbReverseText";
			this.rbReverseText.Size = new System.Drawing.Size(219, 36);
			this.rbReverseText.TabIndex = 1;
			this.rbReverseText.Text = "Reverse Text";
			this.rbReverseText.UseVisualStyleBackColor = true;
			// 
			// rbSendText
			// 
			this.rbSendText.AutoSize = true;
			this.rbSendText.Checked = true;
			this.rbSendText.Location = new System.Drawing.Point(45, 64);
			this.rbSendText.Name = "rbSendText";
			this.rbSendText.Size = new System.Drawing.Size(181, 36);
			this.rbSendText.TabIndex = 0;
			this.rbSendText.TabStop = true;
			this.rbSendText.Text = "Send Text";
			this.rbSendText.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Location = new System.Drawing.Point(19, 416);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1427, 425);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Text to Send";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 50);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(1379, 345);
			this.textBox1.TabIndex = 0;
			// 
			// btnOpenWPF
			// 
			this.btnOpenWPF.Location = new System.Drawing.Point(22, 91);
			this.btnOpenWPF.Name = "btnOpenWPF";
			this.btnOpenWPF.Size = new System.Drawing.Size(425, 71);
			this.btnOpenWPF.TabIndex = 0;
			this.btnOpenWPF.Text = "Open WPF Client";
			this.btnOpenWPF.UseVisualStyleBackColor = true;
			// 
			// btnOpenForms
			// 
			this.btnOpenForms.Location = new System.Drawing.Point(22, 214);
			this.btnOpenForms.Name = "btnOpenForms";
			this.btnOpenForms.Size = new System.Drawing.Size(425, 71);
			this.btnOpenForms.TabIndex = 1;
			this.btnOpenForms.Text = "Open Forms Client";
			this.btnOpenForms.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1475, 908);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Automation Controller";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbClearText;
		private System.Windows.Forms.RadioButton rbReverseText;
		private System.Windows.Forms.RadioButton rbSendText;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbCloseClient;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnSendMessage;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnOpenForms;
		private System.Windows.Forms.Button btnOpenWPF;
	}
}

