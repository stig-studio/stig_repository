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

    public partial class add_subjects : Form {

        public add_subjects() {
            InitializeComponent();
        }
        
        private void add_subjects_Load( object sender, EventArgs e ) {
            lbl_error.Text = "";
        }

        private void btn_add_Click( object sender, EventArgs e ) {

            if( txtb_subj_name.Text == "" ) {

                lbl_error.Text = "Не указано название предмета";
                return;
            }

            string res = sql_data.add_subject( txtb_subj_name.Text );

            if ( res != "" )
                lbl_error.Text = res;
            else
                this.Close();
        }
    }
}