using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace JSON_Parser {

    [Guid( "5338660F-4554-477A-81B9-FFB0E3163D7C" )]
    [ComVisible( true )]
    public interface IJSON_parser {

        [DispId( 0x00000001 )]
        void load_JSON( string path_file );
        [DispId( 0x00000002 )]
        string get_value_JSON( string key );
        [DispId( 0x00000003 )]
        void get_table_JSON( string columns );
        [DispId( 0x00000004 )]
        ArrayList get_list_JSON( string columns );
        [DispId( 0x00000005 )]
        string get_list_value_by_index( int index );
        [DispId( 0x00000006 )]
        string get_table_value_by_index( string column, int index );
        [DispId( 0x00000007 )]
        int get_table_row_count();

    }

    [Guid( "48C37FF4-D1B4-4B70-942B-286EDC3BA4DD" )]
    [ClassInterface( ClassInterfaceType.None ), ComSourceInterfaces( typeof( IJSON_parser ) )]
    [ComVisible( true )]
    public class json_parser : IJSON_parser {

        public StringBuilder data { get; set; }
        public DataTable table { get; set; }
        public ArrayList list { get; set; }

        public json_parser() {

            this.data = null;
            this.list = null;

        }

        public void load_JSON( string path_file ) {

            data = new StringBuilder();
            StreamReader reader = new StreamReader( path_file, Encoding.GetEncoding( 1251 ) );
            data.Append( reader.ReadToEnd() );

            reader.Close();

        }

        public string get_value_JSON( string key ) {

            string pattern = $@"""{ key }"":\s""(.*)""";

            Regex reg = new Regex( pattern, RegexOptions.IgnoreCase );
            Match res = reg.Match( data.ToString() );

            if ( res.Length > 1 ) return res.Groups[1].ToString();
            else return String.Empty;
        }

        public void get_table_JSON( string columns ) {

            columns = columns.Replace( " ", "" );
            string[] cols = columns.Split( ',' );

            Regex reg = null;
            List<string> list = new List<string>();

            for ( int i = 0; i < cols.Length; i++ ) {

                string pattern = $@"""{ cols[i] }"":\s""(.*)""";

                reg = new Regex( pattern );
                MatchCollection res = reg.Matches( data.ToString() );

                if ( res.Count > 1 ) {
                    foreach ( Match item in res ) {
                        list.Add( item.Groups[1].ToString() );
                    }
                }
            }

            this.table = new DataTable( "table" );

            for( int i = 0; i < cols.Length; i++ ) table.Columns.Add( cols[i] );

            int count_row = list.Count / cols.Length;

            for ( int i = 0; i < count_row; i++ ) {

                DataRow row = table.NewRow();

                int step = 0;

                for( int j = 0; j < cols.Length; j++ ) {
                    row[cols[j]] = list[i + step];
                    step += count_row;
                }

                table.Rows.Add( row );
            }
        }

        public ArrayList get_list_JSON( string columns ) {
            
            columns = columns.Replace( " ", "" );
            string[] cols = columns.Split( ',' );

            Regex reg = null;
            list = new ArrayList();

            for ( int i = 0; i < cols.Length; i++ ) {

                string pattern = $@"""{ cols[i] }"":\s""(.*)""";

                reg = new Regex( pattern );
                MatchCollection res = reg.Matches( data.ToString() );

                if ( res.Count > 1 ) {
                    foreach ( Match item in res ) {
                        list.Add( item.Groups[1].ToString() );
                    }
                }
            }

            return list;
        }

        public string get_list_value_by_index( int index ) {
            return this.list[index].ToString();
        }

        public string get_table_value_by_index( string column, int index ) {
            return table.Rows[index][column].ToString();
        }

        public int get_table_row_count() {
            return table.Rows.Count;
        }
    }
}