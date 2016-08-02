using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DIRECTView.Information
{
    public class Data
    {
        public OperationalConditionsList OperationalConditionsList = new OperationalConditionsList();
        public Data()
        {
            //OperationalConditionsList.Add("OC-1", new OperationalConditions("OC-1", "4", "OC-1 Description"));
            //OperationalConditionsList.Add("OC-2", new OperationalConditions("OC-2", "3", "OC-1 Description"));
            //OperationalConditionsList.Add("OC-3", new OperationalConditions("OC-3", "2", "OC-1 Description"));
            //OperationalConditionsList.Add("OC-4", new OperationalConditions("OC-4", "1", "OC-1 Description"));

            //OperationalConditionsList["OC-1"].Scenarios.Add(new Scenario(OperationalConditionsList["OC-1"], "Scenario 1", "Scenario 1 Folder"));
            //OperationalConditionsList["OC-1"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-1"], "Scenario 2", "Scenario 2 Folder"));

            //OperationalConditionsList["OC-2"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-2"], "Scenario 3", "Scenario 3 Folder"));
            //OperationalConditionsList["OC-2"].Scenarios.Add(new Scenario(OperationalConditionsList["OC-2"], "Scenario 4", "Scenario 4 Folder"));

            //OperationalConditionsList["OC-3"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-3"], "Scenario 5", "Scenario 5 Folder"));
            //OperationalConditionsList["OC-3"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-3"], "Scenario 6", "Scenario 6 Folder"));

            //OperationalConditionsList["OC-4"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-4"], "Scenario 7", "Scenario 7 Folder"));
            //OperationalConditionsList["OC-4"].Scenarios.Add( new Scenario(OperationalConditionsList["OC-4"], "Scenario 8", "Scenario 8 Folder"));

            //Serialize();
        }

        public String Serialize()
        {
            String Result = new JavaScriptSerializer().Serialize(this);
            Console.WriteLine(Result);
            return Result;

        }
        /// <summary>
        /// Parse Scenarios Data from a JSON file
        /// </summary>
        /// <param name="FileName"></param>
        public void ParseScenariosData(String FileName)
        {
            string Lines = File.ReadAllText(FileName);
            Data Data = JsonConvert.DeserializeObject<Data>(Lines.Replace("[]", "{}"));
            OperationalConditionsList = Data.OperationalConditionsList;

            Data = null;
            OperationalConditionsList["OC-1"].DoNothingScenario = OperationalConditionsList["OC-1"].Scenarios[0];
            OperationalConditionsList["OC-2"].DoNothingScenario = OperationalConditionsList["OC-2"].Scenarios[0];
            OperationalConditionsList["OC-3"].DoNothingScenario = OperationalConditionsList["OC-3"].Scenarios[0];
            OperationalConditionsList["OC-4"].DoNothingScenario = OperationalConditionsList["OC-4"].Scenarios[0];
        }

        //      public DataCollection CarbonDioxideDataCollection = new DataCollection();
        //public DataCollection FuelConsumptionDataCollection = new DataCollection();
        //public DataCollection NitrogenOxideDataCollection = new DataCollection();
        //public SortedList<String, DataCollection> TravelTimeDataCollection = new SortedList<String, DataCollection>();
        //public SortedList<String, ScreenLine> ScreenLines = new SortedList<String, ScreenLine>();
    }
    public class DataCollection : SortedList<String, DataSeries> { public DataCollection() { } }
    public enum Directions { Northbound, Southbound, UnKnown }
}
