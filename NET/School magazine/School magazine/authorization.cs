using School_magazine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine {

    public partial class authorization : Form {

        public authorization() {
            InitializeComponent();
        }

        private void authorization_Load( object sender, EventArgs e ) {

            this.lbl_error.Text = "";

        }

        private void btn_signin_Click( object sender, EventArgs e ) {

            if( this.txtb_user.Text == "" ) { this.lbl_error.Text = "Не указано имя пользователя!"; return; }

            if( this.txtb_password.Text == "" ) { this.lbl_error.Text = "Не указан пароль!"; return; }
            
            string msg = sql_data.signin( this.txtb_user.Text, txtb_password.Text );

            if( msg != "" ) { lbl_error.Text = msg; return; }

            main_page main = new main_page();
            main.Show();

            this.Hide();
        }

        private void authorization_FormClosed( object sender, FormClosedEventArgs e ) {

            Application.Exit();
        }
    }
}