// const mongoose = require( "mongoose" );

// mongoose.connect( 'mongodb://localhost:27017/CRUDDB',
//                 ( err ) => {

//                     if( !err )
//                         console.log( 'MongoDB connections successed!' );
//                     else
//                         console.log( 'Error in DB connection: ' + JSON.stringify( err, undefined, 2 ) );
//                 } );

// module.exports = mongoose;

const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost:27017/CrudDB', (err) =>{
    if (!err)
        console.log('MongoDB connections succeeded.');
    else
        console.log('Error in DB connection: ' + JSON.stringify(err, undefined,2));

});

module.exports = mongoose;