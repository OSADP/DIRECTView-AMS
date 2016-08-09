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
	public partial class NitrogenOxide_Chart : UserControl
	{
		public SortedList<String, BarSideBySideSeries2D> ChartSeries = new SortedList<string, BarSideBySideSeries2D>();
		public DataTable SummaryTable = new DataTable();
		public NitrogenOxide_Chart()
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

			DataTable.Columns.Add("Name", typeof(String));
			DataTable.Columns.Add("Time", typeof(TimeSpan));
			DataTable.Columns.Add("Car", typeof(double));
			//DataTable.Columns.Add("Bus", typeof(double));
			//DataTable.Columns.Add("Truck", typeof(double));
			foreach (String Name in DataCollection.Keys)
			{
				if (Name.Equals("Do Nothing")) { continue; }
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
			Chart.BeginInit();
			//XYDiagram2D XYDiagram2D = new XYDiagram2D();
			//Chart.Diagram = XYDiagram2D;
			BarSideBySideSeries2D SeriesTemplate = new BarSideBySideSeries2D();
			XYDiagram2D.SeriesTemplate = SeriesTemplate;
			//XYDiagram2D.SeriesDataMember = "Name";
			SeriesTemplate.ArgumentDataMember = "Time";
			SeriesTemplate.ValueDataMember = "Car";
			//SeriesTemplate.Model = new GlassCylinderBar2DModel();
			Chart.EndInit();
			foreach (BarSideBySideSeries2D BarSideBySideSeries2D in XYDiagram2D.Series)
			{
				BarSideBySideSeries2D.Visible = false;
				ChartSeries.Add(BarSideBySideSeries2D.DisplayName, BarSideBySideSeries2D);
			}
		}
		public void RefreshView(string Name, bool Visibility, DataSeries DataSeries)
		{
			if (ChartSeries.ContainsKey(Name))
			{
				ChartSeries[Name].Visible = Visibility;
				if (ChartSeries[Name].Visible)
				{
					String Maximum = String.Format("{0:#,0}", DataSeries.Maximum);
					String Average = String.Format("{0:#,0}", DataSeries.Average);
					SummaryTable.Rows.Add(new object[] { Name, Maximum, Average });
				}
				else { foreach (DataRow DataRow in SummaryTable.Rows) { if (DataRow["Name"].ToString().Equals(Name)) { DataRow.Delete(); break; } } }
				Summary.RefreshData();
			}
		}
	}
}
