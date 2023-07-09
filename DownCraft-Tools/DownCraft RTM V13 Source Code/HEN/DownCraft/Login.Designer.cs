
namespace DownCraft
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.GunaPanelTop = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.GunaControlMin = new Guna.UI.WinForms.GunaControlBox();
            this.GunaControlClose = new Guna.UI.WinForms.GunaControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LoginBTN = new Guna.UI.WinForms.GunaButton();
            this.GunaLabelPassword = new Guna.UI.WinForms.GunaLabel();
            this.GunaLabelUsername = new Guna.UI.WinForms.GunaLabel();
            this.GunaSeparatorLine2 = new Guna.UI.WinForms.GunaSeparator();
            this.Password = new Guna.UI.WinForms.GunaTextBox();
            this.Username = new Guna.UI.WinForms.GunaTextBox();
            this.GunaPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GunaPanelTop
            // 
            this.GunaPanelTop.BackColor = System.Drawing.Color.Black;
            this.GunaPanelTop.Controls.Add(this.gunaLabel3);
            this.GunaPanelTop.Controls.Add(this.GunaControlMin);
            this.GunaPanelTop.Controls.Add(this.GunaControlClose);
            this.GunaPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.GunaPanelTop.Location = new System.Drawing.Point(0, 0);
            this.GunaPanelTop.Name = "GunaPanelTop";
            this.GunaPanelTop.Size = new System.Drawing.Size(368, 25);
            this.GunaPanelTop.TabIndex = 80;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.White;
            this.gunaLabel3.Location = new System.Drawing.Point(13, 4);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(154, 17);
            this.gunaLabel3.TabIndex = 14;
            this.gunaLabel3.Text = "DownCraft RTM - Login";
            // 
            // GunaControlMin
            // 
            this.GunaControlMin.AnimationHoverSpeed = 0.07F;
            this.GunaControlMin.AnimationSpeed = 0.03F;
            this.GunaControlMin.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.GunaControlMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GunaControlMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.GunaControlMin.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(222)))));
            this.GunaControlMin.IconSize = 15F;
            this.GunaControlMin.Location = new System.Drawing.Point(308, 0);
            this.GunaControlMin.Name = "GunaControlMin";
            this.GunaControlMin.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.GunaControlMin.OnHoverIconColor = System.Drawing.Color.Transparent;
            this.GunaControlMin.OnPressedColor = System.Drawing.Color.Black;
            this.GunaControlMin.Size = new System.Drawing.Size(30, 25);
            this.GunaControlMin.TabIndex = 2;
            // 
            // GunaControlClose
            // 
            this.GunaControlClose.AnimationHoverSpeed = 0.07F;
            this.GunaControlClose.AnimationSpeed = 0.03F;
            this.GunaControlClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GunaControlClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.GunaControlClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(222)))));
            this.GunaControlClose.IconSize = 15F;
            this.GunaControlClose.Location = new System.Drawing.Point(338, 0);
            this.GunaControlClose.Name = "GunaControlClose";
            this.GunaControlClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.GunaControlClose.OnHoverIconColor = System.Drawing.Color.Transparent;
            this.GunaControlClose.OnPressedColor = System.Drawing.Color.Black;
            this.GunaControlClose.Size = new System.Drawing.Size(30, 25);
            this.GunaControlClose.TabIndex = 0;
            this.GunaControlClose.Click += new System.EventHandler(this.GunaControlClose_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(69, 65);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(231, 54);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 194;
            this.guna2PictureBox1.TabStop = false;
            // 
            // LoginBTN
            // 
            this.LoginBTN.AnimationHoverSpeed = 0.07F;
            this.LoginBTN.AnimationSpeed = 0.03F;
            this.LoginBTN.BackColor = System.Drawing.Color.Transparent;
            this.LoginBTN.BaseColor = System.Drawing.Color.Black;
            this.LoginBTN.BorderColor = System.Drawing.Color.Black;
            this.LoginBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.LoginBTN.FocusedColor = System.Drawing.Color.Empty;
            this.LoginBTN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBTN.ForeColor = System.Drawing.Color.White;
            this.LoginBTN.Image = null;
            this.LoginBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.LoginBTN.Location = new System.Drawing.Point(38, 326);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LoginBTN.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LoginBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.LoginBTN.OnHoverImage = null;
            this.LoginBTN.OnPressedColor = System.Drawing.Color.Black;
            this.LoginBTN.Radius = 2;
            this.LoginBTN.Size = new System.Drawing.Size(293, 50);
            this.LoginBTN.TabIndex = 201;
            this.LoginBTN.Text = "Login";
            this.LoginBTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // GunaLabelPassword
            // 
            this.GunaLabelPassword.AutoSize = true;
            this.GunaLabelPassword.BackColor = System.Drawing.Color.Transparent;
            this.GunaLabelPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabelPassword.ForeColor = System.Drawing.Color.White;
            this.GunaLabelPassword.Location = new System.Drawing.Point(47, 247);
            this.GunaLabelPassword.Name = "GunaLabelPassword";
            this.GunaLabelPassword.Size = new System.Drawing.Size(79, 17);
            this.GunaLabelPassword.TabIndex = 200;
            this.GunaLabelPassword.Text = "PASSWORD";
            // 
            // GunaLabelUsername
            // 
            this.GunaLabelUsername.AutoSize = true;
            this.GunaLabelUsername.BackColor = System.Drawing.Color.Transparent;
            this.GunaLabelUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabelUsername.ForeColor = System.Drawing.Color.White;
            this.GunaLabelUsername.Location = new System.Drawing.Point(47, 181);
            this.GunaLabelUsername.Name = "GunaLabelUsername";
            this.GunaLabelUsername.Size = new System.Drawing.Size(77, 17);
            this.GunaLabelUsername.TabIndex = 199;
            this.GunaLabelUsername.Text = "USERNAME";
            // 
            // GunaSeparatorLine2
            // 
            this.GunaSeparatorLine2.BackColor = System.Drawing.Color.Transparent;
            this.GunaSeparatorLine2.LineColor = System.Drawing.Color.Gray;
            this.GunaSeparatorLine2.Location = new System.Drawing.Point(57, 145);
            this.GunaSeparatorLine2.Name = "GunaSeparatorLine2";
            this.GunaSeparatorLine2.Size = new System.Drawing.Size(254, 8);
            this.GunaSeparatorLine2.TabIndex = 198;
            this.GunaSeparatorLine2.Thickness = 2;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.Transparent;
            this.Password.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Password.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Password.FocusedForeColor = System.Drawing.Color.White;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Gray;
            this.Password.Location = new System.Drawing.Point(38, 267);
            this.Password.MaxLength = 160;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '●';
            this.Password.Radius = 2;
            this.Password.SelectedText = "";
            this.Password.Size = new System.Drawing.Size(293, 40);
            this.Password.TabIndex = 197;
            this.Password.TextOffsetX = 3;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.Transparent;
            this.Username.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Username.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Username.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Username.FocusedForeColor = System.Drawing.Color.White;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.Gray;
            this.Username.Location = new System.Drawing.Point(38, 201);
            this.Username.MaxLength = 160;
            this.Username.Name = "Username";
            this.Username.PasswordChar = '\0';
            this.Username.Radius = 2;
            this.Username.SelectedText = "";
            this.Username.Size = new System.Drawing.Size(293, 46);
            this.Username.TabIndex = 195;
            this.Username.TextOffsetX = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(368, 458);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.GunaLabelPassword);
            this.Controls.Add(this.GunaLabelUsername);
            this.Controls.Add(this.GunaSeparatorLine2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.GunaPanelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.GunaPanelTop.ResumeLayout(false);
            this.GunaPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Guna.UI.WinForms.GunaPanel GunaPanelTop;
        internal Guna.UI.WinForms.GunaControlBox GunaControlMin;
        internal Guna.UI.WinForms.GunaControlBox GunaControlClose;
        internal Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        internal Guna.UI.WinForms.GunaLabel GunaLabelPassword;
        internal Guna.UI.WinForms.GunaLabel GunaLabelUsername;
        internal Guna.UI.WinForms.GunaSeparator GunaSeparatorLine2;
        public Guna.UI.WinForms.GunaTextBox Password;
        public Guna.UI.WinForms.GunaTextBox Username;
        internal Guna.UI.WinForms.GunaButton LoginBTN;
    }
}