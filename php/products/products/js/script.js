"use strict";

$( document ).ready( function() {

    $( "#btn_notebooks" ).click( function () {
        show_products( "notebooks", "data.php" );
    });
    $( "#btn_phones" ).click( function () {
        show_products( "phones", "data.php" );
    });
    $( "#btn_tablets" ).click( function () {
        show_products( "tablets", "data.php" );
    });
    $( "#btn_filter" ).click( function () {
        if( $( ".prod_head" ).text() != "" ) {
            if( parseInt( $( "#price_from" ).val() ) <= parseInt( $( "#price_to" ).val() ) ) {
                filter_products($("#price_from").val(), $("#price_to").val(), $(".prod_head").text(), "data.php");
            }
            else alert( 'Значение поля "Цена от:" не может быть больше!' );
        }
        else alert( "Не возможно выполнить фильтрацию данных, так как не выбрана категория товаров!" );
    } );
    $( "#inp_search" ).keyup( function( event ) {
        if( event.keyCode == 13 ) {
            search_products( $( "#inp_search" ).val(), "data.php" );
        }
    } );

});

function show_products( prod, url ) {

    $.ajax ({
        type: "POST",
        url: url,
        data: { 'type': 'product', 'product': prod },
        success: function( responce ) {
            if( $( ".product" ).length > 0 ) {
                $( ".prod_head" ).remove();
                $( ".product" ).remove();
                $( ".products" ).append( responce );
            }
            else $( ".products" ).append( responce );
        },
        error: function ( responce ) {
            console.log( responce );
        }
    } );
}

function filter_products ( price_min, price_max, prod, url ) {

    $.ajax ({

        type: "POST",
        url: url,
        data: { 'type': 'filter', 'product': prod, 'price_min': price_min, 'price_max': price_max },
        success: function( responce ) {
            if( $( ".product" ).length > 0 ) {
                $( ".product" ).remove();
                $( ".products" ).append( responce );
            }
            else $( ".products" ).append( responce );
        },
        error: function ( responce ) {
            console.log( responce );
        }
    } );
}

function search_products( text_search, url ) {

    $.ajax ({

        type: "POST",
        url: url,
        data: { 'type': 'search', 'value': text_search },
        success: function( responce ) {
            if( $( ".product" ).length > 0 ) {
                $( ".product" ).remove();
                $( ".products" ).append( responce );
            }
            else $( ".products" ).append( responce );
        },
        error: function ( responce ) {
            console.log( responce );
        }
    } );
}