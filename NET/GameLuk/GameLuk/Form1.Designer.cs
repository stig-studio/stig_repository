﻿namespace GameLuk
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
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.White;
            this.btn5.Image = global::GameLuk.Properties.Resources.icons8_назад_64;
            this.btn5.Location = new System.Drawing.Point(407, 12);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(73, 60);
            this.btn5.TabIndex = 5;
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.White;
            this.btn6.Image = global::GameLuk.Properties.Resources.icons8_назад_64;
            this.btn6.Location = new System.Drawing.Point(486, 12);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(73, 60);
            this.btn6.TabIndex = 6;
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.White;
            this.btn4.Image = global::GameLuk.Properties.Resources.icons8_назад_64;
            this.btn4.Location = new System.Drawing.Point(328, 12);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(73, 60);
            this.btn4.TabIndex = 4;
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.White;
            this.btn3.Image = global::GameLuk.Properties.Resources.icons8_вперед_64;
            this.btn3.Location = new System.Drawing.Point(170, 12);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(73, 60);
            this.btn3.TabIndex = 2;
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.White;
            this.btn2.Image = global::GameLuk.Properties.Resources.icons8_вперед_64;
            this.btn2.Location = new System.Drawing.Point(91, 12);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(73, 60);
            this.btn2.TabIndex = 1;
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.White;
            this.btn1.Image = global::GameLuk.Properties.Resources.icons8_вперед_64;
            this.btn1.Location = new System.Drawing.Point(12, 12);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(73, 60);
            this.btn1.TabIndex = 0;
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 86);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Игра";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
    }
}

