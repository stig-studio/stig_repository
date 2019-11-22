 'use strict';

let arr_x = [];
let arr_y = [];
let arr_pos = [];
let n = 0;

while( n != 20 ) {

	let cx = Math.random() * ( 900 - 100 ) + 100;
	let cy = Math.random() * ( 450 - 100 ) + 100;

	let obj_pos = {
		x: cx,
		y: cy
	};	

	if( arr_pos.length > 0 ) {

		for( let i = 0; i < arr_pos.length; i++ ) {

			let val = Math.sqrt( Math.pow( cx - arr_pos[ i ].x, 2 ) + Math.pow( cy - arr_pos[ i ].y, 2 ) );

			if( val < 85 )
				break;

			if( i == arr_pos.length - 1 ) {
				arr_pos.push( obj_pos );
				n++;
			}
		}
	}
	else {
		arr_pos.push( obj_pos );
		n++;
	}
}

let arr_copy = arr_pos;

Sort( arr_pos );

for( let i = 0; i < arr_pos.length; i++ ) {

	let dist = [];

	for( let j = 0; j < arr_pos.length; j++ ) {

		let curr;

		if( j != i ) {			
			curr = Math.sqrt( Math.pow( arr_pos[ j ].x - arr_pos[ i ].x, 2 ) + Math.pow( arr_pos[ j ].y - arr_pos[ i ].y, 2 ) );
			let pos = {
				x: arr_pos[ j ].x,
				y: arr_pos[ j ].y,
				d: curr
			};

			dist.push( pos );
		}
	}

	sort_dist( dist );		

	for( let k = 0; k < 3; k++ ) {

		var c = document.getElementById( "myCanvas" );
		var ctx = c.getContext( "2d" );

		ctx.moveTo( arr_pos[ i ].x, arr_pos[ i ].y );
		ctx.lineTo( dist[ k ].x, dist[ k ].y );
		ctx.stroke();
	}
}

for( let i = 0; i < arr_copy.length; i++ ) {
	let canvas = document.getElementById( "myCanvas" );
	let ctx = canvas.getContext( "2d" );
	ctx.beginPath();

	ctx.arc( arr_copy[ i ].x, arr_copy[ i ].y, 40, 0, 2 * Math.PI );
	ctx.fillStyle = rndColor();
	ctx.fill();
	ctx.stroke();
}


//======================================================================


function rndColor() {

    let r = Math.floor( Math.random() * ( 256 ) );
    let g = Math.floor( Math.random() * ( 256 ) );
    let b = Math.floor( Math.random() * ( 256 ) );
    let c = '#' + r.toString( 16 ) + g.toString( 16 ) + b.toString( 16 );

    return c;
}


function Sort( arr ) {

	for ( let i = 0; i < arr.length - 1; i++ )
	{
		let min = i;
		{
			for ( let j = i + 1; j < arr.length; j++ )
				if ( arr[ min ].x > arr[ j ].x )
					min = j;
			if ( min != i ) {
				let val = arr[ min ];
				arr[ min ] = arr[ i ];
				arr[ i ] = val;				
			}
		}
	}
}

function sort_dist( arr ) {

	for ( let i = 0; i < arr.length - 1; i++ )
	{
		let min = i;
		{
			for ( let j = i + 1; j < arr.length; j++ )
				if ( arr[ min ].d > arr[ j ].d )
					min = j;
			if ( min != i ) {
				let val = arr[ min ];
				arr[ min ] = arr[ i ];
				arr[ i ] = val;				
			}
		}
	}
}