using System;
using System.Collections.Generic;
using System.Linq;

namespace DIRECTView.Information
{
    public class DataSeries : SortedList<String, DataItem>
    {
        public String Name { get; set; }
        public double Maximum { get; set; }
        public double Average { get; set; }
        public bool Availabe { get; set; }
        public DataSeries() { Maximum = double.MinValue; Name = String.Empty; Availabe = false; }
    }
}
