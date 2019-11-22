namespace School_magazine
{
    partial class NoticeItem
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.text_notice = new System.Windows.Forms.TextBox();
            this.date_notice = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(275, 39);
            this.title.TabIndex = 1;
            this.title.Text = "title";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_notice
            // 
            this.text_notice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_notice.BackColor = System.Drawing.Color.White;
            this.text_notice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_notice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_notice.Location = new System.Drawing.Point(7, 42);
            this.text_notice.Multiline = true;
            this.text_notice.Name = "text_notice";
            this.text_notice.ReadOnly = true;
            this.text_notice.Size = new System.Drawing.Size(344, 63);
            this.text_notice.TabIndex = 2;
            this.text_notice.Text = "text";
            // 
            // date_notice
            // 
            this.date_notice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_notice.AutoSize = true;
            this.date_notice.Location = new System.Drawing.Point(290, 13);
            this.date_notice.Name = "date_notice";
            this.date_notice.Size = new System.Drawing.Size(30, 13);
            this.date_notice.TabIndex = 3;
            this.date_notice.Text = "date";
            // 
            // author
            // 
            this.author.BackColor = System.Drawing.Color.White;
            this.author.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.author.Location = new System.Drawing.Point(0, 108);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(361, 17);
            this.author.TabIndex = 4;
            this.author.Text = "author";
            this.author.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoticeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.author);
            this.Controls.Add(this.date_notice);
            this.Controls.Add(this.text_notice);
            this.Controls.Add(this.title);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "NoticeItem";
            this.Size = new System.Drawing.Size(361, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label title;
        public System.Windows.Forms.TextBox text_notice;
        public System.Windows.Forms.Label date_notice;
        public System.Windows.Forms.Label author;
    }
}
