using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Exam {

    static class data_bind {

        public static BindingList<Client> clients_list { get; set; }

        static data_bind() {
            clients_list = new BindingList<Client>();
        }

        public static void save( string file_name ) {

            XmlSerializer xml = new XmlSerializer( typeof( BindingList<Client> ) );

            try {
                if ( clients_list.Count() > 0)
                    using ( FileStream stream = File.Create( file_name ) ) { xml.Serialize( stream, clients_list ); }
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public static void load( string file_name ) {

            XmlSerializer xml = new XmlSerializer( typeof( BindingList<Client> ) );

            try {
                if( File.Exists( file_name ) ) {
                    using ( FileStream stream = File.OpenRead( file_name ) ) { clients_list = xml.Deserialize( stream ) as BindingList<Client>; }
                }
            }
            catch( Exception ex ) {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}