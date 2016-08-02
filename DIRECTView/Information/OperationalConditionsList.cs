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
    public class OperationalConditionsList : SortedList<String, OperationalConditions>
    {
        
        public String Serialize()
        {
            String Result = new JavaScriptSerializer().Serialize(this);
            Console.WriteLine(Result);
            return Result;

        }
        public void ParseJsonFile(String FileName)
        {
            string Lines = File.ReadAllText(FileName);
            OperationalConditionsList OperationalConditionsList = JsonConvert.DeserializeObject<OperationalConditionsList>(Lines.Replace("[]", "{}"));
            foreach (String OC_ID in OperationalConditionsList.Keys)
            {
                this.Add(OC_ID, OperationalConditionsList[OC_ID]);
            }
        }
    }
}
