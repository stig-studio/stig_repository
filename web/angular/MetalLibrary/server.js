
const fs        = require( 'fs' );
const express   = require( 'express' );
var config      = require( 'config' );
var func        = require( config.get( 'modules' ) );
var body_parser = require( 'body-parser' );

const app = express();

app.set( "view engine", "ejs" );
app.use( express.static( __dirname + '/public' ) );
app.use( express.json() );

var url_encoded_parser = body_parser.urlencoded( { extended: false } );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

var user = null;

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/', function( req, res ) {

    var data = config.get( 'index_data' );

    res.render( 'index', { data: fs.readFileSync( data ), login_pers: ( user != null ) ? user.login : "" } );

} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/news', function( req, res ) {

    var data = config.get( 'news_data' );
    
    res.render( 'news', { news_data: JSON.parse( fs.readFileSync( data ) ), login_pers: ( user != null ) ? user.login : "" } );

} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/bands', function( req, res ) {

    var data = config.get( 'bands_data' );
    
    res.render( 'bands', { bands_data: JSON.parse( fs.readFileSync( data ) ), login_pers: ( user != null ) ? user.login : "" } );

} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/bands/:band', function( req, res ) {
    
    var band = func.get_band( req.params.band );

    res.render( 'band', { data: band, login_pers: ( user != null ) ? user.login : "" } );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/signin', function( req, res ) {
    
    res.render( 'signin', { login: "", pass: "", error: "", login_pers: ( user != null ) ? user.login : "" } );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/about', function( req, res ) {
    
    res.render( 'about', { login_pers: ( user != null ) ? user.login : "" } );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/personal_area', function( req, res ) {
    
    //res.render( 'personal_area', { data: user } );

    if( user != null ) {
        res.render( 'personal_area', { data: user, login_pers: ( user != null ) ? user.login : "" } );
    }
    else res.redirect( '*' );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '/exit', function( req, res ) {
    
    user = null;

    res.redirect( '/' );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.get( '*', function( req, res ) {
    
    res.render( '404', { login_pers: ( user != null ) ? user.login : "" } );
 
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.post( '/signin', url_encoded_parser, function( req, res ) {
    
    user = func.get_user( req.body.login, req.body.pass );

    if( user == -1 ) {

        res.render( 'signin',
        {
            login:  req.body.login,
            pass:   req.body.pass,
            error:  "Wrong login!",
            login_pers: ( user != null ) ? user.login : ""
        });
    }
    else if( user == 0 ) {

        res.render( 'signin',
        {
            login:  req.body.login,
            pass:   req.body.pass,
            error:  "Wrong password!",
            login_pers: ( user != null ) ? user.login : ""
        });
    }
    else {
        res.redirect( '/personal_area' );
    }
    
} );

// + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

app.listen( 3213 );

console.log( "server start " + new Date().toLocaleTimeString() );