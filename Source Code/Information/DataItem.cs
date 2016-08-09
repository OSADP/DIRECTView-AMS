using System;
using System.Collections.Generic;
using System.Linq;

namespace DIRECTView.Information
{
    public class DataItem
    {
        public String Time { get; set; }
        public double Car { get; set; }
        public double Bus { get; set; }
        public double Truck { get; set; }
        public DataItem(String Time, double Car = 0, double Bus = 0, double Truck = 0)
        {
            this.Time = Time;
            this.Car = Car;
            this.Bus = Bus;
            this.Truck = Truck;
        }
    }
}
