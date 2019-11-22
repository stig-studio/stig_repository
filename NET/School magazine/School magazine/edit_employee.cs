using School_magazine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine {

    public partial class edit_employee : Form {

        Employee empl;

        public edit_employee() {
            InitializeComponent();
        }

        public edit_employee( int id ) {

            InitializeComponent();

            empl = sql_data.get_employee_by_id( id );

            this.txtb_last_name.Text = empl.l_name.ToString();
            this.txtb_f_name.Text = empl.f_name;
            this.txtb_p_name.Text = empl.p_name;

            this.txtb_dob.Text = empl.dob;
            this.dtp_dob.Value = DateTime.Parse( empl.dob );

            this.txtb_empl.Text = empl.employment_date;
            this.dtp_employment_date.Value = DateTime.Parse( empl.employment_date );

            this.txtb_dism.Text = empl.dismissal_date;
            
            if( empl.dismissal_date != "" )
                this.dtp_dismissal_date.Value = DateTime.Parse( empl.dismissal_date );

            this.pic_photo.Image = empl.photo;

            this.txtb_addr.Text = empl.addr;
            this.txtb_phone_number.Text = empl.phone;

            sql_data.get_education();

            cmb_education.DataSource = sql_data.data_set_education.Tables["education"];
            cmb_education.DisplayMember = "descr";
            cmb_education.ValueMember = "id";

            cmb_education.SelectedValue = empl.education;

            this.lbl_error.Text = "";
        }

        private void btn_photo_choise_Click( object sender, EventArgs e ) {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            this.txtb_photo.Text = dialog.FileName;
        }

        private void btn_edit_Click( object sender, EventArgs e ) {

            if ( txtb_last_name.Text == "" ) {
                lbl_error.Text = @"Поле ""фамилия"" не может быть пустым";
                return;
            }

            if ( txtb_f_name.Text == "" ) {
                lbl_error.Text = @"Поле ""имя"" не может быть пустым";
                return;
            }

            if ( txtb_p_name.Text == "" ) {
                lbl_error.Text = @"Поле ""отчество"" не может быть пустым";
                return;
            }

            if ( txtb_dob.Text == "" ) {
                lbl_error.Text = @"Поле ""дата рождения"" не может быть пустым";
                return;
            }
            else if ( dtp_dob.Value > DateTime.Now ) {
                lbl_error.Text = @"Дата рождения не можеть быть больше текущей даты";
                return;
            }
            else if ( DateTime.Now.Year - dtp_dob.Value.Year < 18 ) {
                lbl_error.Text = @"Сотрудник не совершеннолетний";
                return;
            }

            if ( dtp_employment_date.Text == "" ) {
                lbl_error.Text = @"Поле ""дата приема"" не может быть пустым";
                return;
            }

            if ( cmb_education.Text == "" ) {
                lbl_error.Text = @"Поле ""образование"" не может быть пустым";
                return;
            }

            empl.l_name = txtb_last_name.Text;
            empl.f_name = txtb_f_name.Text;
            empl.p_name = txtb_p_name.Text;
            empl.dob = DateTime.Parse(txtb_dob.Text).ToString( "yyyy-MM-dd" );
            empl.employment_date = DateTime.Parse( txtb_empl.Text ).ToString( "yyyy-MM-dd" );
            empl.dismissal_date = ( txtb_dism.Text != "" ) ? DateTime.Parse( txtb_dism.Text ).ToString( "yyyy-MM-dd" ) : "null";

            if ( this.txtb_photo.Text != "" ) {

                FileInfo file = new FileInfo( this.txtb_photo.Text );

                if ( file.Exists ) {

                    using ( FileStream stream = file.Open( FileMode.Open ) ) {

                        using ( BinaryReader reader = new BinaryReader( stream ) ) {
                            empl.bytes_photo = reader.ReadBytes( ( int )file.Length );
                        }
                    }
                }
            }

            empl.addr = txtb_addr.Text;
            empl.phone = txtb_phone_number.Text;
            empl.education = ( int )cmb_education.SelectedValue;

            string msg = sql_data.update_employee( empl );

            if ( msg != "" ) {
                this.lbl_error.Text = msg;
                return;
            }
            else this.Close();

        }

        private void dtp_dob_ValueChanged( object sender, EventArgs e ) {
            txtb_dob.Text = dtp_dob.Value.ToString( "dd.MM.yyyy" );
        }

        private void dtp_employment_date_ValueChanged( object sender, EventArgs e ) {
            txtb_empl.Text = dtp_employment_date.Value.ToString( "dd.MM.yyyy" );
        }

        private void dtp_dismissal_date_ValueChanged( object sender, EventArgs e ) {
            txtb_dism.Text = dtp_dismissal_date.Value.ToString("dd.MM.yyyy");
        }
    }
}