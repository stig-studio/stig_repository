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

    public partial class new_lesson : Form {

        private int class_id;
        private int subj_id;

        public new_lesson() {
            InitializeComponent();
        }

        public new_lesson( int class_id, int subj_id, string cl_name, string sj_name ) {

            InitializeComponent();

            this.class_id = class_id;
            this.subj_id = subj_id;

            lbl_class_value.Text = cl_name;
            lbl_subj_value.Text = sj_name;
        }

        private void new_lesson_Load( object sender, EventArgs e ) {

            dtp_dob.Value = DateTime.Now;

            lbl_error.Text = "";
        }

        private void dtp_dob_ValueChanged( object sender, EventArgs e ) {
            txtb_dob.Text = dtp_dob.Value.ToString( "dd.MM.yyyy" );
        }

        private void btn_create_Click( object sender, EventArgs e ) {

            if( txtb_dob.Text == "") {
                lbl_error.Text = "Не указана дата урока";
                return;
            }

            if( DateTime.Parse( txtb_dob.Text ) > DateTime.Now ) {
                lbl_error.Text = "Дата урока больше текущей";
                return;
            }

            string res = sql_data.add_lesson( this.subj_id, DateTime.Parse( this.txtb_dob.Text ).ToString( "yyyy-MM-dd" ), this.txtb_theme.Text );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();
        }
    }
}