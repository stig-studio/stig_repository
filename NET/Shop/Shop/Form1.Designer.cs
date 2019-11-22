namespace Shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.list_box_info = new System.Windows.Forms.ListBox();
            this.panel_caption = new System.Windows.Forms.Panel();
            this.btn_test_connection = new System.Windows.Forms.Button();
            this.btn_sales = new System.Windows.Forms.Button();
            this.btn_sallers = new System.Windows.Forms.Button();
            this.btn_customers = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_maximize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_caption.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_box_info
            // 
            this.list_box_info.BackColor = System.Drawing.SystemColors.ControlDark;
            this.list_box_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_box_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_box_info.ForeColor = System.Drawing.Color.White;
            this.list_box_info.FormattingEnabled = true;
            this.list_box_info.Location = new System.Drawing.Point(0, 169);
            this.list_box_info.Name = "list_box_info";
            this.list_box_info.Size = new System.Drawing.Size(679, 78);
            this.list_box_info.TabIndex = 2;
            // 
            // panel_caption
            // 
            this.panel_caption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_caption.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_caption.Controls.Add(this.btn_test_connection);
            this.panel_caption.Controls.Add(this.btn_sales);
            this.panel_caption.Controls.Add(this.btn_sallers);
            this.panel_caption.Controls.Add(this.btn_customers);
            this.panel_caption.Location = new System.Drawing.Point(0, 33);
            this.panel_caption.Name = "panel_caption";
            this.panel_caption.Size = new System.Drawing.Size(679, 134);
            this.panel_caption.TabIndex = 6;
            // 
            // btn_test_connection
            // 
            this.btn_test_connection.BackColor = System.Drawing.Color.Red;
            this.btn_test_connection.FlatAppearance.BorderSize = 0;
            this.btn_test_connection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_test_connection.ForeColor = System.Drawing.Color.White;
            this.btn_test_connection.Image = global::Shop.Properties.Resources.test;
            this.btn_test_connection.Location = new System.Drawing.Point(507, 20);
            this.btn_test_connection.Name = "btn_test_connection";
            this.btn_test_connection.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btn_test_connection.Size = new System.Drawing.Size(159, 90);
            this.btn_test_connection.TabIndex = 3;
            this.btn_test_connection.Text = "ПРОВЕРКА ПОДКЛЮЧЕНИЯ";
            this.btn_test_connection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_test_connection.UseVisualStyleBackColor = false;
            this.btn_test_connection.Click += new System.EventHandler(this.btn_test_connection_Click);
            // 
            // btn_sales
            // 
            this.btn_sales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_sales.FlatAppearance.BorderSize = 0;
            this.btn_sales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sales.ForeColor = System.Drawing.Color.White;
            this.btn_sales.Image = global::Shop.Properties.Resources.cart;
            this.btn_sales.Location = new System.Drawing.Point(342, 20);
            this.btn_sales.Name = "btn_sales";
            this.btn_sales.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btn_sales.Size = new System.Drawing.Size(159, 90);
            this.btn_sales.TabIndex = 2;
            this.btn_sales.Text = "ПРОДАЖИ";
            this.btn_sales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sales.UseVisualStyleBackColor = false;
            this.btn_sales.Click += new System.EventHandler(this.btn_table_Click);
            // 
            // btn_sallers
            // 
            this.btn_sallers.BackColor = System.Drawing.Color.BlueViolet;
            this.btn_sallers.FlatAppearance.BorderSize = 0;
            this.btn_sallers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sallers.ForeColor = System.Drawing.Color.White;
            this.btn_sallers.Image = global::Shop.Properties.Resources.saller;
            this.btn_sallers.Location = new System.Drawing.Point(177, 20);
            this.btn_sallers.Name = "btn_sallers";
            this.btn_sallers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btn_sallers.Size = new System.Drawing.Size(159, 90);
            this.btn_sallers.TabIndex = 1;
            this.btn_sallers.Text = "ПРОДАВЦЫ";
            this.btn_sallers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sallers.UseVisualStyleBackColor = false;
            this.btn_sallers.Click += new System.EventHandler(this.btn_table_Click);
            // 
            // btn_customers
            // 
            this.btn_customers.BackColor = System.Drawing.Color.Blue;
            this.btn_customers.FlatAppearance.BorderSize = 0;
            this.btn_customers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_customers.ForeColor = System.Drawing.Color.White;
            this.btn_customers.Image = global::Shop.Properties.Resources.customers;
            this.btn_customers.Location = new System.Drawing.Point(12, 20);
            this.btn_customers.Name = "btn_customers";
            this.btn_customers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btn_customers.Size = new System.Drawing.Size(159, 90);
            this.btn_customers.TabIndex = 0;
            this.btn_customers.Text = "ПОКУПАТЕЛИ";
            this.btn_customers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_customers.UseVisualStyleBackColor = false;
            this.btn_customers.Click += new System.EventHandler(this.btn_table_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Image = global::Shop.Properties.Resources.minimize;
            this.btn_minimize.Location = new System.Drawing.Point(596, 5);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(21, 21);
            this.btn_minimize.TabIndex = 4;
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_maximize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_maximize.FlatAppearance.BorderSize = 0;
            this.btn_maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maximize.Image = global::Shop.Properties.Resources.maximize;
            this.btn_maximize.Location = new System.Drawing.Point(623, 5);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(21, 21);
            this.btn_maximize.TabIndex = 5;
            this.btn_maximize.UseVisualStyleBackColor = true;
            this.btn_maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::Shop.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(650, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 21);
            this.btn_close.TabIndex = 3;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "SHOP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(679, 247);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_minimize);
            this.Controls.Add(this.panel_caption);
            this.Controls.Add(this.btn_maximize);
            this.Controls.Add(this.list_box_info);
            this.Controls.Add(this.btn_close);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_caption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox list_box_info;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_maximize;
        private System.Windows.Forms.Panel panel_caption;
        private System.Windows.Forms.Button btn_customers;
        private System.Windows.Forms.Button btn_sallers;
        private System.Windows.Forms.Button btn_sales;
        private System.Windows.Forms.Button btn_test_connection;
        private System.Windows.Forms.Label label1;
    }
}

