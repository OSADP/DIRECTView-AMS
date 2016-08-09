using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class ScreenLine : DataSeries
    {
        public int ID { get; set; }
        public int Total { get; set; }
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Directions Direction { get; set; }
        public ScreenLine() { P1 = new Point(); P2 = new Point(); Name = String.Empty; Direction = Directions.UnKnown; }

        public ScreenLine(ScreenLine ScreenLine)
        {
            this.ID = ScreenLine.ID;
            this.Total = ScreenLine.Total;
            this.P1 = ScreenLine.P1;
            this.P2 = ScreenLine.P2;
            this.Direction = ScreenLine.Direction;
            this.Name = ScreenLine.Name;
           
        }
    }
}
