
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace SendMailFor1c7 {

    [Guid( "31D1BE3F-CA23-4D0D-A5B2-5BE14A11C7E2" )]
    [ComVisible( true )]
    public interface ISendMail {

        [DispId( 0x00000001 )]
        void create_message();

        [DispId( 0x00000002 )]
        void message_sender( string sender );

        [DispId( 0x00000003 )]
        void add_recipient( string recipient );

        [DispId( 0x00000004 )]
        void message_subject( string subject );

        [DispId( 0x00000005 )]
        void message_text( string text );

        [DispId( 0x00000006 )]
        void attach_file( string path_file );

        [DispId( 0x00000007 )]
        void send( string email, string password ); 

    }

    [Guid( "AE35F68C-A292-471E-AFC3-D5CEDFCF1B6B" )]
    [ClassInterface( ClassInterfaceType.None ), ComSourceInterfaces( typeof( ISendMail ) )]
    [ComVisible( true )]
    public class SendMail: ISendMail {

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private MailAddress msg_sender { get; set; }
        private MailMessage msg { get; set; }
        private SmtpClient  smtp { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void create_message() {
            msg = new MailMessage();
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void message_sender( string sender ) {
            this.msg_sender = new MailAddress( sender );
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void add_recipient( string recipient ) {
            
            if( this.msg == null )
                throw new Exception( "Невозможно добавить адрес электронной почты, так как сообщение не было создано" );

            this.msg.To.Add( recipient );
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void message_subject( string subject ) {
            this.msg.Subject = subject;
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void message_text( string text ) {
            this.msg.Body = $"<p>{ text }</p>";
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void attach_file( string path_file ) {

            if( !File.Exists( path_file ) )
                throw new Exception( "Файл по указанному пути не существует" );

            this.msg.Attachments.Add( new Attachment( path_file, MediaTypeNames.Application.Octet ) );
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void send( string email, string password ) {

            this.msg.From = this.msg_sender;
            this.msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient( "smtp.gmail.com", 587 );
            smtp.Credentials = new NetworkCredential( email, password );
            smtp.EnableSsl = true;

            try {
                smtp.Send( msg );
            }
            catch ( Exception ex ) {
                throw new Exception( ex.ToString() );
            }
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    }
}