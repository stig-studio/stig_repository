namespace dz_2_1
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmb_city = new System.Windows.Forms.ComboBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.group_continents = new System.Windows.Forms.GroupBox();
            this.rb_aust = new System.Windows.Forms.RadioButton();
            this.rb_n_america = new System.Windows.Forms.RadioButton();
            this.rb_s_america = new System.Windows.Forms.RadioButton();
            this.rb_asia = new System.Windows.Forms.RadioButton();
            this.rb_africa = new System.Windows.Forms.RadioButton();
            this.rb_europe = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ch_list_values = new System.Windows.Forms.CheckedListBox();
            this.lbl_header = new System.Windows.Forms.Label();
            this.selected_values = new System.Windows.Forms.ListBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.group_continents.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 527);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmb_city);
            this.tabPage1.Controls.Add(this.pb);
            this.tabPage1.Controls.Add(this.group_continents);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Города мира";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmb_city
            // 
            this.cmb_city.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_city.FormattingEnabled = true;
            this.cmb_city.Location = new System.Drawing.Point(180, 17);
            this.cmb_city.Name = "cmb_city";
            this.cmb_city.Size = new System.Drawing.Size(266, 21);
            this.cmb_city.TabIndex = 2;
            this.cmb_city.SelectedIndexChanged += new System.EventHandler(this.cmb_city_SelectedIndexChanged);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(180, 47);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(589, 425);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            // 
            // group_continents
            // 
            this.group_continents.Controls.Add(this.rb_aust);
            this.group_continents.Controls.Add(this.rb_n_america);
            this.group_continents.Controls.Add(this.rb_s_america);
            this.group_continents.Controls.Add(this.rb_asia);
            this.group_continents.Controls.Add(this.rb_africa);
            this.group_continents.Controls.Add(this.rb_europe);
            this.group_continents.Location = new System.Drawing.Point(16, 17);
            this.group_continents.Name = "group_continents";
            this.group_continents.Size = new System.Drawing.Size(158, 187);
            this.group_continents.TabIndex = 0;
            this.group_continents.TabStop = false;
            this.group_continents.Text = "Часть света";
            // 
            // rb_aust
            // 
            this.rb_aust.AutoSize = true;
            this.rb_aust.Location = new System.Drawing.Point(17, 145);
            this.rb_aust.Name = "rb_aust";
            this.rb_aust.Size = new System.Drawing.Size(80, 17);
            this.rb_aust.TabIndex = 5;
            this.rb_aust.TabStop = true;
            this.rb_aust.Tag = "5";
            this.rb_aust.Text = "Австралия";
            this.rb_aust.UseVisualStyleBackColor = true;
            this.rb_aust.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_n_america
            // 
            this.rb_n_america.AutoSize = true;
            this.rb_n_america.Location = new System.Drawing.Point(17, 122);
            this.rb_n_america.Name = "rb_n_america";
            this.rb_n_america.Size = new System.Drawing.Size(126, 17);
            this.rb_n_america.TabIndex = 4;
            this.rb_n_america.TabStop = true;
            this.rb_n_america.Tag = "4";
            this.rb_n_america.Text = "Северная Америка";
            this.rb_n_america.UseVisualStyleBackColor = true;
            this.rb_n_america.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_s_america
            // 
            this.rb_s_america.AutoSize = true;
            this.rb_s_america.Location = new System.Drawing.Point(17, 99);
            this.rb_s_america.Name = "rb_s_america";
            this.rb_s_america.Size = new System.Drawing.Size(114, 17);
            this.rb_s_america.TabIndex = 3;
            this.rb_s_america.TabStop = true;
            this.rb_s_america.Tag = "3";
            this.rb_s_america.Text = "Южная Америка";
            this.rb_s_america.UseVisualStyleBackColor = true;
            this.rb_s_america.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_asia
            // 
            this.rb_asia.AutoSize = true;
            this.rb_asia.Location = new System.Drawing.Point(17, 76);
            this.rb_asia.Name = "rb_asia";
            this.rb_asia.Size = new System.Drawing.Size(50, 17);
            this.rb_asia.TabIndex = 2;
            this.rb_asia.TabStop = true;
            this.rb_asia.Tag = "2";
            this.rb_asia.Text = "Азия";
            this.rb_asia.UseVisualStyleBackColor = true;
            this.rb_asia.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_africa
            // 
            this.rb_africa.AutoSize = true;
            this.rb_africa.Location = new System.Drawing.Point(17, 53);
            this.rb_africa.Name = "rb_africa";
            this.rb_africa.Size = new System.Drawing.Size(67, 17);
            this.rb_africa.TabIndex = 1;
            this.rb_africa.TabStop = true;
            this.rb_africa.Tag = "1";
            this.rb_africa.Text = "Африка";
            this.rb_africa.UseVisualStyleBackColor = true;
            this.rb_africa.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_europe
            // 
            this.rb_europe.AutoSize = true;
            this.rb_europe.Location = new System.Drawing.Point(17, 30);
            this.rb_europe.Name = "rb_europe";
            this.rb_europe.Size = new System.Drawing.Size(64, 17);
            this.rb_europe.TabIndex = 0;
            this.rb_europe.TabStop = true;
            this.rb_europe.Tag = "0";
            this.rb_europe.Text = "Европа";
            this.rb_europe.UseVisualStyleBackColor = true;
            this.rb_europe.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_msg);
            this.tabPage2.Controls.Add(this.lbl_result);
            this.tabPage2.Controls.Add(this.selected_values);
            this.tabPage2.Controls.Add(this.lbl_header);
            this.tabPage2.Controls.Add(this.ch_list_values);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(787, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Головоломка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ch_list_values
            // 
            this.ch_list_values.FormattingEnabled = true;
            this.ch_list_values.Items.AddRange(new object[] {
            "25",
            "27",
            "3",
            "12",
            "5",
            "15",
            "9",
            "30",
            "21",
            "19"});
            this.ch_list_values.Location = new System.Drawing.Point(37, 57);
            this.ch_list_values.Name = "ch_list_values";
            this.ch_list_values.Size = new System.Drawing.Size(156, 174);
            this.ch_list_values.TabIndex = 0;
            this.ch_list_values.SelectedValueChanged += new System.EventHandler(this.ch_list_values_SelectedValueChanged);
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Location = new System.Drawing.Point(41, 29);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(63, 13);
            this.lbl_header.TabIndex = 1;
            this.lbl_header.Text = "Собери 50";
            // 
            // selected_values
            // 
            this.selected_values.FormattingEnabled = true;
            this.selected_values.Location = new System.Drawing.Point(216, 59);
            this.selected_values.Name = "selected_values";
            this.selected_values.Size = new System.Drawing.Size(120, 95);
            this.selected_values.TabIndex = 2;
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Location = new System.Drawing.Point(220, 178);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(69, 13);
            this.lbl_result.TabIndex = 3;
            this.lbl_result.Text = "Результат: 0";
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_msg.ForeColor = System.Drawing.Color.Lime;
            this.lbl_msg.Location = new System.Drawing.Point(220, 204);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(74, 17);
            this.lbl_msg.TabIndex = 4;
            this.lbl_msg.Text = "ПОБЕДА!!!";
            this.lbl_msg.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 555);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.Text = "дз";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.group_continents.ResumeLayout(false);
            this.group_continents.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmb_city;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.GroupBox group_continents;
        private System.Windows.Forms.RadioButton rb_aust;
        private System.Windows.Forms.RadioButton rb_n_america;
        private System.Windows.Forms.RadioButton rb_s_america;
        private System.Windows.Forms.RadioButton rb_asia;
        private System.Windows.Forms.RadioButton rb_africa;
        private System.Windows.Forms.RadioButton rb_europe;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox selected_values;
        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.CheckedListBox ch_list_values;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label lbl_msg;
    }
}

