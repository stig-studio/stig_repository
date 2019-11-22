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

    public partial class add_subject_for_schedule : Form {

        public add_subject_for_schedule() {
            InitializeComponent();
        }

        private void add_subject_for_schedule_Load( object sender, EventArgs e ) {

            sql_data.get_classes_with_id();

            cmb_classes.DataSource = sql_data.data_set_classes.Tables["classes"];
            cmb_classes.DisplayMember = "class_name";
            cmb_classes.ValueMember = "id";

            sql_data.get_subjects_data();

            cmb_subj.DataSource = sql_data.data_set_subjects.Tables["subjects"];
            cmb_subj.DisplayMember = "name";
            cmb_subj.ValueMember = "id";

            cmb_semestr.SelectedIndex = 0;
            cmb_day_of_week.SelectedIndex = 0;
            cmb_numbers.SelectedIndex = 0;

            sql_data.get_employees();

            cmb_teachers.DataSource = sql_data.data_set_employees.Tables["employees"];
            cmb_teachers.DisplayMember = "full_name";
            cmb_teachers.ValueMember = "id";

            lbl_error.Text = "";

        }

        private void btn_add_Click( object sender, EventArgs e ) {

            string res = sql_data.add_subject_for_schedule(

                ( int )cmb_classes.SelectedValue,
                cmb_day_of_week.SelectedIndex + 1,
                ( int )cmb_semestr.SelectedIndex + 1,
                cmb_numbers.SelectedIndex + 1,
                ( int )cmb_subj.SelectedValue,
                ( int )cmb_teachers.SelectedValue

                );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }

        private void btn_update_Click( object sender, EventArgs e ) {

            string res = sql_data.update_subject_for_schedule(

                ( int )cmb_classes.SelectedValue,
                cmb_day_of_week.SelectedIndex + 1,
                ( int )cmb_semestr.SelectedIndex + 1,
                cmb_numbers.SelectedIndex + 1,
                ( int )cmb_subj.SelectedValue,
                ( int )cmb_teachers.SelectedValue

                );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }

        private void btn_del_Click( object sender, EventArgs e ) {

            string res = sql_data.delete_subject_for_schedule(

                ( int )cmb_classes.SelectedValue,
                cmb_day_of_week.SelectedIndex + 1,
                ( int )cmb_semestr.SelectedIndex + 1,
                cmb_numbers.SelectedIndex + 1

                );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }
    }
}