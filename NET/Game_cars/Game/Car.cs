using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game {

    class Car {

        public int x { get; set; }
        public int y { get; set; }
        public int color { get; set; }
        public bool working { get; set; }

        public Car() {

            this.x = 0;
            this.y = 0;
            this.color = 0;
            this.working = true;

        }

        public Car( int x, int y, int color ) {

            this.x = x;
            this.y = y;
            this.color = color;
            this.working = true;

        }

        public Car( Car car ) {

            this.x = car.x;
            this.y = car.y;
            this.color = car.color;
            this.working = this.working;

        }

        public static Car operator ++( Car car ) {

            if (car.working == true) car.x++;
            else throw new Exception();
            return car;

        }
    }
}
