namespace test_graph
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
            this.btn_create = new System.Windows.Forms.Button();
            this.txtb_temp = new System.Windows.Forms.TextBox();
            this.panel_graph = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.Green;
            this.btn_create.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_create.ForeColor = System.Drawing.Color.White;
            this.btn_create.Location = new System.Drawing.Point(12, 12);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(141, 37);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "Create graphic";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // txtb_temp
            // 
            this.txtb_temp.Location = new System.Drawing.Point(12, 55);
            this.txtb_temp.Name = "txtb_temp";
            this.txtb_temp.Size = new System.Drawing.Size(141, 20);
            this.txtb_temp.TabIndex = 2;
            // 
            // panel_graph
            // 
            this.panel_graph.Location = new System.Drawing.Point(159, 12);
            this.panel_graph.Name = "panel_graph";
            this.panel_graph.Size = new System.Drawing.Size(576, 399);
            this.panel_graph.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(749, 423);
            this.Controls.Add(this.panel_graph);
            this.Controls.Add(this.txtb_temp);
            this.Controls.Add(this.btn_create);
            this.Name = "Form1";
            this.Text = "Graphic test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox txtb_temp;
        private System.Windows.Forms.Panel panel_graph;
    }
}

