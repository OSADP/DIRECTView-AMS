using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows;

namespace DIRECTView.Information
{
    public class Scenario
    {
        public String ID { get; set; }
        public String Folder { get; set; }
        public String OperationalConditions { get; set; }
        [ScriptIgnore]
        public Conditions Conditions { get; set; }
        [ScriptIgnore]
        public Boolean IsSimulated { get; set; }
        public String Description { get; set; }

        public ATDMStrategies ATDMStrategies { get; set; }
        public AssesmentAttributes AssesmentAttributes { get; set; }
        public bool IsChecked { get; set; }


        [ScriptIgnore]
        public DataSeries CarbonDioxide = new DataSeries();
        [ScriptIgnore]
        public DataSeries FuelConsumption = new DataSeries();
        [ScriptIgnore]
        public DataSeries NitrogenOxide = new DataSeries();
        [ScriptIgnore]
        public DataSeries TravelTime_EntireSystem = new DataSeries();
        [ScriptIgnore]
        public DataSeries TravelTime_US75_NB = new DataSeries();
        [ScriptIgnore]
        public DataSeries TravelTime_US75_SB = new DataSeries();
        [ScriptIgnore]
        public SortedList<String, ScreenLine> ScreenLines = new SortedList<String, ScreenLine>();
        [ScriptIgnore]
        public SortedList<String, DataSeries> DataSeries = new SortedList<String, Information.DataSeries>();


        //[ScriptIgnore]
        //public SortedList<String, DataCollection> TravelTimeDataCollection = new SortedList<String, DataCollection>();


        public Scenario()
        {
            this.IsSimulated = false;
            this.ID = String.Empty;
            this.Folder = String.Empty;
            this.Conditions = Conditions.OC_1;
            this.ATDMStrategies = new ATDMStrategies();
            this.AssesmentAttributes = new AssesmentAttributes();
        }
        public Scenario(String OperationalConditions, Conditions Conditions = Conditions.OC_1, String ID = "", String Folder = "") : this()
        {
            this.ID = ID;
            this.Folder = Folder;
            this.OperationalConditions = OperationalConditions;
            this.Conditions = Conditions;
            this.ATDMStrategies = new ATDMStrategies();
            this.AssesmentAttributes = new AssesmentAttributes();
        }
        public Scenario(OperationalConditions OperationalConditions, String ID = "", String Folder = "") :
            this(OperationalConditions.ID, OperationalConditions.Conditions, ID, Folder)
        { }

        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {
            ScenarioItem.Visibility = Visibility.Visible;
            if (Filters["Filters"].IsChecked == false) { return; }
            
            if (ScenarioItem.IsSelected) { return; }
            bool OC_1_Filter = Filters[Conditions.OC_1.ToString()].IsChecked == true; OC_1_Filter = OC_1_Filter && (OC_1_Filter == (Conditions == Conditions.OC_1));
            bool OC_2_Filter = Filters[Conditions.OC_2.ToString()].IsChecked == true; OC_2_Filter = OC_2_Filter && (OC_2_Filter == (Conditions == Conditions.OC_2));
            bool OC_3_Filter = Filters[Conditions.OC_3.ToString()].IsChecked == true; OC_3_Filter = OC_3_Filter && (OC_3_Filter == (Conditions == Conditions.OC_3));
            bool OC_4_Filter = Filters[Conditions.OC_4.ToString()].IsChecked == true; OC_4_Filter = OC_4_Filter && (OC_4_Filter == (Conditions == Conditions.OC_4));
            ScenarioItem.Visibility = (OC_1_Filter || OC_2_Filter || OC_3_Filter || OC_4_Filter) ? Visibility.Visible : Visibility.Collapsed;
            if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }
            ATDMStrategies.CheckFilters(Filters, ScenarioItem);
            if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }
            AssesmentAttributes.CheckFilters(Filters, ScenarioItem);
        }
    }
}
