namespace School_magazine
{
    partial class add_subject_for_schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_subject_for_schedule));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            this.cmb_classes = new System.Windows.Forms.ComboBox();
            this.lbl_subj = new System.Windows.Forms.Label();
            this.cmb_subj = new System.Windows.Forms.ComboBox();
            this.lbl_number = new System.Windows.Forms.Label();
            this.cmb_numbers = new System.Windows.Forms.ComboBox();
            this.cmb_teachers = new System.Windows.Forms.ComboBox();
            this.lbl_teacher = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.cmb_day_of_week = new System.Windows.Forms.ComboBox();
            this.lbl_day_of_week = new System.Windows.Forms.Label();
            this.cmb_semestr = new System.Windows.Forms.ComboBox();
            this.lbl_semestr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_header.ForeColor = System.Drawing.Color.White;
            this.lbl_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(483, 50);
            this.lbl_header.TabIndex = 3;
            this.lbl_header.Text = "  Редактирование расписания";
            this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(60, 101);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(38, 13);
            this.lbl_class.TabIndex = 4;
            this.lbl_class.Text = "Класс:";
            // 
            // cmb_classes
            // 
            this.cmb_classes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_classes.FormattingEnabled = true;
            this.cmb_classes.Location = new System.Drawing.Point(104, 98);
            this.cmb_classes.Name = "cmb_classes";
            this.cmb_classes.Size = new System.Drawing.Size(278, 21);
            this.cmb_classes.TabIndex = 5;
            // 
            // lbl_subj
            // 
            this.lbl_subj.AutoSize = true;
            this.lbl_subj.Location = new System.Drawing.Point(42, 142);
            this.lbl_subj.Name = "lbl_subj";
            this.lbl_subj.Size = new System.Drawing.Size(56, 13);
            this.lbl_subj.TabIndex = 6;
            this.lbl_subj.Text = "Предмет:";
            // 
            // cmb_subj
            // 
            this.cmb_subj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_subj.FormattingEnabled = true;
            this.cmb_subj.Location = new System.Drawing.Point(104, 139);
            this.cmb_subj.Name = "cmb_subj";
            this.cmb_subj.Size = new System.Drawing.Size(278, 21);
            this.cmb_subj.TabIndex = 7;
            // 
            // lbl_number
            // 
            this.lbl_number.AutoSize = true;
            this.lbl_number.Location = new System.Drawing.Point(52, 255);
            this.lbl_number.Name = "lbl_number";
            this.lbl_number.Size = new System.Drawing.Size(46, 13);
            this.lbl_number.TabIndex = 8;
            this.lbl_number.Text = "Номер:";
            // 
            // cmb_numbers
            // 
            this.cmb_numbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_numbers.FormattingEnabled = true;
            this.cmb_numbers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmb_numbers.Location = new System.Drawing.Point(104, 252);
            this.cmb_numbers.Name = "cmb_numbers";
            this.cmb_numbers.Size = new System.Drawing.Size(278, 21);
            this.cmb_numbers.TabIndex = 9;
            // 
            // cmb_teachers
            // 
            this.cmb_teachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_teachers.FormattingEnabled = true;
            this.cmb_teachers.Location = new System.Drawing.Point(104, 292);
            this.cmb_teachers.Name = "cmb_teachers";
            this.cmb_teachers.Size = new System.Drawing.Size(278, 21);
            this.cmb_teachers.TabIndex = 11;
            // 
            // lbl_teacher
            // 
            this.lbl_teacher.AutoSize = true;
            this.lbl_teacher.Location = new System.Drawing.Point(45, 295);
            this.lbl_teacher.Name = "lbl_teacher";
            this.lbl_teacher.Size = new System.Drawing.Size(53, 13);
            this.lbl_teacher.TabIndex = 10;
            this.lbl_teacher.Text = "Учитель:";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(104, 332);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(278, 26);
            this.btn_add.TabIndex = 12;
            this.btn_add.Text = "ДОБАВИТЬ";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 485);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(483, 63);
            this.lbl_error.TabIndex = 51;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(104, 364);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(278, 26);
            this.btn_update.TabIndex = 52;
            this.btn_update.Text = "ИЗМЕНИТЬ";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.Red;
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.ForeColor = System.Drawing.Color.White;
            this.btn_del.Location = new System.Drawing.Point(104, 396);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(278, 26);
            this.btn_del.TabIndex = 53;
            this.btn_del.Text = "УДАЛИТЬ";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // cmb_day_of_week
            // 
            this.cmb_day_of_week.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_day_of_week.FormattingEnabled = true;
            this.cmb_day_of_week.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб"});
            this.cmb_day_of_week.Location = new System.Drawing.Point(104, 211);
            this.cmb_day_of_week.Name = "cmb_day_of_week";
            this.cmb_day_of_week.Size = new System.Drawing.Size(278, 21);
            this.cmb_day_of_week.TabIndex = 55;
            // 
            // lbl_day_of_week
            // 
            this.lbl_day_of_week.AutoSize = true;
            this.lbl_day_of_week.Location = new System.Drawing.Point(20, 214);
            this.lbl_day_of_week.Name = "lbl_day_of_week";
            this.lbl_day_of_week.Size = new System.Drawing.Size(78, 13);
            this.lbl_day_of_week.TabIndex = 54;
            this.lbl_day_of_week.Text = "День недели:";
            // 
            // cmb_semestr
            // 
            this.cmb_semestr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_semestr.FormattingEnabled = true;
            this.cmb_semestr.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmb_semestr.Location = new System.Drawing.Point(104, 176);
            this.cmb_semestr.Name = "cmb_semestr";
            this.cmb_semestr.Size = new System.Drawing.Size(278, 21);
            this.cmb_semestr.TabIndex = 57;
            // 
            // lbl_semestr
            // 
            this.lbl_semestr.AutoSize = true;
            this.lbl_semestr.Location = new System.Drawing.Point(42, 180);
            this.lbl_semestr.Name = "lbl_semestr";
            this.lbl_semestr.Size = new System.Drawing.Size(54, 13);
            this.lbl_semestr.TabIndex = 56;
            this.lbl_semestr.Text = "Семестр:";
            // 
            // add_subject_for_schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 548);
            this.Controls.Add(this.cmb_semestr);
            this.Controls.Add(this.lbl_semestr);
            this.Controls.Add(this.cmb_day_of_week);
            this.Controls.Add(this.lbl_day_of_week);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_teachers);
            this.Controls.Add(this.lbl_teacher);
            this.Controls.Add(this.cmb_numbers);
            this.Controls.Add(this.lbl_number);
            this.Controls.Add(this.cmb_subj);
            this.Controls.Add(this.lbl_subj);
            this.Controls.Add(this.cmb_classes);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "add_subject_for_schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   Редактирование расписания";
            this.Load += new System.EventHandler(this.add_subject_for_schedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.ComboBox cmb_classes;
        private System.Windows.Forms.Label lbl_subj;
        private System.Windows.Forms.ComboBox cmb_subj;
        private System.Windows.Forms.Label lbl_number;
        private System.Windows.Forms.ComboBox cmb_numbers;
        private System.Windows.Forms.ComboBox cmb_teachers;
        private System.Windows.Forms.Label lbl_teacher;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.ComboBox cmb_day_of_week;
        private System.Windows.Forms.Label lbl_day_of_week;
        private System.Windows.Forms.ComboBox cmb_semestr;
        private System.Windows.Forms.Label lbl_semestr;
    }
}