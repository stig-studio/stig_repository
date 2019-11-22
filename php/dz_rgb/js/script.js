"use strict";

$( document ).ready( function() {
    $( "#btn_accept" ).click(
        function(){
            sendAjaxForm( 'b_out', 'main_form', 'data.php' );
            return false;
        }
    );
});


function sendAjaxForm( out, m_form, url ) {

    if( parseInt( $( "#inp_r_" ).val() ) >= 0 && parseInt( $( "#inp_r_" ).val() ) <= 255
     && parseInt( $( "#inp_g_" ).val() ) >= 0 && parseInt( $( "#inp_g_" ).val() ) <= 255
     && parseInt( $( "#inp_b_" ).val() ) >= 0 && parseInt( $( "#inp_b_" ).val() ) <= 255 ) {

        $.ajax( {
            url:        url,
            type:       "post",
            dataType:   "json",
            data: $( "#" + m_form ).serialize(),
            success: function( response ) {

                let arr = [];

                $.each( response, function( key, value ) {
                    arr.push( value );
                } );

                $( "#" + out ).css( "background-color", "#" + arr[ 0 ] );
                $( "#" + out ).css( "color", "#" + arr[ 1 ] );

            },
            error: function( response ) {
                $( "#" + out ).html( 'Не удалось отправить форму!' );
            }
        });
    }
    else
        alert( "Не правильное значение для RGB!" );
}