namespace PS3Lib
{
	public partial class ConnectDialog : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(PS3Lib.ConnectDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.txtIp = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0x10, 0x1A);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0x17, 0xD);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP: ";
			this.txtIp.Location = new System.Drawing.Point(0x2D, 0x17);
			this.txtIp.MaxLength = 0x10;
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(0x74, 0x14);
			this.txtIp.TabIndex = 1;
			this.txtIp.Text = "127.0.0.1";
			this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(0x76, 0x3A);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(0x4B, 0x15);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "Connect";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(0xCB, 0x3A);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(0x4B, 0x15);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.txtPort.Enabled = false;
			this.txtPort.Location = new System.Drawing.Point(0xDF, 0x17);
			this.txtPort.MaxLength = 5;
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(0x37, 0x14);
			this.txtPort.TabIndex = 5;
			this.txtPort.Text = "7887";
			this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0xAE, 0x1A);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0x2B, 0xD);
			this.label2.TabIndex = 4;
			this.label2.Text = "PORT: ";
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(0x124, 0x55);
			base.ControlBox = false;
			base.Controls.Add(this.txtPort);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.txtIp);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ConnectDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connection with PS3 Manager API";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

#pragma warning disable CS0649 // Field 'ConnectDialog.components' is never assigned to, and will always have its default value null
		private System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // Field 'ConnectDialog.components' is never assigned to, and will always have its default value null

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Button btnOK;

		private System.Windows.Forms.Button btnCancel;

		protected internal System.Windows.Forms.TextBox txtIp;

		protected internal System.Windows.Forms.TextBox txtPort;

		private System.Windows.Forms.Label label2;
	}
}
