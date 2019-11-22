namespace dz_grb
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.table_layout_panel = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_red = new System.Windows.Forms.Label();
            this.lbl_green = new System.Windows.Forms.Label();
            this.lbl_blue = new System.Windows.Forms.Label();
            this.lbl_red_value = new System.Windows.Forms.Label();
            this.lbl_green_value = new System.Windows.Forms.Label();
            this.lbl_blue_value = new System.Windows.Forms.Label();
            this.panel_red = new System.Windows.Forms.Panel();
            this.scroll_red = new System.Windows.Forms.VScrollBar();
            this.panel_green = new System.Windows.Forms.Panel();
            this.scroll_green = new System.Windows.Forms.VScrollBar();
            this.panel_blue = new System.Windows.Forms.Panel();
            this.scroll_blue = new System.Windows.Forms.VScrollBar();
            this.panel_res_rgb = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.table_layout_panel.SuspendLayout();
            this.panel_red.SuspendLayout();
            this.panel_green.SuspendLayout();
            this.panel_blue.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.table_layout_panel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.panel_res_rgb);
            this.splitContainer1.Size = new System.Drawing.Size(732, 498);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // table_layout_panel
            // 
            this.table_layout_panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.table_layout_panel.ColumnCount = 3;
            this.table_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_layout_panel.Controls.Add(this.lbl_red, 0, 0);
            this.table_layout_panel.Controls.Add(this.lbl_green, 1, 0);
            this.table_layout_panel.Controls.Add(this.lbl_blue, 2, 0);
            this.table_layout_panel.Controls.Add(this.lbl_red_value, 0, 2);
            this.table_layout_panel.Controls.Add(this.lbl_green_value, 1, 2);
            this.table_layout_panel.Controls.Add(this.lbl_blue_value, 2, 2);
            this.table_layout_panel.Controls.Add(this.panel_red, 0, 1);
            this.table_layout_panel.Controls.Add(this.panel_green, 1, 1);
            this.table_layout_panel.Controls.Add(this.panel_blue, 2, 1);
            this.table_layout_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_panel.Location = new System.Drawing.Point(0, 0);
            this.table_layout_panel.Name = "table_layout_panel";
            this.table_layout_panel.RowCount = 3;
            this.table_layout_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.224319F));
            this.table_layout_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.77568F));
            this.table_layout_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.table_layout_panel.Size = new System.Drawing.Size(320, 498);
            this.table_layout_panel.TabIndex = 0;
            // 
            // lbl_red
            // 
            this.lbl_red.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_red.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_red.ForeColor = System.Drawing.Color.Red;
            this.lbl_red.Location = new System.Drawing.Point(3, 0);
            this.lbl_red.Name = "lbl_red";
            this.lbl_red.Size = new System.Drawing.Size(100, 42);
            this.lbl_red.TabIndex = 0;
            this.lbl_red.Text = "КРАСНЫЙ";
            this.lbl_red.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_green
            // 
            this.lbl_green.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_green.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_green.ForeColor = System.Drawing.Color.Green;
            this.lbl_green.Location = new System.Drawing.Point(109, 0);
            this.lbl_green.Name = "lbl_green";
            this.lbl_green.Size = new System.Drawing.Size(100, 42);
            this.lbl_green.TabIndex = 1;
            this.lbl_green.Text = "ЗЕЛЕНЫЙ";
            this.lbl_green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_blue
            // 
            this.lbl_blue.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_blue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_blue.ForeColor = System.Drawing.Color.Blue;
            this.lbl_blue.Location = new System.Drawing.Point(215, 0);
            this.lbl_blue.Name = "lbl_blue";
            this.lbl_blue.Size = new System.Drawing.Size(102, 42);
            this.lbl_blue.TabIndex = 2;
            this.lbl_blue.Text = "СИНИЙ";
            this.lbl_blue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_red_value
            // 
            this.lbl_red_value.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_red_value.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_red_value.ForeColor = System.Drawing.Color.Red;
            this.lbl_red_value.Location = new System.Drawing.Point(3, 458);
            this.lbl_red_value.Name = "lbl_red_value";
            this.lbl_red_value.Size = new System.Drawing.Size(100, 40);
            this.lbl_red_value.TabIndex = 3;
            this.lbl_red_value.Text = "0";
            this.lbl_red_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_green_value
            // 
            this.lbl_green_value.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_green_value.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_green_value.ForeColor = System.Drawing.Color.Green;
            this.lbl_green_value.Location = new System.Drawing.Point(109, 458);
            this.lbl_green_value.Name = "lbl_green_value";
            this.lbl_green_value.Size = new System.Drawing.Size(100, 40);
            this.lbl_green_value.TabIndex = 4;
            this.lbl_green_value.Text = "0";
            this.lbl_green_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_blue_value
            // 
            this.lbl_blue_value.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_blue_value.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_blue_value.ForeColor = System.Drawing.Color.Blue;
            this.lbl_blue_value.Location = new System.Drawing.Point(215, 458);
            this.lbl_blue_value.Name = "lbl_blue_value";
            this.lbl_blue_value.Size = new System.Drawing.Size(102, 40);
            this.lbl_blue_value.TabIndex = 5;
            this.lbl_blue_value.Text = "0";
            this.lbl_blue_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_red
            // 
            this.panel_red.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_red.Controls.Add(this.scroll_red);
            this.panel_red.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_red.Location = new System.Drawing.Point(3, 45);
            this.panel_red.Name = "panel_red";
            this.panel_red.Size = new System.Drawing.Size(100, 410);
            this.panel_red.TabIndex = 6;
            // 
            // scroll_red
            // 
            this.scroll_red.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scroll_red.Location = new System.Drawing.Point(38, 14);
            this.scroll_red.Maximum = 255;
            this.scroll_red.Name = "scroll_red";
            this.scroll_red.Size = new System.Drawing.Size(23, 379);
            this.scroll_red.TabIndex = 6;
            this.scroll_red.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_Scroll);
            // 
            // panel_green
            // 
            this.panel_green.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_green.Controls.Add(this.scroll_green);
            this.panel_green.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_green.Location = new System.Drawing.Point(109, 45);
            this.panel_green.Name = "panel_green";
            this.panel_green.Size = new System.Drawing.Size(100, 410);
            this.panel_green.TabIndex = 7;
            // 
            // scroll_green
            // 
            this.scroll_green.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scroll_green.Location = new System.Drawing.Point(37, 14);
            this.scroll_green.Maximum = 255;
            this.scroll_green.Name = "scroll_green";
            this.scroll_green.Size = new System.Drawing.Size(23, 379);
            this.scroll_green.TabIndex = 7;
            this.scroll_green.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_Scroll);
            // 
            // panel_blue
            // 
            this.panel_blue.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_blue.Controls.Add(this.scroll_blue);
            this.panel_blue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_blue.Location = new System.Drawing.Point(215, 45);
            this.panel_blue.Name = "panel_blue";
            this.panel_blue.Size = new System.Drawing.Size(102, 410);
            this.panel_blue.TabIndex = 8;
            // 
            // scroll_blue
            // 
            this.scroll_blue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scroll_blue.Location = new System.Drawing.Point(39, 14);
            this.scroll_blue.Maximum = 255;
            this.scroll_blue.Name = "scroll_blue";
            this.scroll_blue.Size = new System.Drawing.Size(23, 379);
            this.scroll_blue.TabIndex = 8;
            this.scroll_blue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_Scroll);
            // 
            // panel_res_rgb
            // 
            this.panel_res_rgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_res_rgb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_res_rgb.Location = new System.Drawing.Point(0, 0);
            this.panel_res_rgb.Name = "panel_res_rgb";
            this.panel_res_rgb.Size = new System.Drawing.Size(408, 498);
            this.panel_res_rgb.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(732, 498);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RGB";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.table_layout_panel.ResumeLayout(false);
            this.panel_red.ResumeLayout(false);
            this.panel_green.ResumeLayout(false);
            this.panel_blue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel table_layout_panel;
        private System.Windows.Forms.Label lbl_red;
        private System.Windows.Forms.Label lbl_green;
        private System.Windows.Forms.Label lbl_blue;
        private System.Windows.Forms.Label lbl_red_value;
        private System.Windows.Forms.Label lbl_green_value;
        private System.Windows.Forms.Label lbl_blue_value;
        private System.Windows.Forms.Panel panel_red;
        private System.Windows.Forms.VScrollBar scroll_red;
        private System.Windows.Forms.Panel panel_green;
        private System.Windows.Forms.VScrollBar scroll_green;
        private System.Windows.Forms.Panel panel_blue;
        private System.Windows.Forms.VScrollBar scroll_blue;
        private System.Windows.Forms.Panel panel_res_rgb;
    }
}

