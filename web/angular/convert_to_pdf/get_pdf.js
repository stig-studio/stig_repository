
var pdf = require( 'html-pdf' );
var requestify = require( 'requestify' );
var externalURL= 'http://127.0.0.1:3212/receipt/1';     // URL of the page to be converted

requestify.get( externalURL ).then( function ( response ) {
   
   var html = response.body; 
   var config = {format: 'A4'};

   pdf.create( html, config ).toFile( 'html_in_pdf/receipt_1.pdf', function ( err, res ) {
      if ( err ) return console.log( err );
      console.log( res );
   } );
} );


