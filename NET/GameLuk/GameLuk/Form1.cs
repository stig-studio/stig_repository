using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameLuk {

    public partial class Form1 : Form {

        const int begin_btn = 12;             // позиция первой кнопки по X
        const int end_btn = 486;              // позиция последней кнопки X

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            btn1.Click += new EventHandler( btn_right_Click );
            btn2.Click += new EventHandler( btn_right_Click );
            btn3.Click += new EventHandler( btn_right_Click );

            btn4.Click += new EventHandler( btn_left_Click );
            btn5.Click += new EventHandler( btn_left_Click );
            btn6.Click += new EventHandler( btn_left_Click );

        }

        private void btn_right_Click(object sender, EventArgs e) {

            if (((Button)sender).Location.X < end_btn) {

                int step_1 = 0;
                int step_2 = 0;
                int quantity = 0;

                foreach (var item in Controls) {

                    if (item.GetType() == typeof(Button) && ((Button)item).Name != ((Button)sender).Name) {

                        if(((Button)item).Location.X > ((Button)sender).Location.X) {

                            if (((Button)item).Location.X == ((Button)sender).Location.X + 79 && ((Button)item).Location.X < end_btn ) step_1++;
                            else if (((Button)item).Location.X == end_btn && ((Button)item).Location.X == ((Button)sender).Location.X + 79) step_1++;
                            if (((Button)item).Location.X == ((Button)sender).Location.X + 158) step_2++;
                            quantity++;
                        }
                    }
                }

                if (step_2 == 0) {
                    if (((Button)sender).Location.X + 158 <= end_btn)
                        ((Button)sender).Location = new Point(((Button)sender).Location.X + 158, ((Button)sender).Location.Y);
                    else if (quantity == 0)
                        ((Button)sender).Location = new Point(((Button)sender).Location.X + 79, ((Button)sender).Location.Y);
                }
                else if (step_1 == 0) {
                    ((Button)sender).Location = new Point(((Button)sender).Location.X + 79, ((Button)sender).Location.Y);
                }
            }
            check_order();
        }

        private void btn_left_Click(object sender, EventArgs e) {

            if (((Button)sender).Location.X > begin_btn) {

                int step_1 = 0;
                int step_2 = 0;
                int quantity = 0;

                foreach (var item in Controls) {

                    if (item.GetType() == typeof(Button) && ((Button)item).Name != ((Button)sender).Name) {

                        if (((Button)item).Location.X < ((Button)sender).Location.X) {

                            if (((Button)item).Location.X == ((Button)sender).Location.X - 79) step_1++;
                            else if (((Button)item).Location.X == begin_btn && ((Button)item).Location.X == ((Button)sender).Location.X - 79) step_1++;
                            if (((Button)item).Location.X == ((Button)sender).Location.X - 158) step_2++;
                            quantity++;
                        }
                    }
                }

                if (step_2 == 0) {
                    if(((Button)sender).Location.X - 158 >= begin_btn)
                        ((Button)sender).Location = new Point(((Button)sender).Location.X - 158, ((Button)sender).Location.Y);
                    else if (quantity == 0)
                        ((Button)sender).Location = new Point(((Button)sender).Location.X - 79, ((Button)sender).Location.Y);
                }
                else if (step_1 == 0) ((Button)sender).Location = new Point(((Button)sender).Location.X - 79, ((Button)sender).Location.Y);
            }
            check_order();
        }

        private void check_order() {

            bool left = false;
            bool right = false;

            if (btn1.Location.X == end_btn && btn2.Location.X == end_btn - 79 && btn3.Location.X == end_btn - 158)
                right = true;
            else if (btn1.Location.X == end_btn && btn3.Location.X == end_btn - 79 && btn2.Location.X == end_btn - 158)
                right = true;
            else if (btn2.Location.X == end_btn && btn1.Location.X == end_btn - 79 && btn3.Location.X == end_btn - 158)
                right = true;
            else if (btn2.Location.X == end_btn && btn3.Location.X == end_btn - 79 && btn1.Location.X == end_btn - 158)
                right = true;
            else if (btn3.Location.X == end_btn && btn1.Location.X == end_btn - 79 && btn2.Location.X == end_btn - 158)
                right = true;
            else if (btn3.Location.X == end_btn && btn2.Location.X == end_btn - 79 && btn1.Location.X == end_btn - 158)
                right = true;

            if (btn6.Location.X == begin_btn && btn5.Location.X == begin_btn + 79 && btn4.Location.X == begin_btn + 158)
                left = true;
            else if (btn6.Location.X == begin_btn && btn4.Location.X == begin_btn + 79 && btn5.Location.X == begin_btn + 158)
                left = true;
            else if (btn5.Location.X == begin_btn && btn6.Location.X == begin_btn + 79 && btn4.Location.X == begin_btn + 158)
                left = true;
            else if (btn5.Location.X == begin_btn && btn4.Location.X == begin_btn + 79 && btn6.Location.X == begin_btn + 158)
                left = true;
            else if (btn4.Location.X == begin_btn && btn6.Location.X == begin_btn + 79 && btn5.Location.X == begin_btn + 158)
                left = true;
            else if (btn4.Location.X == begin_btn && btn5.Location.X == begin_btn + 79 && btn6.Location.X == begin_btn + 158)
                left = true;

            if (left == true && right == true) this.Text = "Победа!";
        }
    }
}