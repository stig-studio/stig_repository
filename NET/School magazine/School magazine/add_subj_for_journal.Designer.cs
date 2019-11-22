namespace School_magazine
{
    partial class add_subj_for_journal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_subj_for_journal));
            this.lbl_panel_journal_header = new System.Windows.Forms.Label();
            this.lbl_class_value = new System.Windows.Forms.Label();
            this.lbl_class = new System.Windows.Forms.Label();
            this.lbl_subj = new System.Windows.Forms.Label();
            this.cmb_subj = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
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
            this.lbl_panel_journal_header.Size = new System.Drawing.Size(366, 50);
            this.lbl_panel_journal_header.TabIndex = 15;
            this.lbl_panel_journal_header.Text = "  Новый предмет в журнал";
            this.lbl_panel_journal_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_class_value
            // 
            this.lbl_class_value.AutoSize = true;
            this.lbl_class_value.Location = new System.Drawing.Point(82, 65);
            this.lbl_class_value.Name = "lbl_class_value";
            this.lbl_class_value.Size = new System.Drawing.Size(63, 13);
            this.lbl_class_value.TabIndex = 18;
            this.lbl_class_value.Text = "class_value";
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(12, 65);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(38, 13);
            this.lbl_class.TabIndex = 17;
            this.lbl_class.Text = "класс:";
            // 
            // lbl_subj
            // 
            this.lbl_subj.AutoSize = true;
            this.lbl_subj.Location = new System.Drawing.Point(12, 95);
            this.lbl_subj.Name = "lbl_subj";
            this.lbl_subj.Size = new System.Drawing.Size(55, 13);
            this.lbl_subj.TabIndex = 19;
            this.lbl_subj.Text = "предмет:";
            // 
            // cmb_subj
            // 
            this.cmb_subj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_subj.FormattingEnabled = true;
            this.cmb_subj.Location = new System.Drawing.Point(85, 92);
            this.cmb_subj.Name = "cmb_subj";
            this.cmb_subj.Size = new System.Drawing.Size(269, 21);
            this.cmb_subj.TabIndex = 20;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(219, 129);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(135, 29);
            this.btn_add.TabIndex = 21;
            this.btn_add.Text = "ДОБАВИТЬ";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(0, 171);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(366, 46);
            this.lbl_error.TabIndex = 76;
            this.lbl_error.Text = "error";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // add_subj_for_journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(366, 217);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_subj);
            this.Controls.Add(this.lbl_subj);
            this.Controls.Add(this.lbl_class_value);
            this.Controls.Add(this.lbl_class);
            this.Controls.Add(this.lbl_panel_journal_header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "add_subj_for_journal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Новый предмет в журнал *";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_panel_journal_header;
        private System.Windows.Forms.Label lbl_class_value;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.Label lbl_subj;
        private System.Windows.Forms.ComboBox cmb_subj;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_error;
    }
}