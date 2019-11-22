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

    public partial class user_info : Form {

        private int id;

        public user_info() {
            InitializeComponent();
        }

        public user_info( int id ) {

            InitializeComponent();

            this.id = id;

        }

        private void user_info_Load( object sender, EventArgs e ) {

            this.lbl_error.Text = "";

            sql_data.get_employees();

            cmb_employees.DataSource = sql_data.data_set_employees.Tables["employees"];
            cmb_employees.DisplayMember = "full_name";
            cmb_employees.ValueMember = "id";
            cmb_employees.SelectedValue = id;

            cmb_is_admin.Items.Add( "да" );
            cmb_is_admin.Items.Add( "нет" );
            cmb_is_admin.SelectedIndex = 1;

            User user = sql_data.get_user( id );

            if( user == null ) { this.btn_add.Text = "ДОБАВИТЬ"; return; };

            this.txtb_username.Text = user.Login;
            this.txtb_pass.Text = user.Password;
            this.txtb_confirm.Text = user.Password;
        }

        private void btn_add_Click( object sender, EventArgs e ) {

            if( txtb_username.Text == "" ) {

                this.lbl_error.Text = @"Поле ""имя пользователя"" не может быть пустым! ";
                return;
            }

            if( txtb_pass.Text == "" ) {

                this.lbl_error.Text = "Не указан пароль";
                return;
            }
            else if( txtb_pass.Text != txtb_confirm.Text ) {

                this.lbl_error.Text = "Пароли не совпадают";
                return;
            }

            User u = new User {

                Id = this.id,
                employee_id = Convert.ToInt32( cmb_employees.SelectedValue ),
                Login = txtb_username.Text,
                Password = txtb_pass.Text,
                IsAdmin = ( cmb_is_admin.SelectedText == "Да" ) ? true : false

            };

            string res = "";

            if ( btn_add.Text == "ИЗМЕНИТЬ" )
                res = sql_data.update_user( u );
            else
                res = sql_data.add_user( u );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();
        }
    }
}
