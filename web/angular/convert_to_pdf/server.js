
var express = require( 'express' );
var m = require( './module/parse_file.js' );
var func = require( './module/func.js' );

var app = express();

app.use( express.static( __dirname + '/public' ) );
app.set( 'view engine', 'ejs' );

app.get( '/receipt/:id', function( req, res ) {

    var arr = m.get_info( req.params.id );

    if( arr == null ) {
        res.send( "Счет с таким ID не найден" );
        return;
    }

    var inf = {

        f_name           : arr[1],
        address          : arr[2],
        apartment_number : arr[3],
        date             : arr[4],
        checking_account : arr[5],
        balance          : arr[6],
        counted          : arr[7],
        paid             : arr[8],
        to_pay           : arr[9],
        balance_next     : arr[10],

        payment_type_1   : arr[11],
        previous_1       : arr[12],
        current_1        : arr[13],
        rate_1           : arr[14],
        quantity_1       : arr[15],
        sum_1            : arr[16],
        subsidy_1        : arr[17],
        accrued_1        : arr[18],

        payment_type_2   : arr[19],
        previous_2       : arr[20],
        current_2        : arr[21],
        rate_2           : arr[22],
        quantity_2       : arr[23],
        sum_2            : arr[24],
        subsidy_2        : arr[25],
        accrued_2        : arr[26],

        payment_type_3   : arr[27],
        previous_3       : arr[28],
        current_3        : arr[29],
        rate_3           : arr[30],
        quantity_3       : arr[31],
        sum_3            : arr[32],
        subsidy_3        : arr[33],
        accrued_3        : arr[34],

        payment_type_4   : arr[35],
        previous_4       : arr[36],
        current_4        : arr[37],
        rate_4           : arr[38],
        quantity_4       : arr[39],
        sum_4            : arr[40],
        subsidy_4        : arr[41],
        accrued_4        : arr[42]

    };

    var val = inf.date.split( '.' );
    var _date = val[2] + "-" + val[1] + "-" + val[0];

    var month_name_ = func.get_month( new Date( _date ).getMonth() ) + " " + new Date( _date ).getFullYear();
    var month_n = ( new Date( _date ).getMonth() < 10 )? "0" + String( new Date( _date ).getMonth() + 1 ) : new Date( _date ).getMonth() + 1;
    var year_n = ( new Date( _date ).getFullYear() );

    var next_month_n = ( ( new Date( _date ).getMonth() + 2 ) < 10 )? "0" + String( ( new Date( _date ).getMonth() ) + 2 ) : String( ( new Date( _date ).getMonth() ) + 2 );
    var next_year_n = ( new Date( _date ).getFullYear() );

    if( next_month_n == "13" ) {
        next_month_n = "01";
        next_year_n++;
    }

    res.render( 'receipt', {

        month_name: month_name_,
        month_number: month_n,
        year_number: year_n,
        next_month_number: next_month_n,
        next_year_number: next_year_n,
        info: inf 
    });

} );

app.listen( 3212 );

console.log( 'server start ' + new Date() );