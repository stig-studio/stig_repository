namespace game_tag
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.table_board = new System.Windows.Forms.TableLayoutPanel();
            this.p_bar = new System.Windows.Forms.ProgressBar();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_counter = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // table_board
            // 
            this.table_board.BackColor = System.Drawing.Color.Black;
            this.table_board.ColumnCount = 4;
            this.table_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.Location = new System.Drawing.Point(12, 57);
            this.table_board.Name = "table_board";
            this.table_board.RowCount = 4;
            this.table_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_board.Size = new System.Drawing.Size(397, 331);
            this.table_board.TabIndex = 0;
            // 
            // p_bar
            // 
            this.p_bar.Location = new System.Drawing.Point(12, 403);
            this.p_bar.Maximum = 15;
            this.p_bar.Name = "p_bar";
            this.p_bar.Size = new System.Drawing.Size(397, 29);
            this.p_bar.Step = 1;
            this.p_bar.TabIndex = 1;
            // 
            // btn_update
            // 
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.Location = new System.Drawing.Point(350, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(59, 48);
            this.btn_update.TabIndex = 2;
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_counter
            // 
            this.lbl_counter.AutoSize = true;
            this.lbl_counter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_counter.ForeColor = System.Drawing.Color.Green;
            this.lbl_counter.Location = new System.Drawing.Point(21, 16);
            this.lbl_counter.Name = "lbl_counter";
            this.lbl_counter.Size = new System.Drawing.Size(63, 21);
            this.lbl_counter.TabIndex = 3;
            this.lbl_counter.Text = "Счет: 0";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_time.ForeColor = System.Drawing.Color.Green;
            this.lbl_time.Location = new System.Drawing.Point(150, 16);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(50, 21);
            this.lbl_time.TabIndex = 4;
            this.lbl_time.Text = "00:00";
            // 
            // timer_time
            // 
            this.timer_time.Interval = 1000;
            this.timer_time.Tick += new System.EventHandler(this.timer_time_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(422, 449);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_counter);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.p_bar);
            this.Controls.Add(this.table_board);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Пятнашки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_board;
        private System.Windows.Forms.ProgressBar p_bar;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_counter;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Timer timer_time;
    }
}

