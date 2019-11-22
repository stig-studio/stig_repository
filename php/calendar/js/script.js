"use strict";

$( document ).ready( function() {
    $( "#list_months" ).change( function () {
        show_calendar( "f_month", "data.php" );
    } );
});

function show_calendar( month, url ) {

    $.ajax( {

        url: url,
        type: "post",
        dataType: "html",
        data: $( "#" + month ).serialize(),
        success: function( responce ) {
            if( $( ".table_calendar" ).length > 0 ) {
                $( ".table_calendar" ).remove();
                $( "#calendar" ).append( responce );
            }
            else
                $( "#calendar" ).append( responce );
        },
        error: function ( responce ) {
            console.log( responce );
        }
    } );
};