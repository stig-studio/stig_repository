namespace School_magazine
{
    partial class user_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user_info));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txtb_username = new System.Windows.Forms.TextBox();
            this.txtb_pass = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.txtb_confirm = new System.Windows.Forms.TextBox();
            this.lbl_confirm = new System.Windows.Forms.Label();
            this.lbl_empl = new System.Windows.Forms.Label();
            this.cmb_employees = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.cmb_is_admin = new System.Windows.Forms.ComboBox();
            this.lbl_admin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_header.ForeColor = System.Drawing.Color.White;
            this.lbl_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(485, 50);
            this.lbl_header.TabIndex = 28;
            this.lbl_header.Text = "  Информации о пользователе для входа в программу";
            this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_username.Location = new System.Drawing.Point(11, 122);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(107, 13);
            this.lbl_username.TabIndex = 29;
            this.lbl_username.Text = "имя пользователя:";
            // 
            // txtb_username
            // 
            this.txtb_username.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_username.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_username.Location = new System.Drawing.Point(127, 118);
            this.txtb_username.Name = "txtb_username";
            this.txtb_username.Size = new System.Drawing.Size(234, 22);
            this.txtb_username.TabIndex = 30;
            // 
            // txtb_pass
            // 
            this.txtb_pass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_pass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_pass.Location = new System.Drawing.Point(127, 150);
            this.txtb_pass.Name = "txtb_pass";
            this.txtb_pass.Size = new System.Drawing.Size(234, 22);
            this.txtb_pass.TabIndex = 32;
            this.txtb_pass.UseSystemPasswordChar = true;
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_pass.Location = new System.Drawing.Point(71, 154);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(49, 13);
            this.lbl_pass.TabIndex = 31;
            this.lbl_pass.Text = "пароль:";
            // 
            // txtb_confirm
            // 
            this.txtb_confirm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_confirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_confirm.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_confirm.Location = new System.Drawing.Point(127, 181);
            this.txtb_confirm.Name = "txtb_confirm";
            this.txtb_confirm.Size = new System.Drawing.Size(234, 22);
            this.txtb_confirm.TabIndex = 34;
            this.txtb_confirm.UseSystemPasswordChar = true;
            // 
            // lbl_confirm
            // 
            this.lbl_confirm.AutoSize = true;
            this.lbl_confirm.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_confirm.Location = new System.Drawing.Point(26, 185);
            this.lbl_confirm.Name = "lbl_confirm";
            this.lbl_confirm.Size = new System.Drawing.Size(95, 13);
            this.lbl_confirm.TabIndex = 33;
            this.lbl_confirm.Text = "подтверждение:";
            // 
            // lbl_empl
            // 
            this.lbl_empl.AutoSize = true;
            this.lbl_empl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_empl.Location = new System.Drawing.Point(54, 213);
            this.lbl_empl.Name = "lbl_empl";
            this.lbl_empl.Size = new System.Drawing.Size(65, 13);
            this.lbl_empl.TabIndex = 35;
            this.lbl_empl.Text = "сотрудник:";
            // 
            // cmb_employees
            // 
            this.cmb_employees.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_employees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_employees.FormattingEnabled = true;
            this.cmb_employees.Location = new System.Drawing.Point(127, 209);
            this.cmb_employees.Name = "cmb_employees";
            this.cmb_employees.Size = new System.Drawing.Size(234, 21);
            this.cmb_employees.TabIndex = 36;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(127, 268);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(234, 37);
            this.btn_add.TabIndex = 50;
            this.btn_add.Text = "ИЗМЕНИТЬ";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 365);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(485, 78);
            this.lbl_error.TabIndex = 51;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmb_is_admin
            // 
            this.cmb_is_admin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_is_admin.FormattingEnabled = true;
            this.cmb_is_admin.Location = new System.Drawing.Point(127, 236);
            this.cmb_is_admin.Name = "cmb_is_admin";
            this.cmb_is_admin.Size = new System.Drawing.Size(234, 21);
            this.cmb_is_admin.TabIndex = 53;
            // 
            // lbl_admin
            // 
            this.lbl_admin.AutoSize = true;
            this.lbl_admin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_admin.Location = new System.Drawing.Point(25, 240);
            this.lbl_admin.Name = "lbl_admin";
            this.lbl_admin.Size = new System.Drawing.Size(93, 13);
            this.lbl_admin.TabIndex = 52;
            this.lbl_admin.Text = "администратор:";
            // 
            // user_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 443);
            this.Controls.Add(this.cmb_is_admin);
            this.Controls.Add(this.lbl_admin);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_employees);
            this.Controls.Add(this.lbl_empl);
            this.Controls.Add(this.txtb_confirm);
            this.Controls.Add(this.lbl_confirm);
            this.Controls.Add(this.txtb_pass);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.txtb_username);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "user_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   Информации о пользователе для входа в программу";
            this.Load += new System.EventHandler(this.user_info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox txtb_username;
        private System.Windows.Forms.TextBox txtb_pass;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.TextBox txtb_confirm;
        private System.Windows.Forms.Label lbl_confirm;
        private System.Windows.Forms.Label lbl_empl;
        private System.Windows.Forms.ComboBox cmb_employees;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.ComboBox cmb_is_admin;
        private System.Windows.Forms.Label lbl_admin;
    }
}