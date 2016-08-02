using DevExpress.Xpf.Charts;
using MeasuresOfPerformance.Information;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeasuresOfPerformance.Controls.Charts
{
	/// <summary>
	/// Interaction logic for FuelConsumption.xaml
	/// </summary>
	public partial class ScreenLine_Chart : UserControl
	{

		public ScreenLine ScreenLine { get; set; }
		public SortedList<String, BarSideBySideSeries2D> ChartSeries = new SortedList<string, BarSideBySideSeries2D>();
		public DataTable SummaryTable = new DataTable();
		public ScreenLine_Chart()
		{
			InitializeComponent();
			SummaryTable.Columns.Add("Name", typeof(String));
			SummaryTable.Columns.Add("Total", typeof(String));
			Summary.ItemsSource = SummaryTable;
			Name = String.Empty;
		}
		public void SetData(DataCollection DataCollection, TimeSpan Begin, TimeSpan End)
		{
			DataTable DataTable = new DataTable();
			DataTable.Columns.Add("Name", typeof(String));
			DataTable.Columns.Add("Time", typeof(TimeSpan));
			DataTable.Columns.Add("Car", typeof(double));
			foreach (String Name in DataCollection.Keys)
			{
				if (Name.Equals("Do Nothing")) { continue; }
				DataSeries DataSeries = DataCollection[Name];
				foreach (DataItem DataItem in DataSeries.Values)
				{
					TimeSpan Time = TimeSpan.Parse(DataItem.Time);
					if (Time < Begin || Time > End) { continue; }
					DataTable.Rows.Add(new object[] { Name, DataItem.Time, DataItem.Car });
				}
			}
			Chart.DataSource = DataTable;
			Chart.BeginInit();
			BarSideBySideSeries2D SeriesTemplate = new BarSideBySideSeries2D();
			Chart.XYDiagram2D.SeriesTemplate = SeriesTemplate;
			SeriesTemplate.ArgumentDataMember = "Time";
			SeriesTemplate.ValueDataMember = "Car";
			Chart.EndInit();
			foreach (BarSideBySideSeries2D BarSideBySideSeries2D in Chart.XYDiagram2D.Series)
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
					String Total = String.Format("{0:#,0}", DataSeries.Average);
					
					SummaryTable.Rows.Add(new object[] { Name, Total });
				}
				else { foreach (DataRow DataRow in SummaryTable.Rows) { if (DataRow["Name"].ToString().Equals(Name)) { DataRow.Delete(); break; } } }
				Summary.RefreshData();
			}
		}
	}
}
