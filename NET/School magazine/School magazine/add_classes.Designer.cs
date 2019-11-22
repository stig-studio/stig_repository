namespace School_magazine
{
    partial class add_classes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_classes));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            this.txtb_class_name = new System.Windows.Forms.TextBox();
            this.lbl_teacher = new System.Windows.Forms.Label();
            this.cmb_teacher = new System.Windows.Forms.ComboBox();
            this.btn_add_class = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.BackColor = System.Drawing.Color.Orange;
            this.lbl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_header.ForeColor = System.Drawing.Color.White;
            this.lbl_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(357, 50);
            this.lbl_header.TabIndex = 2;
            this.lbl_header.Text = "  Добавление нового класса";
            this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.ForeColor = System.Drawing.Color.Black;
            this.lbl_class.Location = new System.Drawing.Point(57, 111);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(91, 13);
            this.lbl_class.TabIndex = 3;
            this.lbl_class.Text = "Наименование:";
            // 
            // txtb_class_name
            // 
            this.txtb_class_name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_class_name.Location = new System.Drawing.Point(60, 127);
            this.txtb_class_name.Name = "txtb_class_name";
            this.txtb_class_name.Size = new System.Drawing.Size(235, 22);
            this.txtb_class_name.TabIndex = 4;
            // 
            // lbl_teacher
            // 
            this.lbl_teacher.AutoSize = true;
            this.lbl_teacher.ForeColor = System.Drawing.Color.Black;
            this.lbl_teacher.Location = new System.Drawing.Point(57, 167);
            this.lbl_teacher.Name = "lbl_teacher";
            this.lbl_teacher.Size = new System.Drawing.Size(137, 13);
            this.lbl_teacher.TabIndex = 5;
            this.lbl_teacher.Text = "Классный руководитель:";
            // 
            // cmb_teacher
            // 
            this.cmb_teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_teacher.FormattingEnabled = true;
            this.cmb_teacher.Location = new System.Drawing.Point(60, 183);
            this.cmb_teacher.Name = "cmb_teacher";
            this.cmb_teacher.Size = new System.Drawing.Size(235, 21);
            this.cmb_teacher.TabIndex = 6;
            // 
            // btn_add_class
            // 
            this.btn_add_class.BackColor = System.Drawing.Color.Orange;
            this.btn_add_class.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_add_class.FlatAppearance.BorderSize = 0;
            this.btn_add_class.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_class.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add_class.ForeColor = System.Drawing.Color.White;
            this.btn_add_class.Location = new System.Drawing.Point(162, 225);
            this.btn_add_class.Name = "btn_add_class";
            this.btn_add_class.Size = new System.Drawing.Size(133, 36);
            this.btn_add_class.TabIndex = 7;
            this.btn_add_class.Text = "ДОБАВИТЬ";
            this.btn_add_class.UseVisualStyleBackColor = false;
            this.btn_add_class.Click += new System.EventHandler(this.btn_add_class_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 307);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(357, 74);
            this.lbl_error.TabIndex = 51;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // add_classes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(357, 381);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_add_class);
            this.Controls.Add(this.cmb_teacher);
            this.Controls.Add(this.lbl_teacher);
            this.Controls.Add(this.txtb_class_name);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "add_classes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Добавление нового класса *";
            this.Load += new System.EventHandler(this.add_classes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.TextBox txtb_class_name;
        private System.Windows.Forms.Label lbl_teacher;
        private System.Windows.Forms.ComboBox cmb_teacher;
        private System.Windows.Forms.Button btn_add_class;
        private System.Windows.Forms.Label lbl_error;
    }
}