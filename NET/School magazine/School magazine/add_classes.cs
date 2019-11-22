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

    public partial class add_classes : Form {

        public add_classes() {
            InitializeComponent();
        }

        private void add_classes_Load( object sender, EventArgs e ) {

            lbl_error.Text = "";

            sql_data.get_employees();

            cmb_teacher.DataSource = sql_data.data_set_employees.Tables["employees"];
            cmb_teacher.DisplayMember = "full_name";
            cmb_teacher.ValueMember = "id";
            cmb_teacher.SelectedIndex = -1;

        }

        private void btn_add_class_Click( object sender, EventArgs e ) {

            if( this.txtb_class_name.Text == "" ) {

                this.lbl_error.Text = @"Не указано название класса";
                return;
            }

            string res = sql_data.add_new_class( new Class { class_name = this.txtb_class_name.Text, classroom_teacher_id = Convert.ToInt32( cmb_teacher.SelectedValue ) } );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();
        }
    }
}