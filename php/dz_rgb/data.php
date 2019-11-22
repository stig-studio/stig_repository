<?php

    $r = $_POST[ 'inp_r' ];
    $g = $_POST[ 'inp_g' ];
    $b = $_POST[ 'inp_b' ];

    if( $r >= 0 && $r <= 9 ) $r = '0'.$r;
    else $r = base_convert( $r, 10, 16 );

    if( $g >= 0 && $g <= 9 ) $g = '0'.$g;
    else $g = base_convert( $g, 10, 16 );

    if( $b >= 0 && $b <= 9 ) $b = '0'.$b;
    else $b = base_convert( $b, 10, 16 );

    //------------------------------------------------------------------------------------

    $rnd_r = rand( 255, 0 );

    if( $rnd_r >= 0 && $rnd_r <= 9 ) $rnd_r = '0'.$rnd_r;
    else $rnd_r = base_convert( $rnd_r, 10, 16 );

    $rnd_g = rand( 255, 0 );

    if( $rnd_g >= 0 && $rnd_g <= 9 ) $rnd_g = '0'.$rnd_g;
    else $rnd_g = base_convert( $rnd_g, 10, 16 );

    $rnd_b = rand( 255, 0 );

    if( $rnd_b >= 0 && $rnd_b <= 9 ) $rnd_b = '0'.$rnd_b;
    else $rnd_b = base_convert( $rnd_b, 10, 16 );

    //------------------------------------------------------------------------------------

    $result = array(
        'bg' => $r.$g.$b,
        'cl' => $rnd_r.$rnd_g.$rnd_b
    );

    echo json_encode( $result );

    //------------------------------------------------------------------------------------

?>