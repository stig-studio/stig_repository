"use strict";

let elem = document.getElementsByClassName( 'item' );

console.log( "=================================================================" );

for( let i = 0; i < elem.length; i++ ) {

	let str = elem[i].innerHTML;	

	let desc = str.match( /<th>(.*)<\/th>/i );	
	let result = str.match( /<strong>\s+(<a.*>)?\s+(\S.*)\t+(<\/a>)?(<br>)?\s+<\/strong>/i );

	if( result != undefined )
		console.log( desc[ 1 ] + ': ' + result[ 2 ] );
	
}

console.log( "=================================================================" );