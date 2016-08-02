using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRECTView.Information
{
	public class Incident
	{
		public String ID { get; set; }
		public String Date { get; set; }
		public String Type { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public int ClosedLanes { get; set; }
		public String FacilityName { get; set; }
		public String Direction { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		
	}
}
