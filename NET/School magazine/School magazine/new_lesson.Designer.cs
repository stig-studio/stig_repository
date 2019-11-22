namespace School_magazine
{
    partial class new_lesson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(new_lesson));
            this.lbl_panel_journal_header = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            this.lbl_class_value = new System.Windows.Forms.Label();
            this.lbl_subj_value = new System.Windows.Forms.Label();
            this.lbl_subj = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.txtb_dob = new System.Windows.Forms.TextBox();
            this.dtp_dob = new System.Windows.Forms.DateTimePicker();
            this.lbl_theme = new System.Windows.Forms.Label();
            this.txtb_theme = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_panel_journal_header
            // 
            this.lbl_panel_journal_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbl_panel_journal_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_panel_journal_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_panel_journal_header.ForeColor = System.Drawing.Color.White;
            this.lbl_panel_journal_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_panel_journal_header.Name = "lbl_panel_journal_header";
            this.lbl_panel_journal_header.Size = new System.Drawing.Size(758, 50);
            this.lbl_panel_journal_header.TabIndex = 14;
            this.lbl_panel_journal_header.Text = "  Создание нового урока";
            this.lbl_panel_journal_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(11, 70);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(38, 13);
            this.lbl_class.TabIndex = 15;
            this.lbl_class.Text = "класс:";
            // 
            // lbl_class_value
            // 
            this.lbl_class_value.AutoSize = true;
            this.lbl_class_value.Location = new System.Drawing.Point(81, 70);
            this.lbl_class_value.Name = "lbl_class_value";
            this.lbl_class_value.Size = new System.Drawing.Size(63, 13);
            this.lbl_class_value.TabIndex = 16;
            this.lbl_class_value.Text = "class_value";
            // 
            // lbl_subj_value
            // 
            this.lbl_subj_value.AutoSize = true;
            this.lbl_subj_value.Location = new System.Drawing.Point(82, 96);
            this.lbl_subj_value.Name = "lbl_subj_value";
            this.lbl_subj_value.Size = new System.Drawing.Size(61, 13);
            this.lbl_subj_value.TabIndex = 18;
            this.lbl_subj_value.Text = "subj_value";
            // 
            // lbl_subj
            // 
            this.lbl_subj.AutoSize = true;
            this.lbl_subj.Location = new System.Drawing.Point(12, 96);
            this.lbl_subj.Name = "lbl_subj";
            this.lbl_subj.Size = new System.Drawing.Size(55, 13);
            this.lbl_subj.TabIndex = 17;
            this.lbl_subj.Text = "предмет:";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(11, 126);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(67, 13);
            this.lbl_date.TabIndex = 19;
            this.lbl_date.Text = "дата урока:";
            // 
            // txtb_dob
            // 
            this.txtb_dob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_dob.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_dob.Location = new System.Drawing.Point(84, 122);
            this.txtb_dob.Name = "txtb_dob";
            this.txtb_dob.Size = new System.Drawing.Size(98, 22);
            this.txtb_dob.TabIndex = 55;
            // 
            // dtp_dob
            // 
            this.dtp_dob.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_dob.Location = new System.Drawing.Point(183, 122);
            this.dtp_dob.Name = "dtp_dob";
            this.dtp_dob.Size = new System.Drawing.Size(20, 22);
            this.dtp_dob.TabIndex = 54;
            this.dtp_dob.ValueChanged += new System.EventHandler(this.dtp_dob_ValueChanged);
            // 
            // lbl_theme
            // 
            this.lbl_theme.AutoSize = true;
            this.lbl_theme.Location = new System.Drawing.Point(9, 154);
            this.lbl_theme.Name = "lbl_theme";
            this.lbl_theme.Size = new System.Drawing.Size(69, 13);
            this.lbl_theme.TabIndex = 56;
            this.lbl_theme.Text = "тема урока:";
            // 
            // txtb_theme
            // 
            this.txtb_theme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_theme.Location = new System.Drawing.Point(84, 151);
            this.txtb_theme.Name = "txtb_theme";
            this.txtb_theme.Size = new System.Drawing.Size(652, 22);
            this.txtb_theme.TabIndex = 57;
            // 
            // btn_create
            // 
            this.btn_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_create.FlatAppearance.BorderSize = 0;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_create.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_create.ForeColor = System.Drawing.Color.White;
            this.btn_create.Location = new System.Drawing.Point(12, 197);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(732, 44);
            this.btn_create.TabIndex = 58;
            this.btn_create.Text = "СОЗДАТЬ";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 255);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(758, 51);
            this.lbl_error.TabIndex = 75;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // new_lesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(758, 306);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.txtb_theme);
            this.Controls.Add(this.lbl_theme);
            this.Controls.Add(this.txtb_dob);
            this.Controls.Add(this.dtp_dob);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_subj_value);
            this.Controls.Add(this.lbl_subj);
            this.Controls.Add(this.lbl_class_value);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_panel_journal_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "new_lesson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Новы урок *";
            this.Load += new System.EventHandler(this.new_lesson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_panel_journal_header;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.Label lbl_class_value;
        private System.Windows.Forms.Label lbl_subj_value;
        private System.Windows.Forms.Label lbl_subj;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.TextBox txtb_dob;
        private System.Windows.Forms.DateTimePicker dtp_dob;
        private System.Windows.Forms.Label lbl_theme;
        private System.Windows.Forms.TextBox txtb_theme;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label lbl_error;
    }
}