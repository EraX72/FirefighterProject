namespace FirefighterProject.View
{
    partial class LoginView
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
            this.lblTitleLog = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtBoxUserLog = new System.Windows.Forms.TextBox();
            this.txtBoxPassLog = new System.Windows.Forms.TextBox();
            this.lblUserLog = new System.Windows.Forms.Label();
            this.lblPassLog = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblAccountLog = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pboxLog = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleLog
            // 
            this.lblTitleLog.AutoSize = true;
            this.lblTitleLog.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitleLog.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLog.ForeColor = System.Drawing.Color.White;
            this.lblTitleLog.Location = new System.Drawing.Point(35, 9);
            this.lblTitleLog.Name = "lblTitleLog";
            this.lblTitleLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitleLog.Size = new System.Drawing.Size(310, 34);
            this.lblTitleLog.TabIndex = 0;
            this.lblTitleLog.Text = "FlameGuard Connect\r\n";
            this.lblTitleLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Maroon;
            this.lblLogin.Location = new System.Drawing.Point(534, 18);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(107, 34);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "LOGIN";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxUserLog
            // 
            this.txtBoxUserLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUserLog.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBoxUserLog.Location = new System.Drawing.Point(448, 116);
            this.txtBoxUserLog.Multiline = true;
            this.txtBoxUserLog.Name = "txtBoxUserLog";
            this.txtBoxUserLog.Size = new System.Drawing.Size(274, 38);
            this.txtBoxUserLog.TabIndex = 2;
            // 
            // txtBoxPassLog
            // 
            this.txtBoxPassLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassLog.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBoxPassLog.Location = new System.Drawing.Point(448, 203);
            this.txtBoxPassLog.Multiline = true;
            this.txtBoxPassLog.Name = "txtBoxPassLog";
            this.txtBoxPassLog.Size = new System.Drawing.Size(274, 38);
            this.txtBoxPassLog.TabIndex = 4;
            // 
            // lblUserLog
            // 
            this.lblUserLog.AutoSize = true;
            this.lblUserLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUserLog.Location = new System.Drawing.Point(444, 94);
            this.lblUserLog.Name = "lblUserLog";
            this.lblUserLog.Size = new System.Drawing.Size(87, 19);
            this.lblUserLog.TabIndex = 5;
            this.lblUserLog.Text = "Username";
            // 
            // lblPassLog
            // 
            this.lblPassLog.AutoSize = true;
            this.lblPassLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassLog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPassLog.Location = new System.Drawing.Point(444, 181);
            this.lblPassLog.Name = "lblPassLog";
            this.lblPassLog.Size = new System.Drawing.Size(86, 19);
            this.lblPassLog.TabIndex = 6;
            this.lblPassLog.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(448, 277);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(273, 50);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblAccountLog
            // 
            this.lblAccountLog.AutoSize = true;
            this.lblAccountLog.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountLog.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAccountLog.Location = new System.Drawing.Point(493, 351);
            this.lblAccountLog.Name = "lblAccountLog";
            this.lblAccountLog.Size = new System.Drawing.Size(188, 19);
            this.lblAccountLog.TabIndex = 9;
            this.lblAccountLog.Text = "Don\'t Have an Account";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCreate.Location = new System.Drawing.Point(527, 379);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(126, 19);
            this.lblCreate.TabIndex = 10;
            this.lblCreate.Text = "Create Account";
            this.lblCreate.Click += new System.EventHandler(this.lblCreate_Click);
            // 
            // pboxLog
            // 
            this.pboxLog.BackgroundImage = global::FirefighterProject.Properties.Resources.firefight;
            this.pboxLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pboxLog.Image = global::FirefighterProject.Properties.Resources.firefighterPh;
            this.pboxLog.Location = new System.Drawing.Point(0, 0);
            this.pboxLog.Name = "pboxLog";
            this.pboxLog.Size = new System.Drawing.Size(395, 463);
            this.pboxLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxLog.TabIndex = 7;
            this.pboxLog.TabStop = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblAccountLog);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassLog);
            this.Controls.Add(this.lblUserLog);
            this.Controls.Add(this.txtBoxPassLog);
            this.Controls.Add(this.txtBoxUserLog);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblTitleLog);
            this.Controls.Add(this.pboxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginView";
            this.Text = "LoginView";
            this.Load += new System.EventHandler(this.LoginView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtBoxUserLog;
        private System.Windows.Forms.TextBox txtBoxPassLog;
        private System.Windows.Forms.Label lblUserLog;
        private System.Windows.Forms.Label lblPassLog;
        private System.Windows.Forms.PictureBox pboxLog;
        private System.Windows.Forms.Label lblTitleLog;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblAccountLog;
        private System.Windows.Forms.Label lblCreate;
    }
}