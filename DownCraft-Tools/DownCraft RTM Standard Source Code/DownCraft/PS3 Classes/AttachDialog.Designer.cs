namespace PS3Lib
{
	public partial class AttachDialog : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(PS3Lib.AttachDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 0x15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0x40, 0xD);
			this.label1.TabIndex = 0;
			this.label1.Text = "PROCESS: ";
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(0x59, 0x3A);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(0x6C, 0x15);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "Attach selected";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(0xCB, 0x3A);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(0x4B, 0x15);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(0x59, 0x12);
			this.comboBox1.MaxDropDownItems = 0x10;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(0xBD, 0x15);
			this.comboBox1.TabIndex = 4;
			this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.btnRefresh.Location = new System.Drawing.Point(0xC, 0x3A);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(0x47, 0x15);
			this.btnRefresh.TabIndex = 5;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(0x124, 0x55);
			base.ControlBox = false;
			base.Controls.Add(this.btnRefresh);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AttachDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Attach process with PS3 Manager API";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

#pragma warning disable CS0649 // Field 'AttachDialog.components' is never assigned to, and will always have its default value null
		private System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // Field 'AttachDialog.components' is never assigned to, and will always have its default value null

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Button btnOK;

		private System.Windows.Forms.Button btnCancel;

		private System.Windows.Forms.Button btnRefresh;

		protected internal System.Windows.Forms.ComboBox comboBox1;
	}
}
