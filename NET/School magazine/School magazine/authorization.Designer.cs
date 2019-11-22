namespace School_magazine
{
    partial class authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(authorization));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.txtb_user = new System.Windows.Forms.TextBox();
            this.txtb_password = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.btn_signin = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::School_magazine.Properties.Resources.group_users;
            this.pictureBox1.Location = new System.Drawing.Point(99, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(45, 175);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(81, 13);
            this.lbl_user.TabIndex = 1;
            this.lbl_user.Text = "Пользователь";
            // 
            // txtb_user
            // 
            this.txtb_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_user.Location = new System.Drawing.Point(48, 193);
            this.txtb_user.Name = "txtb_user";
            this.txtb_user.Size = new System.Drawing.Size(213, 22);
            this.txtb_user.TabIndex = 2;
            // 
            // txtb_password
            // 
            this.txtb_password.Location = new System.Drawing.Point(48, 246);
            this.txtb_password.Name = "txtb_password";
            this.txtb_password.Size = new System.Drawing.Size(213, 22);
            this.txtb_password.TabIndex = 4;
            this.txtb_password.UseSystemPasswordChar = true;
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(45, 228);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(50, 13);
            this.lbl_pass.TabIndex = 3;
            this.lbl_pass.Text = "Пароль:";
            // 
            // btn_signin
            // 
            this.btn_signin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_signin.FlatAppearance.BorderSize = 0;
            this.btn_signin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_signin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_signin.ForeColor = System.Drawing.Color.White;
            this.btn_signin.Location = new System.Drawing.Point(48, 292);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Size = new System.Drawing.Size(213, 39);
            this.btn_signin.TabIndex = 5;
            this.btn_signin.Text = "ВОЙТИ";
            this.btn_signin.UseVisualStyleBackColor = false;
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(12, 369);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(287, 66);
            this.lbl_error.TabIndex = 6;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 444);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_signin);
            this.Controls.Add(this.txtb_password);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.txtb_user);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.authorization_FormClosed);
            this.Load += new System.EventHandler(this.authorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox txtb_user;
        private System.Windows.Forms.TextBox txtb_password;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Button btn_signin;
        private System.Windows.Forms.Label lbl_error;
    }
}