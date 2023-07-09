namespace PS3Lib
{
	public partial class LogDialog : System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(PS3Lib.LogDialog));
			this.tB_Log = new System.Windows.Forms.TextBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			base.SuspendLayout();
			this.tB_Log.BackColor = System.Drawing.Color.White;
			this.tB_Log.Location = new System.Drawing.Point(0xC, 0xC);
			this.tB_Log.MaxLength = 0x10;
			this.tB_Log.Multiline = true;
			this.tB_Log.Name = "tB_Log";
			this.tB_Log.ReadOnly = true;
			this.tB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tB_Log.Size = new System.Drawing.Size(0x1AD, 0x147);
			this.tB_Log.TabIndex = 0xA;
			this.btnRefresh.Location = new System.Drawing.Point(0x122, 0x159);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(0x47, 0x15);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.LogDialog_Refresh);
			this.button1.Location = new System.Drawing.Point(0x172, 0x159);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(0x47, 0x15);
			this.button1.TabIndex = 2;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(0x1C5, 0x17A);
			base.ControlBox = false;
			base.Controls.Add(this.button1);
			base.Controls.Add(this.btnRefresh);
			base.Controls.Add(this.tB_Log);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "LogDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PS3 Manager API Log";
			base.Activated += new System.EventHandler(this.LogDialog_Refresh);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

#pragma warning disable CS0649 // Field 'LogDialog.components' is never assigned to, and will always have its default value null
		private System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // Field 'LogDialog.components' is never assigned to, and will always have its default value null

		protected internal System.Windows.Forms.TextBox tB_Log;

		private System.Windows.Forms.Button btnRefresh;

		private System.Windows.Forms.Button button1;
	}
}
