using DevExpress.Xpf.Charts;
using MeasuresOfPerformance.Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeasuresOfPerformance.Controls.Charts
{
	/// <summary>
	/// Interaction logic for FuelConsumption.xaml
	/// </summary>
	public partial class TravelTime__US75Northbound__Chart : UserControl
	{
		public SortedList<String, Series> ChartSeries = new SortedList<string, Series>();
		public LineSeries2D DoNothingLineSeries = new LineSeries2D();
			public DataTable SummaryTable = new DataTable();
			public TravelTime__US75Northbound__Chart()
		{
			InitializeComponent();

			SummaryTable.Columns.Add("Name", typeof(String));
			SummaryTable.Columns.Add("Maximum", typeof(String));
			SummaryTable.Columns.Add("Average", typeof(String));
			Summary.ItemsSource = SummaryTable;    

		}
		public void SetData(DataCollection DataCollection, TimeSpan Begin, TimeSpan End)
		{
			DataTable DataTable = new DataTable();
			DataTable DoNothingDataTable = new DataTable();


			DataTable.Columns.Add("Name", typeof(String));
			DataTable.Columns.Add("Time", typeof(TimeSpan));
			DataTable.Columns.Add("Car", typeof(double));


			DoNothingDataTable.Columns.Add("Time", typeof(TimeSpan));
			DoNothingDataTable.Columns.Add("Car", typeof(double));
			//DataTable.Columns.Add("Bus", typeof(double));
			//DataTable.Columns.Add("Truck", typeof(double));
			foreach (String Name in DataCollection.Keys)
			{
				if (Name.Equals("Do Nothing"))
				{
					DataSeries DoNothingDataSeries = DataCollection[Name];
					foreach (DataItem DataItem in DoNothingDataSeries.Values)
					{
						TimeSpan Time = TimeSpan.Parse(DataItem.Time);
						if (Time < Begin || Time > End) { continue; }
						DoNothingDataTable.Rows.Add(new object[] { DataItem.Time, DataItem.Car });
					}
					continue;
				}
				DataSeries DataSeries = DataCollection[Name];
				foreach (DataItem DataItem in DataSeries.Values)
				{
					TimeSpan Time = TimeSpan.Parse(DataItem.Time);
					if (Time < Begin || Time > End) { continue; }
					//DataTable.Rows.Add(new object[] { Name, DataItem.Time, DataItem.Car, DataItem.Bus, DataItem.Truck });
					DataTable.Rows.Add(new object[] { Name, DataItem.Time, DataItem.Car });
				}
			}



			Chart.DataSource = DataTable;
			Chart.Diagram.Series.Add(DoNothingLineSeries);
			SecondaryAxisY2D YSecondaryAxis = ((XYDiagram2D)Chart.Diagram).SecondaryAxesY[0];
			XYDiagram2D.SetSeriesAxisY(DoNothingLineSeries, YSecondaryAxis);
			DoNothingLineSeries.DataSource = DoNothingDataTable;
			DoNothingLineSeries.LineStyle = new LineStyle();
			DoNothingLineSeries.LineStyle.Thickness = 5;
			DoNothingLineSeries.Brush = new SolidColorBrush(Colors.DarkRed);
			Chart.BeginInit();
			DoNothingLineSeries.ArgumentDataMember = "Time";
			DoNothingLineSeries.ValueDataMember = "Car";

			//XYDiagram2D XYDiagram2D = new XYDiagram2D();
			//Chart.Diagram = XYDiagram2D;
			BarSideBySideSeries2D SeriesTemplate = new BarSideBySideSeries2D();
			XYDiagram2D.SeriesTemplate = SeriesTemplate;
			//XYDiagram2D.SeriesDataMember = "Name";
			SeriesTemplate.ArgumentDataMember = "Time";
			SeriesTemplate.ValueDataMember = "Car";

			//SeriesTemplate.Model = new GlassCylinderBar2DModel();
			Chart.EndInit();

			foreach (Series Series in XYDiagram2D.Series)
			{
				if (Series.GetType().Equals(typeof(BarSideBySideSeries2D)))
				{
					//BarSideBySideSeries2D BarSideBySideSeries2D = (BarSideBySideSeries2D)Series;
					Series.Visible = false;
					ChartSeries.Add(Series.DisplayName, Series);
				}

			}
		}
		public void RefreshView(string Name, bool Visibility, DataSeries DataSeries)
		{
			if (ChartSeries.ContainsKey(Name))
			{
				ChartSeries[Name].Visible = Visibility;
				if (ChartSeries[Name].Visible)
				{
					String Maximum = String.Format("{0:P2}", DataSeries.Maximum);
					String Average = String.Format("{0:P2}", DataSeries.Average);
					SummaryTable.Rows.Add(new object[] { Name, Maximum, Average });
				}
				else { foreach (DataRow DataRow in SummaryTable.Rows) { if (DataRow["Name"].ToString().Equals(Name)) { DataRow.Delete(); break; } } }
				Summary.RefreshData();
			}
		}
	}
}
