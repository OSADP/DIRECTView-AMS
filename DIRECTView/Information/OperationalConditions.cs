using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace DIRECTView.Information
{
    public enum Conditions { OC_1 = 1, OC_2 = 2, OC_3 = 3, OC_4 = 4 }
    public class OperationalConditions
    {
        public Scenarios Scenarios { get; set; }
        public String ID { get; set; }
        public String Cluster { get; set; }
        [ScriptIgnore]
        public Conditions Conditions { get; set; }
        [ScriptIgnore]
        public Scenario DoNothingScenario { get; set; }
        [ScriptIgnore]
        public int VisibleItems { get; set; }
        public String Description { get; set; }

		public SortedList<int, Incident> Incidents { get; set; }

		public OperationalConditions() { this.Scenarios = new Scenarios(); this.Incidents= new SortedList<int,Incident>(); VisibleItems = 0; }
        public OperationalConditions(String ID = "", String Cluster = "", String Description = "") : this()
        {
            this.ID = ID;
            this.Cluster = Cluster;
            this.Description = Description;
            Conditions = (Conditions)Enum.Parse(typeof(Conditions), ID.Replace("-", "_"), true);

        }
    }
}
