namespace Shop
{
    partial class FormUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
            this.panel_sale = new System.Windows.Forms.Panel();
            this.dtp_sale = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_sum_sale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_sellers = new System.Windows.Forms.ComboBox();
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.lbl_seller = new System.Windows.Forms.Label();
            this.lbl_customer = new System.Windows.Forms.Label();
            this.panel_full_name = new System.Windows.Forms.Panel();
            this.txtb_first_name = new System.Windows.Forms.TextBox();
            this.lbl_f_name = new System.Windows.Forms.Label();
            this.txtb_last_name = new System.Windows.Forms.TextBox();
            this.lbl_l_name = new System.Windows.Forms.Label();
            this.btn_update_item = new System.Windows.Forms.Button();
            this.panel_sale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sum_sale)).BeginInit();
            this.panel_full_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_sale
            // 
            this.panel_sale.Controls.Add(this.dtp_sale);
            this.panel_sale.Controls.Add(this.label2);
            this.panel_sale.Controls.Add(this.nud_sum_sale);
            this.panel_sale.Controls.Add(this.label1);
            this.panel_sale.Controls.Add(this.cmb_sellers);
            this.panel_sale.Controls.Add(this.cmb_customers);
            this.panel_sale.Controls.Add(this.lbl_seller);
            this.panel_sale.Controls.Add(this.lbl_customer);
            this.panel_sale.Location = new System.Drawing.Point(12, 90);
            this.panel_sale.Name = "panel_sale";
            this.panel_sale.Size = new System.Drawing.Size(306, 132);
            this.panel_sale.TabIndex = 10;
            this.panel_sale.Visible = false;
            // 
            // dtp_sale
            // 
            this.dtp_sale.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtp_sale.Location = new System.Drawing.Point(91, 100);
            this.dtp_sale.Name = "dtp_sale";
            this.dtp_sale.Size = new System.Drawing.Size(120, 20);
            this.dtp_sale.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ДАТА:";
            // 
            // nud_sum_sale
            // 
            this.nud_sum_sale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nud_sum_sale.DecimalPlaces = 2;
            this.nud_sum_sale.Location = new System.Drawing.Point(91, 69);
            this.nud_sum_sale.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nud_sum_sale.Name = "nud_sum_sale";
            this.nud_sum_sale.Size = new System.Drawing.Size(120, 20);
            this.nud_sum_sale.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "СУММА:";
            // 
            // cmb_sellers
            // 
            this.cmb_sellers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sellers.FormattingEnabled = true;
            this.cmb_sellers.Location = new System.Drawing.Point(91, 39);
            this.cmb_sellers.Name = "cmb_sellers";
            this.cmb_sellers.Size = new System.Drawing.Size(202, 21);
            this.cmb_sellers.TabIndex = 5;
            // 
            // cmb_customers
            // 
            this.cmb_customers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(91, 9);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(202, 21);
            this.cmb_customers.TabIndex = 4;
            // 
            // lbl_seller
            // 
            this.lbl_seller.AutoSize = true;
            this.lbl_seller.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_seller.ForeColor = System.Drawing.Color.Blue;
            this.lbl_seller.Location = new System.Drawing.Point(6, 42);
            this.lbl_seller.Name = "lbl_seller";
            this.lbl_seller.Size = new System.Drawing.Size(69, 13);
            this.lbl_seller.TabIndex = 2;
            this.lbl_seller.Text = "ПРОДАВЕЦ:";
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_customer.ForeColor = System.Drawing.Color.Blue;
            this.lbl_customer.Location = new System.Drawing.Point(6, 12);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(78, 13);
            this.lbl_customer.TabIndex = 0;
            this.lbl_customer.Text = "ПОКУПАТЕЛЬ:";
            // 
            // panel_full_name
            // 
            this.panel_full_name.BackColor = System.Drawing.Color.White;
            this.panel_full_name.Controls.Add(this.txtb_first_name);
            this.panel_full_name.Controls.Add(this.lbl_f_name);
            this.panel_full_name.Controls.Add(this.txtb_last_name);
            this.panel_full_name.Controls.Add(this.lbl_l_name);
            this.panel_full_name.Location = new System.Drawing.Point(12, 12);
            this.panel_full_name.Name = "panel_full_name";
            this.panel_full_name.Size = new System.Drawing.Size(306, 72);
            this.panel_full_name.TabIndex = 9;
            this.panel_full_name.Visible = false;
            // 
            // txtb_first_name
            // 
            this.txtb_first_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtb_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_first_name.Location = new System.Drawing.Point(91, 40);
            this.txtb_first_name.Name = "txtb_first_name";
            this.txtb_first_name.Size = new System.Drawing.Size(202, 20);
            this.txtb_first_name.TabIndex = 3;
            // 
            // lbl_f_name
            // 
            this.lbl_f_name.AutoSize = true;
            this.lbl_f_name.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_f_name.ForeColor = System.Drawing.Color.Blue;
            this.lbl_f_name.Location = new System.Drawing.Point(6, 43);
            this.lbl_f_name.Name = "lbl_f_name";
            this.lbl_f_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_f_name.TabIndex = 2;
            this.lbl_f_name.Text = "ИМЯ:";
            // 
            // txtb_last_name
            // 
            this.txtb_last_name.BackColor = System.Drawing.Color.Gainsboro;
            this.txtb_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_last_name.Location = new System.Drawing.Point(91, 9);
            this.txtb_last_name.Name = "txtb_last_name";
            this.txtb_last_name.Size = new System.Drawing.Size(202, 20);
            this.txtb_last_name.TabIndex = 1;
            // 
            // lbl_l_name
            // 
            this.lbl_l_name.AutoSize = true;
            this.lbl_l_name.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_l_name.ForeColor = System.Drawing.Color.Blue;
            this.lbl_l_name.Location = new System.Drawing.Point(6, 13);
            this.lbl_l_name.Name = "lbl_l_name";
            this.lbl_l_name.Size = new System.Drawing.Size(64, 13);
            this.lbl_l_name.TabIndex = 0;
            this.lbl_l_name.Text = "ФАМИЛИЯ:";
            // 
            // btn_update_item
            // 
            this.btn_update_item.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_update_item.BackColor = System.Drawing.Color.Blue;
            this.btn_update_item.FlatAppearance.BorderSize = 0;
            this.btn_update_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update_item.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_update_item.ForeColor = System.Drawing.Color.White;
            this.btn_update_item.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_update_item.Location = new System.Drawing.Point(324, 110);
            this.btn_update_item.Name = "btn_update_item";
            this.btn_update_item.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btn_update_item.Size = new System.Drawing.Size(137, 34);
            this.btn_update_item.TabIndex = 11;
            this.btn_update_item.Text = "ОБНОВИТЬ";
            this.btn_update_item.UseVisualStyleBackColor = false;
            this.btn_update_item.Click += new System.EventHandler(this.btn_update_item_Click);
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 156);
            this.Controls.Add(this.btn_update_item);
            this.Controls.Add(this.panel_sale);
            this.Controls.Add(this.panel_full_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUpdate";
            this.Text = "Изменение записи";
            this.panel_sale.ResumeLayout(false);
            this.panel_sale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sum_sale)).EndInit();
            this.panel_full_name.ResumeLayout(false);
            this.panel_full_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sale;
        private System.Windows.Forms.DateTimePicker dtp_sale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_sum_sale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_sellers;
        private System.Windows.Forms.ComboBox cmb_customers;
        private System.Windows.Forms.Label lbl_seller;
        private System.Windows.Forms.Label lbl_customer;
        private System.Windows.Forms.Panel panel_full_name;
        private System.Windows.Forms.TextBox txtb_first_name;
        private System.Windows.Forms.Label lbl_f_name;
        private System.Windows.Forms.TextBox txtb_last_name;
        private System.Windows.Forms.Label lbl_l_name;
        private System.Windows.Forms.Button btn_update_item;
    }
}