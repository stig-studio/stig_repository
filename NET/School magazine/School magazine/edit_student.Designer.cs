namespace School_magazine
{
    partial class edit_student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edit_student));
            this.lbl_panel_students_header = new System.Windows.Forms.Label();
            this.lbl_error = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.cmb_classes = new System.Windows.Forms.ComboBox();
            this.lbl_class = new System.Windows.Forms.Label();
            this.txtb_phone = new System.Windows.Forms.TextBox();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txtb_addr = new System.Windows.Forms.TextBox();
            this.lbl_addr = new System.Windows.Forms.Label();
            this.lbl_photo = new System.Windows.Forms.Label();
            this.txtb_photo = new System.Windows.Forms.TextBox();
            this.btn_photo_choise = new System.Windows.Forms.Button();
            this.pic_photo = new System.Windows.Forms.PictureBox();
            this.txtb_father_phone = new System.Windows.Forms.TextBox();
            this.lbl_father_phone = new System.Windows.Forms.Label();
            this.txtb_father = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_mother_phone = new System.Windows.Forms.TextBox();
            this.lbl_mother_phone = new System.Windows.Forms.Label();
            this.txtb_mother = new System.Windows.Forms.TextBox();
            this.lbl_mother = new System.Windows.Forms.Label();
            this.lbl_dob = new System.Windows.Forms.Label();
            this.txtb_dob = new System.Windows.Forms.TextBox();
            this.dtp_dob = new System.Windows.Forms.DateTimePicker();
            this.txtb_patr_name = new System.Windows.Forms.TextBox();
            this.lbl_patr_name = new System.Windows.Forms.Label();
            this.txtb_first_name = new System.Windows.Forms.TextBox();
            this.lbl_first_name = new System.Windows.Forms.Label();
            this.txtb_last_name = new System.Windows.Forms.TextBox();
            this.lbl_last_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_panel_students_header
            // 
            this.lbl_panel_students_header.BackColor = System.Drawing.Color.Purple;
            this.lbl_panel_students_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_panel_students_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_panel_students_header.ForeColor = System.Drawing.Color.White;
            this.lbl_panel_students_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_panel_students_header.Name = "lbl_panel_students_header";
            this.lbl_panel_students_header.Size = new System.Drawing.Size(746, 50);
            this.lbl_panel_students_header.TabIndex = 14;
            this.lbl_panel_students_header.Text = "  Редактирование данных о ученике";
            this.lbl_panel_students_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 469);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(746, 49);
            this.lbl_error.TabIndex = 103;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.BackColor = System.Drawing.Color.Purple;
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(573, 419);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(161, 34);
            this.btn_edit.TabIndex = 102;
            this.btn_edit.Text = "ИЗМЕНИТЬ";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // cmb_classes
            // 
            this.cmb_classes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_classes.FormattingEnabled = true;
            this.cmb_classes.Location = new System.Drawing.Point(123, 381);
            this.cmb_classes.Name = "cmb_classes";
            this.cmb_classes.Size = new System.Drawing.Size(161, 21);
            this.cmb_classes.TabIndex = 101;
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(18, 384);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(38, 13);
            this.lbl_class.TabIndex = 100;
            this.lbl_class.Text = "класс:";
            // 
            // txtb_phone
            // 
            this.txtb_phone.Location = new System.Drawing.Point(123, 353);
            this.txtb_phone.Name = "txtb_phone";
            this.txtb_phone.Size = new System.Drawing.Size(161, 22);
            this.txtb_phone.TabIndex = 99;
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(18, 356);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(56, 13);
            this.lbl_phone.TabIndex = 98;
            this.lbl_phone.Text = "телефон:";
            // 
            // txtb_addr
            // 
            this.txtb_addr.Location = new System.Drawing.Point(123, 325);
            this.txtb_addr.Name = "txtb_addr";
            this.txtb_addr.Size = new System.Drawing.Size(161, 22);
            this.txtb_addr.TabIndex = 97;
            // 
            // lbl_addr
            // 
            this.lbl_addr.AutoSize = true;
            this.lbl_addr.Location = new System.Drawing.Point(18, 328);
            this.lbl_addr.Name = "lbl_addr";
            this.lbl_addr.Size = new System.Drawing.Size(40, 13);
            this.lbl_addr.TabIndex = 96;
            this.lbl_addr.Text = "адрес:";
            // 
            // lbl_photo
            // 
            this.lbl_photo.AutoSize = true;
            this.lbl_photo.Location = new System.Drawing.Point(19, 302);
            this.lbl_photo.Name = "lbl_photo";
            this.lbl_photo.Size = new System.Drawing.Size(38, 13);
            this.lbl_photo.TabIndex = 95;
            this.lbl_photo.Text = "фото:";
            // 
            // txtb_photo
            // 
            this.txtb_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_photo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_photo.Location = new System.Drawing.Point(123, 297);
            this.txtb_photo.Name = "txtb_photo";
            this.txtb_photo.ReadOnly = true;
            this.txtb_photo.Size = new System.Drawing.Size(161, 22);
            this.txtb_photo.TabIndex = 93;
            // 
            // btn_photo_choise
            // 
            this.btn_photo_choise.BackColor = System.Drawing.Color.Purple;
            this.btn_photo_choise.FlatAppearance.BorderSize = 0;
            this.btn_photo_choise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_photo_choise.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_photo_choise.ForeColor = System.Drawing.Color.White;
            this.btn_photo_choise.Location = new System.Drawing.Point(286, 298);
            this.btn_photo_choise.Name = "btn_photo_choise";
            this.btn_photo_choise.Size = new System.Drawing.Size(32, 21);
            this.btn_photo_choise.TabIndex = 94;
            this.btn_photo_choise.Text = "...";
            this.btn_photo_choise.UseVisualStyleBackColor = false;
            this.btn_photo_choise.Click += new System.EventHandler(this.btn_photo_choise_Click);
            // 
            // pic_photo
            // 
            this.pic_photo.Image = global::School_magazine.Properties.Resources.photo_default;
            this.pic_photo.Location = new System.Drawing.Point(480, 77);
            this.pic_photo.Name = "pic_photo";
            this.pic_photo.Size = new System.Drawing.Size(254, 220);
            this.pic_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_photo.TabIndex = 92;
            this.pic_photo.TabStop = false;
            // 
            // txtb_father_phone
            // 
            this.txtb_father_phone.Location = new System.Drawing.Point(123, 269);
            this.txtb_father_phone.Name = "txtb_father_phone";
            this.txtb_father_phone.Size = new System.Drawing.Size(161, 22);
            this.txtb_father_phone.TabIndex = 91;
            // 
            // lbl_father_phone
            // 
            this.lbl_father_phone.AutoSize = true;
            this.lbl_father_phone.Location = new System.Drawing.Point(18, 272);
            this.lbl_father_phone.Name = "lbl_father_phone";
            this.lbl_father_phone.Size = new System.Drawing.Size(84, 13);
            this.lbl_father_phone.TabIndex = 90;
            this.lbl_father_phone.Text = "телефон отца:";
            // 
            // txtb_father
            // 
            this.txtb_father.Location = new System.Drawing.Point(123, 241);
            this.txtb_father.Name = "txtb_father";
            this.txtb_father.Size = new System.Drawing.Size(161, 22);
            this.txtb_father.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "отец:";
            // 
            // txtb_mother_phone
            // 
            this.txtb_mother_phone.Location = new System.Drawing.Point(123, 215);
            this.txtb_mother_phone.Name = "txtb_mother_phone";
            this.txtb_mother_phone.Size = new System.Drawing.Size(161, 22);
            this.txtb_mother_phone.TabIndex = 87;
            // 
            // lbl_mother_phone
            // 
            this.lbl_mother_phone.AutoSize = true;
            this.lbl_mother_phone.Location = new System.Drawing.Point(18, 218);
            this.lbl_mother_phone.Name = "lbl_mother_phone";
            this.lbl_mother_phone.Size = new System.Drawing.Size(98, 13);
            this.lbl_mother_phone.TabIndex = 86;
            this.lbl_mother_phone.Text = "телефон матери:";
            // 
            // txtb_mother
            // 
            this.txtb_mother.Location = new System.Drawing.Point(123, 187);
            this.txtb_mother.Name = "txtb_mother";
            this.txtb_mother.Size = new System.Drawing.Size(161, 22);
            this.txtb_mother.TabIndex = 85;
            // 
            // lbl_mother
            // 
            this.lbl_mother.AutoSize = true;
            this.lbl_mother.Location = new System.Drawing.Point(18, 190);
            this.lbl_mother.Name = "lbl_mother";
            this.lbl_mother.Size = new System.Drawing.Size(35, 13);
            this.lbl_mother.TabIndex = 84;
            this.lbl_mother.Text = "мать:";
            // 
            // lbl_dob
            // 
            this.lbl_dob.AutoSize = true;
            this.lbl_dob.Location = new System.Drawing.Point(19, 161);
            this.lbl_dob.Name = "lbl_dob";
            this.lbl_dob.Size = new System.Drawing.Size(91, 13);
            this.lbl_dob.TabIndex = 83;
            this.lbl_dob.Text = "дата рождения:";
            // 
            // txtb_dob
            // 
            this.txtb_dob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_dob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtb_dob.Location = new System.Drawing.Point(123, 158);
            this.txtb_dob.Name = "txtb_dob";
            this.txtb_dob.Size = new System.Drawing.Size(161, 23);
            this.txtb_dob.TabIndex = 82;
            // 
            // dtp_dob
            // 
            this.dtp_dob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_dob.Location = new System.Drawing.Point(285, 158);
            this.dtp_dob.Name = "dtp_dob";
            this.dtp_dob.Size = new System.Drawing.Size(20, 23);
            this.dtp_dob.TabIndex = 81;
            this.dtp_dob.ValueChanged += new System.EventHandler(this.dtp_dob_ValueChanged);
            // 
            // txtb_patr_name
            // 
            this.txtb_patr_name.Location = new System.Drawing.Point(123, 130);
            this.txtb_patr_name.Name = "txtb_patr_name";
            this.txtb_patr_name.Size = new System.Drawing.Size(161, 22);
            this.txtb_patr_name.TabIndex = 80;
            // 
            // lbl_patr_name
            // 
            this.lbl_patr_name.AutoSize = true;
            this.lbl_patr_name.Location = new System.Drawing.Point(18, 133);
            this.lbl_patr_name.Name = "lbl_patr_name";
            this.lbl_patr_name.Size = new System.Drawing.Size(58, 13);
            this.lbl_patr_name.TabIndex = 79;
            this.lbl_patr_name.Text = "отчество:";
            // 
            // txtb_first_name
            // 
            this.txtb_first_name.Location = new System.Drawing.Point(123, 102);
            this.txtb_first_name.Name = "txtb_first_name";
            this.txtb_first_name.Size = new System.Drawing.Size(161, 22);
            this.txtb_first_name.TabIndex = 78;
            // 
            // lbl_first_name
            // 
            this.lbl_first_name.AutoSize = true;
            this.lbl_first_name.Location = new System.Drawing.Point(18, 105);
            this.lbl_first_name.Name = "lbl_first_name";
            this.lbl_first_name.Size = new System.Drawing.Size(31, 13);
            this.lbl_first_name.TabIndex = 77;
            this.lbl_first_name.Text = "имя:";
            // 
            // txtb_last_name
            // 
            this.txtb_last_name.Location = new System.Drawing.Point(123, 74);
            this.txtb_last_name.Name = "txtb_last_name";
            this.txtb_last_name.Size = new System.Drawing.Size(161, 22);
            this.txtb_last_name.TabIndex = 76;
            // 
            // lbl_last_name
            // 
            this.lbl_last_name.AutoSize = true;
            this.lbl_last_name.Location = new System.Drawing.Point(18, 77);
            this.lbl_last_name.Name = "lbl_last_name";
            this.lbl_last_name.Size = new System.Drawing.Size(59, 13);
            this.lbl_last_name.TabIndex = 75;
            this.lbl_last_name.Text = "фамилия:";
            // 
            // edit_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 518);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.cmb_classes);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.txtb_phone);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.txtb_addr);
            this.Controls.Add(this.lbl_addr);
            this.Controls.Add(this.lbl_photo);
            this.Controls.Add(this.txtb_photo);
            this.Controls.Add(this.btn_photo_choise);
            this.Controls.Add(this.pic_photo);
            this.Controls.Add(this.txtb_father_phone);
            this.Controls.Add(this.lbl_father_phone);
            this.Controls.Add(this.txtb_father);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_mother_phone);
            this.Controls.Add(this.lbl_mother_phone);
            this.Controls.Add(this.txtb_mother);
            this.Controls.Add(this.lbl_mother);
            this.Controls.Add(this.lbl_dob);
            this.Controls.Add(this.txtb_dob);
            this.Controls.Add(this.dtp_dob);
            this.Controls.Add(this.txtb_patr_name);
            this.Controls.Add(this.lbl_patr_name);
            this.Controls.Add(this.txtb_first_name);
            this.Controls.Add(this.lbl_first_name);
            this.Controls.Add(this.txtb_last_name);
            this.Controls.Add(this.lbl_last_name);
            this.Controls.Add(this.lbl_panel_students_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "edit_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Редактирование данных о ученике *";
            this.Load += new System.EventHandler(this.edit_student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_panel_students_header;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.ComboBox cmb_classes;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.TextBox txtb_phone;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.TextBox txtb_addr;
        private System.Windows.Forms.Label lbl_addr;
        private System.Windows.Forms.Label lbl_photo;
        private System.Windows.Forms.TextBox txtb_photo;
        private System.Windows.Forms.Button btn_photo_choise;
        private System.Windows.Forms.PictureBox pic_photo;
        private System.Windows.Forms.TextBox txtb_father_phone;
        private System.Windows.Forms.Label lbl_father_phone;
        private System.Windows.Forms.TextBox txtb_father;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_mother_phone;
        private System.Windows.Forms.Label lbl_mother_phone;
        private System.Windows.Forms.TextBox txtb_mother;
        private System.Windows.Forms.Label lbl_mother;
        private System.Windows.Forms.Label lbl_dob;
        private System.Windows.Forms.TextBox txtb_dob;
        private System.Windows.Forms.DateTimePicker dtp_dob;
        private System.Windows.Forms.TextBox txtb_patr_name;
        private System.Windows.Forms.Label lbl_patr_name;
        private System.Windows.Forms.TextBox txtb_first_name;
        private System.Windows.Forms.Label lbl_first_name;
        private System.Windows.Forms.TextBox txtb_last_name;
        private System.Windows.Forms.Label lbl_last_name;
    }
}