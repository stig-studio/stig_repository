<?php

function get_books_list() {

    $books = file( "data.txt" );
    $arr_books = [];

    foreach ( $books as $b ) {

        $book = explode( "#", $b );
        $arr_books[] = $book;
    }

    return $arr_books;
}