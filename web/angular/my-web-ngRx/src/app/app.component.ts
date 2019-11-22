import { Component, OnInit } from '@angular/core';
import { Car, Cars } from './car.model';
import { AppState } from './app.state';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component( {

  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']

} )

export class AppComponent implements OnInit {

  public carState: Observable<Cars>;
  constructor( private store: Store<AppState> ) {
  }

  public cars: Car[] = [
    // new Car( 'BMW', '07.06.2019', 'CX5' , true, 1 ),
    // new Car( 'Citroen', '07.07.2019', 'C4' , false, 2 ),
    // new Car( 'VW', '05.07.2019', 'Pointer' , true, 3 )
  ]

  // onAdd( car:Car ) {

  //   this.cars.push( car );
  // }

  // onDelete( car: Car ) {
  //   this.cars = this.cars.filter( c => c.id != car.id );
  // }

  ngOnInit() {
    // this.store.select( 'carPage' ).subscribe(
    //   ({cars}) => {
    //     this.cars = cars;
    //   } )

    this.carState = this.store.select( 'carPage' );
  }
}
