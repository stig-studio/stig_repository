
var config = require( 'config' );
var fs = require( 'fs' );

function get_band( src ) {

    var data =  JSON.parse( fs.readFileSync( config.get( 'bands_data' ), "utf8" ) );
    var res_obj = null;

    for( var i in data ) {

        data[i].forEach( element => {

            if( element.src == src ) {
                res_obj = element;
                return;
            }
        } );
    }

    return res_obj;
}

function get_user( user, pass ) {
    
    var file_users = config.get( 'users_data' );
    var data = fs.readFileSync( file_users, "utf8" ).split( "$" );

    var return_status = -1;

    var res_obj = {

        id: "",
        login: "",
        photo: ""
    };

    for( var i in data ) {
        
        var arr = data[i].split( "#" );

        if( arr[1] == user ) {

            return_status = 0;

            if( arr[2] == pass ) {

                return_status = 1;

                res_obj.id = arr[0];
                res_obj.login = arr[1];
                res_obj.photo = arr[3];
            }
            break;
        }
    }

    if( return_status == 1 ) return res_obj;
    else return return_status;
}

function get_user_by_id( id ) {

    var file_users = config.get( 'users_data' );
    var data = fs.readFileSync( file_users, "utf8" ).split( "$" );

    var res_obj = {

        id: "",
        login: "",
        photo: ""
    };

    for( var i in data ) {
        
        var arr = data[i].split( "#" );

        if( arr[0] == id ) {

            res_obj.id = arr[0];
            res_obj.login = arr[1];
            res_obj.photo = arr[3];
            
            break;
        }
    }

    return res_obj;
}

module.exports.get_band = get_band;
module.exports.get_user = get_user;