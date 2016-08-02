using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DIRECTView.Information.ReadersWriters
{
    public class ScreenlineReader : IDisposable
    {
        private SortedList<String, ScreenLine> ScreenLines { get; set; }
        private TimeSpan Start { get; set; }
        private TimeSpan Begin { get; set; }
        private TimeSpan End { get; set; }
        public String BasePath { get; set; }
        public long Count { get; set; }
        public XmlReader XmlReader { get; set; }
        public XDocument XDocument { get; set; }
        public String InputPath { get; set; }
        private TimeSpan _5Minutes = new TimeSpan(0, 5, 0);
        public ScreenlineReader(SortedList<String, ScreenLine> ScreenLines, String InputPath, TimeSpan Start, TimeSpan Begin, TimeSpan End)
        {

            this.ScreenLines = ScreenLines;
            this.InputPath = InputPath;
            this.Start = Start;
            this.Begin = Begin;
            this.End = End;
        }
        public void Dispose() { XDocument = null; if (XmlReader != null) XmlReader.Close(); }
        private bool EOF(String XMLTag)
        {
            if (XmlReader == null) { return true; }
            XmlReader.ReadToFollowing(XMLTag);
            if (XmlReader.NodeType == XmlNodeType.None) { return true; }
            try
            {
                String XDocumentStr = "";
                if (XmlReader.NodeType == XmlNodeType.Whitespace) { while (XmlReader.NodeType == XmlNodeType.Whitespace) { XDocumentStr = XmlReader.ReadOuterXml(); } }
                XDocumentStr = XmlReader.ReadOuterXml();
                if (XDocumentStr == null || XDocumentStr == "") { return true; }
                XDocument = XDocument.Parse(XDocumentStr);
                if (XDocument == null || XDocument.Root == null) { return true; }
                return false;
            }
            catch (Exception) { return false; }
        }

        public bool First(String FileName) { XmlReader = new XmlTextReader(FileName); return Next(); }
        private bool Next()
        {
            if (EOF(XMLTag:"Screenline")) { return true; }
            try
            {
                String ID = int.Parse(XDocument.Root.Attribute("ID").Value.Trim()).ToString();
                ID = String.Format("_{0}",ID);
                DataSeries DataSeries = ScreenLines[ID];
                foreach (XElement TimeElement in XDocument.Root.Descendants("Time"))
                {
                    TimeSpan Time = TimeSpan.Parse(TimeElement.Attributes("Time").First().Value.Trim());
                    Time += Start;
                    if (Time < Begin || Time > End) { continue; }
                    int Volume = int.Parse(TimeElement.Attributes("Volume").First().Value.Trim());
                    String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
                    DataSeries.Add(TimeStr, new DataItem(TimeStr, Volume));
                    ScreenLines[ID].Total += Volume;
                    Time = Time + _5Minutes;
                    TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
                    DataSeries.Add(TimeStr, new DataItem(TimeStr, 0));
                }

                return false;
            }
            catch (Exception) { return false; }
        }
        public void Read(String FileName)
        {
           
                Count = 0;
               // String FileName = System.IO.Path.Combine(InputPath, FileName);
                if (!File.Exists(FileName)) { return; }
                bool EOF = First(FileName);
                while (!EOF) { EOF = Next(); Count++; }
                if (XmlReader != null) { XmlReader.Close(); }
            
        }
    }
}
