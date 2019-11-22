
'use strict';

$( function() {
	$( '.MySlider' ).slick( {
		dots: true
	} );

	$( '.MySlider' ).on( 'swipe', function( event, slick, direction ){
  	console.log( direction );
  		alertify.notify( direction, 'success', 5 );
	});

	new WOW().init();
	setInterval( () => {

		$.get( "data.php", function( data ) {
			alertify.notify( data, 'succes', 5 );
		} );

	}, 1000 ) 

} );


