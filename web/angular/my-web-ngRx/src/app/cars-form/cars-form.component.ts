import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Car } from '../car.model';
import * as moment from 'moment';
import { AppState } from '../app.state';
import { Store } from '@ngrx/store';
import { AddCar } from '../redux/cars.action';

@Component({
  selector: 'app-cars-form',
  templateUrl: './cars-form.component.html',
  styleUrls: ['./cars-form.component.css']
})
export class CarsFormComponent implements OnInit {

  carName:  string = "";
  carModel: string = "";

  private id = 3;

  // @Output() addCar = new EventEmitter<Car>();

  constructor( private store: Store<AppState> ) { }

  ngOnInit() {
  }

  onAdd() {

    if ( this.carModel === '' || this.carName === '' ) return;

    //debugger

    this.id = ++this.id;
    const car = new Car(
      this.carName,
      moment().format('DD.MM.YY'),
      this.carModel,
      false,
      this.id
    );

    //debugger
    // this.addCar.emit( car );

    this.store.dispatch( new AddCar( car ) );

    this.carModel = "";
    this.carName = "";

  }

  onLoad() {

  }

}
