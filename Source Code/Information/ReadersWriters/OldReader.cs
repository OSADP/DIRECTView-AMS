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
	public class OldReader
	{
		public static SortedList<int, ScreenLine> ReadScreenLineNames(String RootFolder)
		{
			SortedList<int, ScreenLine> ScreenLineNames = new SortedList<int, ScreenLine>();
			String FileName = Path.Combine(RootFolder, RootFolder, "ScreenLines.txt");
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
					if (ScreenLineNames.ContainsKey(ScreenLine.ID) == false) { ScreenLineNames.Add(ScreenLine.ID, ScreenLine); }
				}
			}
			return ScreenLineNames;
		}
		public static void ReadScreenLines(Data Data, SortedList<String, String> AvailableDataNames, String RootFolder, TimeSpan StartTime, TimeSpan Begin, TimeSpan End)
		{

			//foreach (String FolderName in AvailableDataNames.Values)
			//{
			//	String FileName = Path.Combine(RootFolder, FolderName, "MOP.txt");
			//	if (File.Exists(FileName) == false) { continue; }
			//	TextReader TextReader = File.OpenText(FileName);
			//	String Line = null;

			//	TimeSpan Time;
			//	String Facilty;
			//	double Car;
			//	double Bus;
			//	double Truck;
			//	double Total;

			//	TextReader.ReadLine();
			//	while ((Line = TextReader.ReadLine()) != null)
			//	{
			//		String[] Columns = Line.Split(new Char[] { '\t' });
			//		try
			//		{
			//			Facilty = Columns[0].Trim();

			//			Time = TimeSpan.Parse(Columns[1].Trim());
			//			Time += StartTime;
			//			if (Time < Begin || Time > End) { continue; }
			//			Total = Car = double.Parse(Columns[5].Trim());
			//			Bus = double.Parse(Columns[16].Trim());
			//			Truck = double.Parse(Columns[60].Trim());


			//			if (Data.TravelTimeDataCollection.ContainsKey(Facilty))
			//			{
			//				String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Name = FolderName;
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Availabe = true;
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Add(TimeStr, new DataItem(TimeStr, Car, Bus, Truck));
			//			}


			//		}
			//		catch (Exception Exception)
			//		{
			//			String Msg = Exception.Message;
			//		}
			//	}

			//}
			//foreach (String Facility in Data.TravelTimeDataCollection.Keys)
			//{
			//	foreach (String FolderName in AvailableDataNames.Values)
			//	{
			//		if (FolderName.Equals("Do Nothing")) { continue; }
			//		if (!Data.TravelTimeDataCollection[Facility][FolderName].Availabe) { continue; }

			//		int Count = 0;
			//		Data.TravelTimeDataCollection[Facility][FolderName].Average = 0;

			//		foreach (String Time in Data.TravelTimeDataCollection[Facility]["Do Nothing"].Keys)
			//		{
			//			Count++;
			//			double Car = AdjustData(Data.TravelTimeDataCollection[Facility][FolderName], Data.TravelTimeDataCollection[Facility]["Do Nothing"], Time, true, FolderName, Facility);
			//			if (Data.TravelTimeDataCollection[Facility][FolderName].Maximum < Car) { Data.TravelTimeDataCollection[Facility][FolderName].Maximum = Car; }
			//			Data.TravelTimeDataCollection[Facility][FolderName].Average += Car;

			//		}
			//		Data.TravelTimeDataCollection[Facility][FolderName].Average = Data.TravelTimeDataCollection[Facility][FolderName].Average / Count;
			//	}
			//}
			
			//foreach (String Facility in Data.TravelTimeDataCollection.Keys)
			//{
			//	foreach (String FolderName in AvailableDataNames.Values)
			//	{
			//		if (FolderName.Equals("Do Nothing")) { continue; }
			//		if (!Data.TravelTimeDataCollection[Facility][FolderName].Availabe) { continue; }

			//		foreach (String _Time in Data.TravelTimeDataCollection[Facility]["Do Nothing"].Keys)
			//		{
			//			TimeSpan _5Minutes = new TimeSpan(0, 5, 0);
			//			TimeSpan Time = TimeSpan.Parse(_Time) + _5Minutes;

			//			String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
			//			Data.TravelTimeDataCollection[Facility][FolderName].Add(TimeStr, new DataItem(TimeStr, 0, 0, 0));
			//		}

			//	}
			//}

		}
		public static void ReadTravelTimes(Data Data, SortedList<String, String> AvailableDataNames, String RootFolder, TimeSpan StartTime, TimeSpan Begin, TimeSpan End)
		{

			//foreach (String FolderName in AvailableDataNames.Values)
			//{
			//	String FileName = Path.Combine(RootFolder, FolderName, "MOP.txt");
			//	if (File.Exists(FileName) == false) { continue; }
			//	TextReader TextReader = File.OpenText(FileName);
			//	String Line = null;

			//	TimeSpan Time;
			//	String Facilty;
			//	double Car;
			//	double Bus;
			//	double Truck;
			//	double Total;

			//	Line = TextReader.ReadLine();
			//	Line = TextReader.ReadLine();
			//	while ((Line = TextReader.ReadLine()) != null)
			//	{
			//		String[] Columns = Line.Split(new Char[] { '\t' });
			//		try
			//		{
			//			Facilty = Columns[0].Trim();

			//			Time = TimeSpan.Parse(Columns[1].Trim());
			//			Time += StartTime;
			//			if (Time < Begin || Time > End) { continue; }
			//			Total = Car = double.Parse(Columns[5].Trim());
			//			Bus = double.Parse(Columns[16].Trim());
			//			Truck = double.Parse(Columns[60].Trim());


			//			if (Data.TravelTimeDataCollection.ContainsKey(Facilty))
			//			{
			//				String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Name = FolderName;
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Availabe = true;
			//				Data.TravelTimeDataCollection[Facilty][FolderName].Add(TimeStr, new DataItem(TimeStr, Car, Bus, Truck));
			//			}


			//		}
			//		catch (Exception Exception)
			//		{
			//			String Msg = Exception.Message;
			//		}
			//	}

			//}
			//foreach (String Facility in Data.TravelTimeDataCollection.Keys)
			//{
			//	foreach (String FolderName in AvailableDataNames.Values)
			//	{
			//		if (FolderName.Equals("Do Nothing")) { continue; }
			//		if (!Data.TravelTimeDataCollection[Facility][FolderName].Availabe) { continue; }

			//		int Count = 0;
			//		Data.TravelTimeDataCollection[Facility][FolderName].Average = 0;

			//		foreach (String Time in Data.TravelTimeDataCollection[Facility]["Do Nothing"].Keys)
			//		{
			//			Count++;
			//			double Car = AdjustData(Data.TravelTimeDataCollection[Facility][FolderName], Data.TravelTimeDataCollection[Facility]["Do Nothing"], Time, true, FolderName, Facility);
			//			if (Data.TravelTimeDataCollection[Facility][FolderName].Maximum < Car) { Data.TravelTimeDataCollection[Facility][FolderName].Maximum = Car; }
			//			Data.TravelTimeDataCollection[Facility][FolderName].Average += Car;

			//		}
			//		Data.TravelTimeDataCollection[Facility][FolderName].Average = Data.TravelTimeDataCollection[Facility][FolderName].Average / Count;
			//	}
			//}
		}
		public static void ReadEnvironmentMeasures(Data Data, SortedList<String, String> AvailableDataNames, String RootFolder, TimeSpan StartTime, TimeSpan Begin, TimeSpan End)
		{
			//foreach (String FolderName in AvailableDataNames.Values)
			//{
			//	if (FolderName.Equals("")) { }
			//	String FileName = Path.Combine(RootFolder, FolderName, "Emissions.txt");
			//	if (File.Exists(FileName) == false) { continue; }

			//	TextReader TextReader = File.OpenText(FileName);
			//	String Line = null;

			//	TimeSpan Time;
			//	double CarFuelConsumption;
			//	double BusFuelConsumption;
			//	double TruckFuelConsumption;

			//	double CarCarbonDioxide;
			//	double BusCarbonDioxide;
			//	double TruckCarbonDioxide;

			//	double CarNitrogenOxides;
			//	double BusNitrogenOxides;
			//	double TruckNitrogenOxides;

			//	TextReader.ReadLine();
			//	Data.FuelConsumptionDataCollection[FolderName].Name = FolderName; Data.FuelConsumptionDataCollection[FolderName].Availabe = true;
			//	Data.CarbonDioxideDataCollection[FolderName].Name = FolderName; Data.CarbonDioxideDataCollection[FolderName].Availabe = true;
			//	Data.NitrogenOxideDataCollection[FolderName].Name = FolderName; Data.NitrogenOxideDataCollection[FolderName].Availabe = true;
			//	while ((Line = TextReader.ReadLine()) != null)
			//	{
			//		String[] Columns = Line.Split(new Char[] { ' ', '\t', ',' });
			//		try
			//		{

			//			Time = TimeSpan.Parse(Columns[0].Trim());
			//			Time += StartTime;
			//			if (Time < Begin || Time > End) { continue; }
			//			CarFuelConsumption = double.Parse(Columns[1].Trim());
			//			BusFuelConsumption = double.Parse(Columns[2].Trim());
			//			TruckFuelConsumption = double.Parse(Columns[3].Trim());

			//			CarCarbonDioxide = double.Parse(Columns[4].Trim());
			//			BusCarbonDioxide = double.Parse(Columns[5].Trim());
			//			TruckCarbonDioxide = double.Parse(Columns[6].Trim());

			//			CarNitrogenOxides = double.Parse(Columns[7].Trim());
			//			BusNitrogenOxides = double.Parse(Columns[8].Trim());
			//			TruckNitrogenOxides = double.Parse(Columns[9].Trim());

			//			String TimeStr = String.Format("{0:00}:{1:00}", Time.Hours, Time.Minutes);

			//			Data.FuelConsumptionDataCollection[FolderName].Add(TimeStr, new DataItem(TimeStr, CarFuelConsumption, BusFuelConsumption, TruckFuelConsumption));
			//			Data.CarbonDioxideDataCollection[FolderName].Add(TimeStr, new DataItem(TimeStr, CarCarbonDioxide, BusCarbonDioxide, TruckCarbonDioxide));
			//			Data.NitrogenOxideDataCollection[FolderName].Add(TimeStr, new DataItem(TimeStr, CarNitrogenOxides, BusNitrogenOxides, TruckNitrogenOxides));


			//		}
			//		catch (Exception Exception)
			//		{
			//			String Msg = Exception.Message;
			//		}
			//	}

			//}

			//foreach (String FolderName in AvailableDataNames.Values)
			//{

			//	if (FolderName.Equals("Do Nothing")) { continue; }
			//	if (!Data.FuelConsumptionDataCollection[FolderName].Availabe) { continue; }
			//	Data.FuelConsumptionDataCollection[FolderName].Average = 0;
			//	Data.CarbonDioxideDataCollection[FolderName].Average = 0;
			//	Data.NitrogenOxideDataCollection[FolderName].Average = 0;
			//	int Count = 0;
			//	foreach (String Time in Data.FuelConsumptionDataCollection["Do Nothing"].Keys)
			//	{
			//		Count++;
			//		double FuelConsumption = AdjustData(Data.FuelConsumptionDataCollection[FolderName], Data.FuelConsumptionDataCollection["Do Nothing"], Time, false, FolderName, "");
			//		double CarbonDioxide = AdjustData(Data.CarbonDioxideDataCollection[FolderName], Data.CarbonDioxideDataCollection["Do Nothing"], Time, false, FolderName, "");
			//		double NitrogenOxide = AdjustData(Data.NitrogenOxideDataCollection[FolderName], Data.NitrogenOxideDataCollection["Do Nothing"], Time, false, FolderName, "");

			//		Data.FuelConsumptionDataCollection[FolderName].Average += FuelConsumption;
			//		Data.CarbonDioxideDataCollection[FolderName].Average += CarbonDioxide;
			//		Data.NitrogenOxideDataCollection[FolderName].Average += NitrogenOxide;

			//		if (Data.FuelConsumptionDataCollection[FolderName].Maximum < FuelConsumption) { Data.FuelConsumptionDataCollection[FolderName].Maximum = FuelConsumption; }
			//		if (Data.CarbonDioxideDataCollection[FolderName].Maximum < CarbonDioxide) { Data.CarbonDioxideDataCollection[FolderName].Maximum = CarbonDioxide; }
			//		if (Data.NitrogenOxideDataCollection[FolderName].Maximum < NitrogenOxide) { Data.NitrogenOxideDataCollection[FolderName].Maximum = NitrogenOxide; }

			//	}
			//	Data.FuelConsumptionDataCollection[FolderName].Average = Data.FuelConsumptionDataCollection[FolderName].Average / Count;
			//	Data.CarbonDioxideDataCollection[FolderName].Average = Data.CarbonDioxideDataCollection[FolderName].Average / Count;
			//	Data.NitrogenOxideDataCollection[FolderName].Average = Data.NitrogenOxideDataCollection[FolderName].Average / Count;
			//}
		}
		private static double AdjustData(DataSeries DataSeries1, DataSeries DataSeries2, String Time, bool Percentage, String FolderName, String Facility)
		{
			
			//DataSeries1[Time].Car = DataSeries2[Time].Car - DataSeries1[Time].Car;
			//DataSeries1[Time].Bus = DataSeries2[Time].Bus - DataSeries1[Time].Bus;
			//DataSeries1[Time].Truck = DataSeries2[Time].Truck - DataSeries1[Time].Truck;

			//if (Percentage)
			//{
			//	DataSeries1[Time].Car = DataSeries1[Time].Car / DataSeries2[Time].Car;
			//	DataSeries1[Time].Bus = DataSeries1[Time].Bus / DataSeries2[Time].Bus;
			//	DataSeries1[Time].Truck = DataSeries1[Time].Truck / DataSeries2[Time].Truck;

			//}
			return DataSeries1[Time].Car;

		}
	}
}
