namespace Exam
{
    partial class main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clients_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.file_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.client_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.client_list_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.about_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clients_tool_strip,
            this.file_tool_strip,
            this.client_tool_strip,
            this.about_tool_strip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clients_tool_strip
            // 
            this.clients_tool_strip.Name = "clients_tool_strip";
            this.clients_tool_strip.Size = new System.Drawing.Size(12, 20);
            // 
            // file_tool_strip
            // 
            this.file_tool_strip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exit_tool_strip});
            this.file_tool_strip.Name = "file_tool_strip";
            this.file_tool_strip.Size = new System.Drawing.Size(53, 20);
            this.file_tool_strip.Text = "ФАЙЛ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exit_tool_strip
            // 
            this.exit_tool_strip.Name = "exit_tool_strip";
            this.exit_tool_strip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exit_tool_strip.Size = new System.Drawing.Size(180, 22);
            this.exit_tool_strip.Text = "Выход";
            this.exit_tool_strip.Click += new System.EventHandler(this.exit_tool_strip_Click);
            // 
            // client_tool_strip
            // 
            this.client_tool_strip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.client_list_tool_strip});
            this.client_tool_strip.Name = "client_tool_strip";
            this.client_tool_strip.Size = new System.Drawing.Size(74, 20);
            this.client_tool_strip.Text = "КЛИЕНТЫ";
            // 
            // client_list_tool_strip
            // 
            this.client_list_tool_strip.Name = "client_list_tool_strip";
            this.client_list_tool_strip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.client_list_tool_strip.Size = new System.Drawing.Size(213, 22);
            this.client_list_tool_strip.Text = " Список клиентов";
            this.client_list_tool_strip.Click += new System.EventHandler(this.client_list_tool_strip_Click);
            // 
            // about_tool_strip
            // 
            this.about_tool_strip.Name = "about_tool_strip";
            this.about_tool_strip.Size = new System.Drawing.Size(105, 20);
            this.about_tool_strip.Text = "О ПРОГРАММЕ";
            this.about_tool_strip.Click += new System.EventHandler(this.about_tool_strip_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 412);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main_form";
            this.Text = "Брачное агенство";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_form_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clients_tool_strip;
        private System.Windows.Forms.ToolStripMenuItem file_tool_strip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exit_tool_strip;
        private System.Windows.Forms.ToolStripMenuItem client_tool_strip;
        private System.Windows.Forms.ToolStripMenuItem client_list_tool_strip;
        private System.Windows.Forms.ToolStripMenuItem about_tool_strip;
    }
}

