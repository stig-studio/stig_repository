using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace game_tag {

    public partial class Form1 : Form {

        private int counter;
        private DateTime time;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e ) {

            counter = 0;
            time = new DateTime( 0, 0 );

            create_btn();
        }

        private void btn_update_Click( object sender, EventArgs e ) {

            table_board.Controls.Clear();
            lbl_counter.Text = "Счет: 0";

            create_btn();

            p_bar.Value = 0;

            order_check();
        }

        private void btn_play_Click( object sender, EventArgs e ) {

            counter++;                              // счетчик кнопок
            lbl_counter.Text = $"Счет: {counter}";

            if ( timer_time.Enabled == false ) timer_time.Enabled = true;

            int pos_x = -1;     int pos_y = -1;     //  позиция кликнутой кнопки
            int empty_x = -1;   int empty_y = -1;   //  позиция пустой ячейки

            for ( int i = 0; i < 4; i++ ) {

                for( int j = 0; j < 4; j++ ) {

                    Control curr_btn = table_board.GetControlFromPosition( i, j );

                    if ( curr_btn.Text == "16" ) { empty_x = i; empty_y = j; }
                    else if ( curr_btn.Name == ( sender as Button ).Name ) { pos_x = i;  pos_y = j; }

                    if ( empty_x != -1 && pos_x != -1 && pos_x != -1 && pos_y != -1 ) {

                        if (empty_x == pos_x && empty_y == pos_y + 1 || empty_x == pos_x && empty_y == pos_y - 1
                            || empty_x == pos_x + 1 && empty_y == pos_y || empty_x == pos_x - 1 && empty_y == pos_y) {

                            try {

                                Control btn = table_board.GetControlFromPosition(pos_x, pos_y);
                                Control empty = table_board.GetControlFromPosition(empty_x, empty_y);
                                
                                table_board.SetColumn(empty, pos_x);
                                table_board.SetRow(empty, pos_y);
                                
                                table_board.SetColumn(btn, empty_x);
                                table_board.SetRow(btn, empty_y);
                                
                                order_check();
                            }
                            catch( Exception ex ) {
                                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            }
                        }
                        return;
                    }
                }
            }
        }

        private void create_btn() {

            Dictionary<int, Button> btn_list = new Dictionary<int, Button>();

            Random rnd = new Random( DateTime.Now.Millisecond );

            for ( int i = 1; i < 17; i++ ) {

                Application.DoEvents();

                int numb = rnd.Next( 1, 17 );

                if ( btn_list.ContainsKey( numb ) == true ) {
                    while ( btn_list.ContainsKey( numb ) == true ) { numb = rnd.Next( 1, 17 ); }
                }

                Button btn = new Button();

                if( numb == 16 ) {

                    btn.Name = $"btn{i}";
                    btn.Text = numb.ToString();
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                    btn.BackColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.Black;
                    btn.FlatAppearance.MouseDownBackColor = Color.Black;
                    btn.Dock = DockStyle.Fill;

                }
                else {

                    btn.Name = $"btn{i}";
                    btn.Text = numb.ToString();
                    btn.BackColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.Black;
                    btn.FlatAppearance.MouseDownBackColor = Color.Black;
                    btn.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn.BackgroundImage = game_tag.Properties.Resources.btn;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Dock = DockStyle.Fill;
                    btn.Font = new Font(btn.Font.FontFamily, 15, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                    btn.Click += btn_play_Click;
                }

                btn_list.Add( numb, btn );
            }

            foreach ( var item in btn_list.Values ) { table_board.Controls.Add( ( item as Button ) ); }

            order_check();
        }

        private void order_check() {

            int btn_number = 1;

            for( int i = 0; i < 4; i++ ) {

                for( int j = 0; j < 4; j++ ) {

                    Control btn = table_board.GetControlFromPosition( j, i );
                    
                    if ( btn.Text == "16" ) return;
                    else if ( Convert.ToInt32( btn.Text ) == btn_number ) {
                        p_bar.Value = btn_number;
                    }
                    else return;

                    btn_number++;

                    if( btn_number == 16 ) {
                        timer_time.Enabled = false;
                        MessageBox.Show( $"ПОБЕДА!!!\nВас счет: {lbl_counter.Text}\nПотрачено времени: {lbl_time.Text}", "15", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        order_check();
                    }
                }
            }

            if ( table_board.GetControlFromPosition( 0, 0 ).Text != "1" ) p_bar.Value = 0;
        }

        private void timer_time_Tick( object sender, EventArgs e ) {

            time = time.AddSeconds( 1 );
            lbl_time.Text = time.ToString( "mm:ss" );
        }
    }
}