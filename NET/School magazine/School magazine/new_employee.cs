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

    public partial class new_employee : Form {

        public new_employee() {
            InitializeComponent();
        }

        private void new_employee_Load( object sender, EventArgs e ) {

            this.lbl_error.Text = "";

            sql_data.get_education();

            cmb_education.DataSource = sql_data.data_set_education.Tables["education"];
            cmb_education.DisplayMember = "descr";
            cmb_education.ValueMember = "id";
            cmb_education.SelectedIndex = 0;

        }

        private void btn_add_Click( object sender, EventArgs e ) {

            if( txtb_last_name.Text == "" ) {
                lbl_error.Text = @"Поле ""фамилия"" не может быть пустым";
                return;
            }

            if( txtb_f_name.Text == "" ) {
                lbl_error.Text = @"Поле ""имя"" не может быть пустым";
                return;
            }

            if( txtb_p_name.Text == "" ) {
                lbl_error.Text = @"Поле ""отчество"" не может быть пустым";
                return;
            }

            if( txtb_dob.Text == "" ) {
                lbl_error.Text = @"Поле ""дата рождения"" не может быть пустым";
                return;
            }
            else if( dtp_dob.Value > DateTime.Now ) {
                lbl_error.Text = @"Дата рождения не можеть быть больше текущей даты";
                return;
            }
            else if( DateTime.Now.Year - dtp_dob.Value.Year < 18 ) {
                lbl_error.Text = @"Сотрудник не совершеннолетний";
                return;
            }

            if( dtp_employment_date.Text == "" ) {
                lbl_error.Text = @"Поле ""дата приема"" не может быть пустым";
                return;
            }

            if( cmb_education.Text == "" ) {
                lbl_error.Text = @"Поле ""образование"" не может быть пустым";
                return;
            }

            FileInfo file = new FileInfo( this.txtb_photo.Text );

            byte[] img_bytes = null;

            if( file.Exists ) {

                using (  FileStream stream = file.Open( FileMode.Open ) ) {

                    using ( BinaryReader reader = new BinaryReader( stream ) ) {
                        img_bytes = reader.ReadBytes( ( int ) file.Length );
                    }
                }
            }

            string res = sql_data.add_new_employees(

                this.txtb_last_name.Text,
                this.txtb_f_name.Text,
                this.txtb_p_name.Text,
                txtb_dob.Text,
                txtb_empl.Text,
                txtb_dism.Text,
                img_bytes,
                this.txtb_addr.Text,
                this.txtb_phone_number.Text,
                ( int ) this.cmb_education.SelectedValue

            );

            if( res != "" ) this.lbl_error.Text = res;
            else this.Close();

        }

        private void btn_photo_choise_Click( object sender, EventArgs e ) {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            this.txtb_photo.Text = dialog.FileName;
        }

        private void dtp_dob_ValueChanged( object sender, EventArgs e ) {

            txtb_dob.Text = dtp_dob.Value.ToString( "yyyy-MM-dd" );
        }

        private void dtp_employment_date_ValueChanged( object sender, EventArgs e ) {

            txtb_empl.Text = dtp_employment_date.Value.ToString( "yyyy-MM-dd" );
        }

        private void dtp_dismissal_date_ValueChanged( object sender, EventArgs e ) {

            txtb_dism.Text = dtp_dismissal_date.Value.ToString( "yyyy-MM-dd" );
        }
    }
}