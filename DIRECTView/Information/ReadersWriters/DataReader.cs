using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace DIRECTView.Information.ReadersWriters
{
    public class DataReader
    {
        public static SortedList<int, ScreenLine> ParseScreenLines(string FileName)
        {
            SortedList<int, ScreenLine> ScreenLines = new SortedList<int, ScreenLine>();

            if (File.Exists(FileName))
            {
                TextReader TextReader = File.OpenText(FileName);

                String Line = TextReader.ReadLine();
                Line = TextReader.ReadLine();
                while ((Line = TextReader.ReadLine()) != null)
                {
                    ScreenLine ScreenLine = new ScreenLine();
                    String[] Columns = Line.Split(new Char[] { '\t' });
                    ScreenLine.ID = int.Parse(Columns[0]);
                    ScreenLine.Name = Columns[7];
                    ScreenLine.P1 = new Point(double.Parse(Columns[1]), double.Parse(Columns[2]));
                    ScreenLine.P2 = new Point(double.Parse(Columns[3]), double.Parse(Columns[4]));
                    String DIR = Columns[6];
                    ScreenLine.Direction = DIR.ToUpper().Equals("NB") ? Directions.Northbound : DIR.ToUpper().Equals("SB") ? Directions.Southbound : Directions.UnKnown;
                    if (ScreenLines.ContainsKey(ScreenLine.ID) == false) { ScreenLines.Add(ScreenLine.ID, ScreenLine); }
                }
            }
            return ScreenLines;
        }
        private static double AdjustData(DataSeries DataSeries1, DataSeries DataSeries2, String Time, bool Percentage, String FolderName, String Facility)
        {
            DataSeries1[Time].Car = DataSeries2[Time].Car - DataSeries1[Time].Car;
            DataSeries1[Time].Bus = DataSeries2[Time].Bus - DataSeries1[Time].Bus;
            DataSeries1[Time].Truck = DataSeries2[Time].Truck - DataSeries1[Time].Truck;

            if (Percentage)
            {
                DataSeries1[Time].Car = DataSeries1[Time].Car / DataSeries2[Time].Car;
                DataSeries1[Time].Bus = DataSeries1[Time].Bus / DataSeries2[Time].Bus;
                DataSeries1[Time].Truck = DataSeries1[Time].Truck / DataSeries2[Time].Truck;

            }
            return DataSeries1[Time].Car;

        }
        public static void ReadEnvironmentMeasures(Scenario Scenario, Scenario DoNothingScenario, string FileName, TimeSpan StartTime, TimeSpan BeginTime, TimeSpan EndTime)
        {
            Scenario.FuelConsumption.Name = Scenario.Folder;
            Scenario.CarbonDioxide.Name = Scenario.Folder;
            Scenario.NitrogenOxide.Name = Scenario.Folder;

            if (!File.Exists(FileName)) { return; }
            TextReader TextReader = File.OpenText(FileName);
            {
                String Line = null;

                TimeSpan Time;
                double CarFuelConsumption;
                double BusFuelConsumption;
                double TruckFuelConsumption;

                double CarCarbonDioxide;
                double BusCarbonDioxide;
                double TruckCarbonDioxide;

                double CarNitrogenOxides;
                double BusNitrogenOxides;
                double TruckNitrogenOxides;

                TextReader.ReadLine();
                Scenario.FuelConsumption.Availabe = Scenario.CarbonDioxide.Availabe = Scenario.NitrogenOxide.Availabe = true;
                while ((Line = TextReader.ReadLine()) != null)
                {
                    String[] Columns = Line.Split(new Char[] { ' ', '\t', ',' });
                    try
                    {

                        Time = TimeSpan.Parse(Columns[0].Trim());
                        Time += StartTime;
                        if (Time < BeginTime || Time > EndTime) { continue; }
                        CarFuelConsumption = double.Parse(Columns[1].Trim());
                        BusFuelConsumption = double.Parse(Columns[2].Trim());
                        TruckFuelConsumption = double.Parse(Columns[3].Trim());

                        CarCarbonDioxide = double.Parse(Columns[4].Trim());
                        BusCarbonDioxide = double.Parse(Columns[5].Trim());
                        TruckCarbonDioxide = double.Parse(Columns[6].Trim());

                        CarNitrogenOxides = double.Parse(Columns[7].Trim());
                        BusNitrogenOxides = double.Parse(Columns[8].Trim());
                        TruckNitrogenOxides = double.Parse(Columns[9].Trim());

                        String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);

                        Scenario.FuelConsumption.Add(TimeStr, new DataItem(TimeStr, CarFuelConsumption, BusFuelConsumption, TruckFuelConsumption));
                        Scenario.CarbonDioxide.Add(TimeStr, new DataItem(TimeStr, CarCarbonDioxide, BusCarbonDioxide, TruckCarbonDioxide));
                        Scenario.NitrogenOxide.Add(TimeStr, new DataItem(TimeStr, CarNitrogenOxides, BusNitrogenOxides, TruckNitrogenOxides));

                    }
                    catch (Exception Exception)
                    {
                        String Msg = Exception.Message;
                    }
                }
            }
            if (Scenario == DoNothingScenario) { return; }
            if (!Scenario.FuelConsumption.Availabe) { return; }

            Scenario.FuelConsumption.Average = 0;
            Scenario.CarbonDioxide.Average = 0;
            Scenario.NitrogenOxide.Average = 0;
            int Count = 0;
            foreach (String Time in DoNothingScenario.FuelConsumption.Keys)
            {
                Count++;
                double FuelConsumption = AdjustData(Scenario.FuelConsumption, DoNothingScenario.FuelConsumption, Time, false, Scenario.Folder, "");
                double CarbonDioxide = AdjustData(Scenario.CarbonDioxide, DoNothingScenario.CarbonDioxide, Time, false, Scenario.Folder, "");
                double NitrogenOxide = AdjustData(Scenario.NitrogenOxide, DoNothingScenario.NitrogenOxide, Time, false, Scenario.Folder, "");

                Scenario.FuelConsumption.Average += FuelConsumption;
                Scenario.CarbonDioxide.Average += CarbonDioxide;
                Scenario.NitrogenOxide.Average += NitrogenOxide;

                if (Scenario.FuelConsumption.Maximum < FuelConsumption) { Scenario.FuelConsumption.Maximum = FuelConsumption; }
                if (Scenario.CarbonDioxide.Maximum < CarbonDioxide) { Scenario.CarbonDioxide.Maximum = CarbonDioxide; }
                if (Scenario.NitrogenOxide.Maximum < NitrogenOxide) { Scenario.NitrogenOxide.Maximum = NitrogenOxide; }

            }
            Scenario.FuelConsumption.Average = Scenario.FuelConsumption.Average / Count;
            Scenario.CarbonDioxide.Average = Scenario.CarbonDioxide.Average / Count;
            Scenario.NitrogenOxide.Average = Scenario.NitrogenOxide.Average / Count;

        }
        public static void ReadTravelTimesMeasures(Scenario Scenario, Scenario DoNothingScenario, string FileName, TimeSpan StartTime, TimeSpan BeginTime, TimeSpan EndTime)
        {
            Scenario.TravelTime_EntireSystem.Name = Scenario.Folder;
            Scenario.TravelTime_US75_NB.Name = Scenario.Folder;
            Scenario.TravelTime_US75_SB.Name = Scenario.Folder;
            {
                if (File.Exists(FileName) == false) { return; }
                TextReader TextReader = File.OpenText(FileName);
                String Line = null;

                TimeSpan Time;
                double Car;
                double Bus;
                double Truck;
                double Total;

                Line = TextReader.ReadLine();
                Line = TextReader.ReadLine();
                while ((Line = TextReader.ReadLine()) != null)
                {
                    String[] Columns = Line.Split(new Char[] { '\t' });
                    try
                    {
                        String Facilty = Columns[0].Trim();
                        Time = TimeSpan.Parse(Columns[1].Trim());
                        Time += StartTime;
                        if (Time < BeginTime || Time > EndTime) { continue; }
                        Total = Car = double.Parse(Columns[5].Trim());
                        Bus = double.Parse(Columns[16].Trim());
                        Truck = double.Parse(Columns[60].Trim());
                        String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
                        if (Facilty.Equals("Entire System"))
                        {
                            Scenario.TravelTime_EntireSystem.Availabe = true;
                            Scenario.TravelTime_EntireSystem.Add(TimeStr, new DataItem(TimeStr, Car, Bus, Truck));
                        }
                        else if (Facilty.Equals("US 75 Northbound"))
                        {
                            Scenario.TravelTime_US75_NB.Availabe = true;
                            Scenario.TravelTime_US75_NB.Add(TimeStr, new DataItem(TimeStr, Car, Bus, Truck));
                        }
                        else if (Facilty.Equals("US 75 Southbound"))
                        {
                            Scenario.TravelTime_US75_SB.Availabe = true;
                            Scenario.TravelTime_US75_SB.Add(TimeStr, new DataItem(TimeStr, Car, Bus, Truck));
                        }


                    }
                    catch (Exception Exception)
                    {
                        String Msg = Exception.Message;
                    }
                }
            }
            if (Scenario == DoNothingScenario) { return; }
            if (!Scenario.FuelConsumption.Availabe) { return; }
            Scenario.TravelTime_EntireSystem.Average = Scenario.TravelTime_US75_NB.Average = Scenario.TravelTime_US75_SB.Average = 0;
            int Count = 0;
            foreach (String Time in DoNothingScenario.TravelTime_EntireSystem.Keys)
            {
                Count++;
                double TravelTime_EntireSystem = AdjustData(Scenario.TravelTime_EntireSystem, DoNothingScenario.TravelTime_EntireSystem, Time, true, Scenario.Folder, "Entire System");
                double TravelTime_US75_NB = AdjustData(Scenario.TravelTime_US75_NB, DoNothingScenario.TravelTime_US75_NB, Time, true, Scenario.Folder, "US 75 Northbound");
                double TravelTime_US75_SB = AdjustData(Scenario.TravelTime_US75_SB, DoNothingScenario.TravelTime_US75_SB, Time, true, Scenario.Folder, "US 75 Southbound");

                Scenario.TravelTime_EntireSystem.Average += TravelTime_EntireSystem;
                Scenario.TravelTime_US75_NB.Average += TravelTime_US75_NB;
                Scenario.TravelTime_US75_SB.Average += TravelTime_US75_SB;

                if (Scenario.TravelTime_EntireSystem.Maximum < TravelTime_EntireSystem) { Scenario.TravelTime_EntireSystem.Maximum = TravelTime_EntireSystem; }
                if (Scenario.TravelTime_US75_NB.Maximum < TravelTime_US75_NB) { Scenario.TravelTime_US75_NB.Maximum = TravelTime_US75_NB; }
                if (Scenario.TravelTime_US75_SB.Maximum < TravelTime_US75_SB) { Scenario.TravelTime_US75_SB.Maximum = TravelTime_US75_SB; }

            }
            Scenario.TravelTime_EntireSystem.Average = Scenario.TravelTime_EntireSystem.Average / Count;
            Scenario.TravelTime_US75_NB.Average = Scenario.TravelTime_US75_NB.Average / Count;
            Scenario.TravelTime_US75_SB.Average = Scenario.TravelTime_US75_SB.Average / Count;
        }

        public static void ReadScreenLinesMeasures(Scenario Scenario, Scenario DoNothingScenario, string FileName, TimeSpan StartTime, TimeSpan BeginTime, TimeSpan EndTime)
        {
            new ScreenlineReader(Scenario.ScreenLines, FileName, StartTime, BeginTime, EndTime).Read(FileName);
        }
    }
}
