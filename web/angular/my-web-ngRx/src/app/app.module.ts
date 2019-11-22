import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarsFormComponent } from './cars-form/cars-form.component';
import { CarComponent } from './car/car.component';
import { StoreModule } from '@ngrx/store';
import { cars_reducer } from './redux/cars.reducer';

@NgModule( {

  declarations: [
    AppComponent,
    CarsFormComponent,
    CarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    StoreModule.forRoot( { carPage: cars_reducer } )
  ],
  providers: [],
  bootstrap: [AppComponent]
} )

export class AppModule { }
