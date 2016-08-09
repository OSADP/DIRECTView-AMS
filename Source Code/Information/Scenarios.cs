using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Charts;
using DIRECTView.Controls.Scenarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;

namespace DIRECTView.Information
{
	public class Scenarios : List< Scenario>
    {
		//public SortedList<String, OperationalConditions> OperationalConditionsList { get; set; }
		//public List<Scenario> ScenariosList { get; set; }

		public String Serialize()
		{
			String Result = new JavaScriptSerializer().Serialize(this);
			Console.WriteLine(Result);
			return Result;

		}
		public void ParseJsonFile(String FileName)
		{
			string Lines = File.ReadAllText(FileName);
			Scenarios Scenarios = JsonConvert.DeserializeObject<Scenarios>(Lines.Replace("[]","{}"));
            foreach (Scenario Scenario in Scenarios) {
                this.Add(Scenario);
            }
			Scenarios = null;
		}
	}
}