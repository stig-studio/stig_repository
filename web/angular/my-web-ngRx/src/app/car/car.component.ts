import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Car } from '../car.model';
import { AppState } from '../app.state';
import { Store } from '@ngrx/store';
import { DeleteCar, UpdateCar } from '../redux/cars.action';

@Component( {

  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
} )

export class CarComponent implements OnInit {

  @Input() car:Car;
  // @Output() deleteCar = new EventEmitter<Car>();

  constructor( private store: Store<AppState> ) { }

  ngOnInit() {
  }

  onDelete(){
    //this.deleteCar.emit(this.car);
    this.store.dispatch( new DeleteCar( this.car ) );

  }
  onBuy(){
    //this.car.isSold = true;
    this.store.dispatch( new UpdateCar( this.car ) );
  }

}
