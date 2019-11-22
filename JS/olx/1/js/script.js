"use strict";

let elem = document.getElementsByClassName('lheight22 margintop5');

console.log( "======================================================\n" );
for( let i = 0; i < elem.length; i++ ) {

	let str = elem[i].innerHTML;
	let result = str.match( /<a\s[a-z]+="(.*)#.*"\s[a-z]+="[a-z0-9]+\s[a-z]+\s[a-z]+\s[a-z]+">/i );

	if( result[ 1 ] != null )
		console.log( result[ 1 ] );		
}

console.log( "\n======================================================" );