namespace School_magazine
{
    partial class StudentItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_dob_val = new System.Windows.Forms.Label();
            this.lbl_dob = new System.Windows.Forms.Label();
            this.lbl_full_name_val = new System.Windows.Forms.Label();
            this.lbl_full_name = new System.Windows.Forms.Label();
            this.pic_photo = new System.Windows.Forms.PictureBox();
            this.lbl_mother_value = new System.Windows.Forms.Label();
            this.lbl_mother = new System.Windows.Forms.Label();
            this.lbl_father_value = new System.Windows.Forms.Label();
            this.lbl_father = new System.Windows.Forms.Label();
            this.lbl_mother_phone_value = new System.Windows.Forms.Label();
            this.lbl_mother_phone = new System.Windows.Forms.Label();
            this.lbl_father_phone_value = new System.Windows.Forms.Label();
            this.lbl_father_phone = new System.Windows.Forms.Label();
            this.lbl_addr_value = new System.Windows.Forms.Label();
            this.lbl_addr = new System.Windows.Forms.Label();
            this.lbl_phone_value = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl_class_value = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Image = global::School_magazine.Properties.Resources.edit_black_20;
            this.btn_edit.Location = new System.Drawing.Point(501, 13);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(37, 33);
            this.btn_edit.TabIndex = 47;
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // lbl_dob_val
            // 
            this.lbl_dob_val.AutoSize = true;
            this.lbl_dob_val.ForeColor = System.Drawing.Color.Black;
            this.lbl_dob_val.Location = new System.Drawing.Point(306, 37);
            this.lbl_dob_val.Name = "lbl_dob_val";
            this.lbl_dob_val.Size = new System.Drawing.Size(28, 13);
            this.lbl_dob_val.TabIndex = 36;
            this.lbl_dob_val.Text = "dob";
            // 
            // lbl_dob
            // 
            this.lbl_dob.AutoSize = true;
            this.lbl_dob.ForeColor = System.Drawing.Color.Black;
            this.lbl_dob.Location = new System.Drawing.Point(201, 37);
            this.lbl_dob.Name = "lbl_dob";
            this.lbl_dob.Size = new System.Drawing.Size(93, 13);
            this.lbl_dob.TabIndex = 35;
            this.lbl_dob.Text = "Дата рождения:";
            // 
            // lbl_full_name_val
            // 
            this.lbl_full_name_val.AutoSize = true;
            this.lbl_full_name_val.ForeColor = System.Drawing.Color.Black;
            this.lbl_full_name_val.Location = new System.Drawing.Point(306, 15);
            this.lbl_full_name_val.Name = "lbl_full_name_val";
            this.lbl_full_name_val.Size = new System.Drawing.Size(57, 13);
            this.lbl_full_name_val.TabIndex = 34;
            this.lbl_full_name_val.Text = "full_name";
            // 
            // lbl_full_name
            // 
            this.lbl_full_name.AutoSize = true;
            this.lbl_full_name.ForeColor = System.Drawing.Color.Black;
            this.lbl_full_name.Location = new System.Drawing.Point(201, 15);
            this.lbl_full_name.Name = "lbl_full_name";
            this.lbl_full_name.Size = new System.Drawing.Size(34, 13);
            this.lbl_full_name.TabIndex = 33;
            this.lbl_full_name.Text = "ФИО:";
            // 
            // pic_photo
            // 
            this.pic_photo.Image = global::School_magazine.Properties.Resources.photo_default;
            this.pic_photo.Location = new System.Drawing.Point(16, 15);
            this.pic_photo.Name = "pic_photo";
            this.pic_photo.Size = new System.Drawing.Size(164, 152);
            this.pic_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_photo.TabIndex = 32;
            this.pic_photo.TabStop = false;
            // 
            // lbl_mother_value
            // 
            this.lbl_mother_value.AutoSize = true;
            this.lbl_mother_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_mother_value.Location = new System.Drawing.Point(306, 62);
            this.lbl_mother_value.Name = "lbl_mother_value";
            this.lbl_mother_value.Size = new System.Drawing.Size(44, 13);
            this.lbl_mother_value.TabIndex = 49;
            this.lbl_mother_value.Text = "mother";
            // 
            // lbl_mother
            // 
            this.lbl_mother.AutoSize = true;
            this.lbl_mother.ForeColor = System.Drawing.Color.Black;
            this.lbl_mother.Location = new System.Drawing.Point(201, 62);
            this.lbl_mother.Name = "lbl_mother";
            this.lbl_mother.Size = new System.Drawing.Size(37, 13);
            this.lbl_mother.TabIndex = 48;
            this.lbl_mother.Text = "Мать:";
            // 
            // lbl_father_value
            // 
            this.lbl_father_value.AutoSize = true;
            this.lbl_father_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_father_value.Location = new System.Drawing.Point(306, 112);
            this.lbl_father_value.Name = "lbl_father_value";
            this.lbl_father_value.Size = new System.Drawing.Size(38, 13);
            this.lbl_father_value.TabIndex = 51;
            this.lbl_father_value.Text = "father";
            // 
            // lbl_father
            // 
            this.lbl_father.AutoSize = true;
            this.lbl_father.ForeColor = System.Drawing.Color.Black;
            this.lbl_father.Location = new System.Drawing.Point(201, 112);
            this.lbl_father.Name = "lbl_father";
            this.lbl_father.Size = new System.Drawing.Size(37, 13);
            this.lbl_father.TabIndex = 50;
            this.lbl_father.Text = "Отец:";
            // 
            // lbl_mother_phone_value
            // 
            this.lbl_mother_phone_value.AutoSize = true;
            this.lbl_mother_phone_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_mother_phone_value.Location = new System.Drawing.Point(306, 86);
            this.lbl_mother_phone_value.Name = "lbl_mother_phone_value";
            this.lbl_mother_phone_value.Size = new System.Drawing.Size(83, 13);
            this.lbl_mother_phone_value.TabIndex = 53;
            this.lbl_mother_phone_value.Text = "mother_phone";
            // 
            // lbl_mother_phone
            // 
            this.lbl_mother_phone.AutoSize = true;
            this.lbl_mother_phone.ForeColor = System.Drawing.Color.Black;
            this.lbl_mother_phone.Location = new System.Drawing.Point(201, 86);
            this.lbl_mother_phone.Name = "lbl_mother_phone";
            this.lbl_mother_phone.Size = new System.Drawing.Size(98, 13);
            this.lbl_mother_phone.TabIndex = 52;
            this.lbl_mother_phone.Text = "Телефон матери:";
            // 
            // lbl_father_phone_value
            // 
            this.lbl_father_phone_value.AutoSize = true;
            this.lbl_father_phone_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_father_phone_value.Location = new System.Drawing.Point(306, 137);
            this.lbl_father_phone_value.Name = "lbl_father_phone_value";
            this.lbl_father_phone_value.Size = new System.Drawing.Size(77, 13);
            this.lbl_father_phone_value.TabIndex = 55;
            this.lbl_father_phone_value.Text = "father_phone";
            // 
            // lbl_father_phone
            // 
            this.lbl_father_phone.AutoSize = true;
            this.lbl_father_phone.ForeColor = System.Drawing.Color.Black;
            this.lbl_father_phone.Location = new System.Drawing.Point(201, 137);
            this.lbl_father_phone.Name = "lbl_father_phone";
            this.lbl_father_phone.Size = new System.Drawing.Size(84, 13);
            this.lbl_father_phone.TabIndex = 54;
            this.lbl_father_phone.Text = "Телефон отца:";
            // 
            // lbl_addr_value
            // 
            this.lbl_addr_value.AutoSize = true;
            this.lbl_addr_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_addr_value.Location = new System.Drawing.Point(306, 164);
            this.lbl_addr_value.Name = "lbl_addr_value";
            this.lbl_addr_value.Size = new System.Drawing.Size(31, 13);
            this.lbl_addr_value.TabIndex = 57;
            this.lbl_addr_value.Text = "addr";
            // 
            // lbl_addr
            // 
            this.lbl_addr.AutoSize = true;
            this.lbl_addr.ForeColor = System.Drawing.Color.Black;
            this.lbl_addr.Location = new System.Drawing.Point(201, 164);
            this.lbl_addr.Name = "lbl_addr";
            this.lbl_addr.Size = new System.Drawing.Size(41, 13);
            this.lbl_addr.TabIndex = 56;
            this.lbl_addr.Text = "Адрес:";
            // 
            // lbl_phone_value
            // 
            this.lbl_phone_value.AutoSize = true;
            this.lbl_phone_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_phone_value.Location = new System.Drawing.Point(306, 189);
            this.lbl_phone_value.Name = "lbl_phone_value";
            this.lbl_phone_value.Size = new System.Drawing.Size(41, 13);
            this.lbl_phone_value.TabIndex = 59;
            this.lbl_phone_value.Text = "phone";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.ForeColor = System.Drawing.Color.Black;
            this.lbl_phone.Location = new System.Drawing.Point(201, 189);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(56, 13);
            this.lbl_phone.TabIndex = 58;
            this.lbl_phone.Text = "Телефон:";
            // 
            // lbl_class_value
            // 
            this.lbl_class_value.AutoSize = true;
            this.lbl_class_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_class_value.Location = new System.Drawing.Point(306, 214);
            this.lbl_class_value.Name = "lbl_class_value";
            this.lbl_class_value.Size = new System.Drawing.Size(31, 13);
            this.lbl_class_value.TabIndex = 61;
            this.lbl_class_value.Text = "class";
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.ForeColor = System.Drawing.Color.Black;
            this.lbl_class.Location = new System.Drawing.Point(201, 214);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(38, 13);
            this.lbl_class.TabIndex = 60;
            this.lbl_class.Text = "Класс:";
            // 
            // StudentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_class_value);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_phone_value);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.lbl_addr_value);
            this.Controls.Add(this.lbl_addr);
            this.Controls.Add(this.lbl_father_phone_value);
            this.Controls.Add(this.lbl_father_phone);
            this.Controls.Add(this.lbl_mother_phone_value);
            this.Controls.Add(this.lbl_mother_phone);
            this.Controls.Add(this.lbl_father_value);
            this.Controls.Add(this.lbl_father);
            this.Controls.Add(this.lbl_mother_value);
            this.Controls.Add(this.lbl_mother);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.lbl_dob_val);
            this.Controls.Add(this.lbl_dob);
            this.Controls.Add(this.lbl_full_name_val);
            this.Controls.Add(this.lbl_full_name);
            this.Controls.Add(this.pic_photo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StudentItem";
            this.Size = new System.Drawing.Size(541, 243);
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_edit;
        public System.Windows.Forms.Label lbl_dob_val;
        private System.Windows.Forms.Label lbl_dob;
        public System.Windows.Forms.Label lbl_full_name_val;
        private System.Windows.Forms.Label lbl_full_name;
        public System.Windows.Forms.PictureBox pic_photo;
        public System.Windows.Forms.Label lbl_mother_value;
        private System.Windows.Forms.Label lbl_mother;
        public System.Windows.Forms.Label lbl_father_value;
        private System.Windows.Forms.Label lbl_father;
        public System.Windows.Forms.Label lbl_mother_phone_value;
        private System.Windows.Forms.Label lbl_mother_phone;
        public System.Windows.Forms.Label lbl_father_phone_value;
        private System.Windows.Forms.Label lbl_father_phone;
        public System.Windows.Forms.Label lbl_addr_value;
        private System.Windows.Forms.Label lbl_addr;
        public System.Windows.Forms.Label lbl_phone_value;
        private System.Windows.Forms.Label lbl_phone;
        public System.Windows.Forms.Label lbl_class_value;
        private System.Windows.Forms.Label lbl_class;
    }
}
