import { Car } from "../car.model";
import { AddCar, CAR_ACTION, CarsAction } from './cars.action';
//import { stat } from 'fs';

const initialState = {

  cars: [
    new Car( 'BMW', '07.06.2019', 'CX5' , true, 1 ),
    new Car( 'Citroen', '07.07.2019', 'C4' , false, 2 ),
    new Car( 'VW', '05.07.2019', 'Pointer' , true, 3 ),
  ]
}

export function cars_reducer( state = initialState, action: CarsAction ) {

  switch( action.type ) {

    case CAR_ACTION.ADD_CAR:
      return {
        ...state,
        cars: [...state.cars, action.payload]
      }
      case CAR_ACTION.DELETE_CAR:
          return{
              ...state,
              cars:[...state.cars.filter(
                  c=>c.id !== action.payload.id
              )]
          }
      case CAR_ACTION.UPDATE_CAR:

        const id = state.cars.findIndex( i => i.id === action.payload.id );

        state.cars[id].isSold = true;

        return{
          ...state,
          cars:[ ...state.cars ]
        }
    default:
      return state;
  }
}
