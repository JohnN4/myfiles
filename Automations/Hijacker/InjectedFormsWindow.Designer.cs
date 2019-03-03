namespace Hijacker
{
	partial class InjectedFormsWindow
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnReadText = new System.Windows.Forms.Button();
			this.btnWriteText = new System.Windows.Forms.Button();
			this.btnQuitApp = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.text = new System.Windows.Forms.TextBox();
			this.status = new System.Windows.Forms.Label();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnReadText);
			this.flowLayoutPanel1.Controls.Add(this.btnWriteText);
			this.flowLayoutPanel1.Controls.Add(this.btnQuitApp);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(795, 80);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnReadText
			// 
			this.btnReadText.Location = new System.Drawing.Point(3, 3);
			this.btnReadText.Name = "btnReadText";
			this.btnReadText.Size = new System.Drawing.Size(186, 68);
			this.btnReadText.TabIndex = 0;
			this.btnReadText.Text = "Read Text";
			this.btnReadText.UseVisualStyleBackColor = true;
			this.btnReadText.Click += new System.EventHandler(this.btnReadText_Click);
			// 
			// btnWriteText
			// 
			this.btnWriteText.Location = new System.Drawing.Point(195, 3);
			this.btnWriteText.Name = "btnWriteText";
			this.btnWriteText.Size = new System.Drawing.Size(207, 68);
			this.btnWriteText.TabIndex = 1;
			this.btnWriteText.Text = "Write Text";
			this.btnWriteText.UseVisualStyleBackColor = true;
			this.btnWriteText.Click += new System.EventHandler(this.btnWriteText_Click);
			// 
			// btnQuitApp
			// 
			this.btnQuitApp.Location = new System.Drawing.Point(408, 3);
			this.btnQuitApp.Name = "btnQuitApp";
			this.btnQuitApp.Size = new System.Drawing.Size(320, 68);
			this.btnQuitApp.TabIndex = 2;
			this.btnQuitApp.Text = "Close the Application";
			this.btnQuitApp.UseVisualStyleBackColor = true;
			this.btnQuitApp.Click += new System.EventHandler(this.btnQuitApp_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(921, 16);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(348, 68);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close this WIndow";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(213, 32);
			this.label1.TabIndex = 4;
			this.label1.Text = "Enter Text Here";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.text);
			this.flowLayoutPanel2.Controls.Add(this.status);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 138);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(1281, 542);
			this.flowLayoutPanel2.TabIndex = 5;
			// 
			// text
			// 
			this.text.Location = new System.Drawing.Point(3, 3);
			this.text.Multiline = true;
			this.text.Name = "text";
			this.text.Size = new System.Drawing.Size(1278, 476);
			this.text.TabIndex = 0;
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.status.Location = new System.Drawing.Point(3, 482);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(109, 39);
			this.status.TabIndex = 1;
			this.status.Text = "label2";
			// 
			// InjectedFormsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1281, 680);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.btnClose);
			this.Name = "InjectedFormsWindow";
			this.Text = "Injected Forms Window";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btnReadText;
		private System.Windows.Forms.Button btnWriteText;
		private System.Windows.Forms.Button btnQuitApp;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.TextBox text;
		private System.Windows.Forms.Label status;
	}
}