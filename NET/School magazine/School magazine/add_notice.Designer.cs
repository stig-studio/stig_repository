namespace School_magazine
{
    partial class add_notice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_notice));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txtb_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_text_notice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_error = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.BackColor = System.Drawing.Color.Yellow;
            this.lbl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(387, 50);
            this.lbl_header.TabIndex = 0;
            this.lbl_header.Text = "  Новое объявление";
            this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_title.Location = new System.Drawing.Point(18, 22);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(70, 15);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Заголовок:";
            // 
            // txtb_title
            // 
            this.txtb_title.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_title.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_title.Location = new System.Drawing.Point(21, 41);
            this.txtb_title.Name = "txtb_title";
            this.txtb_title.Size = new System.Drawing.Size(182, 22);
            this.txtb_title.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Текст сообщения:";
            // 
            // txtb_text_notice
            // 
            this.txtb_text_notice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_text_notice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_text_notice.Location = new System.Drawing.Point(21, 91);
            this.txtb_text_notice.Multiline = true;
            this.txtb_text_notice.Name = "txtb_text_notice";
            this.txtb_text_notice.Size = new System.Drawing.Size(346, 161);
            this.txtb_text_notice.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_error);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Controls.Add(this.txtb_text_notice);
            this.panel1.Controls.Add(this.txtb_title);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 368);
            this.panel1.TabIndex = 5;
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 316);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(387, 52);
            this.lbl_error.TabIndex = 51;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Yellow;
            this.btn_add.FlatAppearance.BorderSize = 2;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(245, 263);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(122, 36);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "ДОБАВИТЬ";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // add_notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "add_notice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Новое объявление *";
            this.Load += new System.EventHandler(this.add_notice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TextBox txtb_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_text_notice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_error;
    }
}