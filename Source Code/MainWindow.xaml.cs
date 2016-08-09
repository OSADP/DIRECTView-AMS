using DevExpress.Utils.Design;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DIRECTView.Information;
using DIRECTView.Information.ReadersWriters;
using DevExpress.Xpf.Ribbon;
using DIRECTView.Controls.Charts;
using DevExpress.Xpf.NavBar;
using DIRECTView.Controls.Scenarios;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Editors;

namespace DIRECTView
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private String InputPath = String.Empty;
		public static String BasePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		SortedList<String, String> AvailableDataNames = new SortedList<String, String>();

		public Data Data = new Data();
		public List<BarCheckItem> ChartButtons = new List<BarCheckItem>();
		public SortedList<String, Chart> ChartScreens = new SortedList<String, Chart>();
		public SortedList<String, Chart> ScreenLine_Charts = new SortedList<String, Chart>();
		public SortedList<String, String> SelectedScenarios = new SortedList<String, String>();
		public SortedList<String, ScenarioItem> AllScenarios = new SortedList<String, ScenarioItem>();
		public MainWindow()
		{
			InputPath = System.IO.Path.Combine(BasePath, "Input");
			InitializeComponent();
			ChartsPage.MainWindow = this;
			ChartsPage.Data = Data;
			// Data.Scenarios.Serialize();
			Data.ParseScenariosData(System.IO.Path.Combine(InputPath, "Scenarios.json"));
			foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
			{
OperationalConditions.Conditions = (Conditions)   Enum.Parse(typeof(Conditions), OperationalConditions.ID.Replace("-","_"));
				foreach (Scenario Scenario in OperationalConditions.Scenarios)
				{
					Scenario.Conditions = OperationalConditions.Conditions;
				}
			}

			ChartScreens.Add("FuelConsumption", ChartsPage.FuelConsumption_Chart);
			ChartScreens.Add("CarbonDioxide", ChartsPage.CarbonDioxide_Chart);
			ChartScreens.Add("NitrogenOxide", ChartsPage.NitrogenOxide_Chart);
			ChartScreens.Add("TravelTime__EntireSystem", ChartsPage.TravelTime__EntireSystem_Chart);
			ChartScreens.Add("TravelTime__US75Northbound", ChartsPage.TravelTime__US75Northbound_Chart);
			ChartScreens.Add("TravelTime__US75Southbound", ChartsPage.TravelTime__US75Southbound_Chart);

			LoadData();

			Filters.OC_1.SetValue(CheckEdit.ToolTipProperty, Data.OperationalConditionsList["OC-1"].Description);
			Filters.OC_2.SetValue(CheckEdit.ToolTipProperty, Data.OperationalConditionsList["OC-2"].Description);
			Filters.OC_3.SetValue(CheckEdit.ToolTipProperty, Data.OperationalConditionsList["OC-3"].Description);
			Filters.OC_4.SetValue(CheckEdit.ToolTipProperty, Data.OperationalConditionsList["OC-4"].Description);
			Filters.CheckEdit_StatusChanged();
			ChartsPage.Summary.ItemsSource = ChartsPage.TravelTime__EntireSystem_Chart.SummaryTable;
			ChartsPage.Summary.RefreshData();
			ChartsPage.Summary.Columns[0].Width = 700;
			ChartsPage.Summary.Columns[1].Width = 200;
			if (ChartsPage.CurrentChart.ScreenLine == null) { ChartsPage.Summary.Columns[2].Width = 200; }
			Filters.DeSelctAllItem.Click += ChartsPage.RefreshViews_Click;
		}
		private void LoadData()
		{

			SortedList<int, ScreenLine> ScreenLines = DataReader.ParseScreenLines(System.IO.Path.Combine(InputPath, "ScreenLines.txt"));
			foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
			{
				foreach (Scenario Scenario in OperationalConditions.Scenarios)
				{

					Scenario.DataSeries.Add("FuelConsumption", Scenario.FuelConsumption);
					Scenario.DataSeries.Add("CarbonDioxide", Scenario.CarbonDioxide);
					Scenario.DataSeries.Add("NitrogenOxide", Scenario.NitrogenOxide);
					Scenario.DataSeries.Add("TravelTime__EntireSystem", Scenario.TravelTime_EntireSystem);
					Scenario.DataSeries.Add("TravelTime__US75Northbound", Scenario.TravelTime_US75_NB);
					Scenario.DataSeries.Add("TravelTime__US75Southbound", Scenario.TravelTime_US75_SB);
					foreach (int ID in ScreenLines.Keys)
					{
						String ScreenLine_ID = String.Format("_{0}", ScreenLines[ID].ID);
						Scenario.ScreenLines.Add(ScreenLine_ID, new ScreenLine(ScreenLines[ID]));
						Scenario.ScreenLines[ScreenLine_ID].Name = Scenario.Folder;
						Scenario.DataSeries.Add(ScreenLine_ID, Scenario.ScreenLines[ScreenLine_ID]);
					}

					if (Scenario == OperationalConditions.DoNothingScenario) { continue; }
					ScenarioItem ScenarioItem = new ScenarioItem(Scenario, this);
					if (OperationalConditions.ID.Equals("OC-1")) { Filters.OC_1_Group.Children.Add(ScenarioItem); }
					else if (OperationalConditions.ID.Equals("OC-2")) { Filters.OC_2_Group.Children.Add(ScenarioItem); }
					else if (OperationalConditions.ID.Equals("OC-3")) { Filters.OC_3_Group.Children.Add(ScenarioItem); }
					else if (OperationalConditions.ID.Equals("OC-4")) { Filters.OC_4_Group.Children.Add(ScenarioItem); }
					ScenarioItem.SetValue(DockPanel.DockProperty, System.Windows.Controls.Dock.Top);
					ScenarioItem.Group.State = GroupBoxState.Minimized;
					AllScenarios.Add(Scenario.Folder, ScenarioItem);
				}

			}
			TimeSpan StartTime = new TimeSpan(14, 0, 0);
			TimeSpan Begin = new TimeSpan(16, 0, 0);
			TimeSpan End = new TimeSpan(19, 0, 0);

			ImageSource Chart_16By16 = DXImageHelper.GetImageSource("Chart", ImageSize.Size16x16, ImageType.Colored);
			ImageSource Chart_32By32 = DXImageHelper.GetImageSource("Chart", ImageSize.Size32x32, ImageType.Colored);
			foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
			{
				foreach (Scenario Scenario in OperationalConditions.Scenarios)
				{

					String EnvironmentFileName = System.IO.Path.Combine(InputPath, OperationalConditions.ID, Scenario.Folder, "Emissions.txt");
					String TravelTimesFileName = System.IO.Path.Combine(InputPath, OperationalConditions.ID, Scenario.Folder, "MOP.txt");
					String ScreenLinesFileName = System.IO.Path.Combine(InputPath, OperationalConditions.ID, Scenario.Folder, "ScreenlineThroughput.xml");
					DataReader.ReadEnvironmentMeasures(Scenario, OperationalConditions.DoNothingScenario, EnvironmentFileName, StartTime, Begin, End);
					DataReader.ReadTravelTimesMeasures(Scenario, OperationalConditions.DoNothingScenario, TravelTimesFileName, StartTime, Begin, End);
					DataReader.ReadScreenLinesMeasures(Scenario, OperationalConditions.DoNothingScenario, ScreenLinesFileName, StartTime, Begin, End);
				}
			}


			foreach (ScreenLine ScreenLine in ScreenLines.Values)
			{
				BarCheckItem BarCheckItem = new BarCheckItem();
				BarCheckItem.ItemClick += Visibility_ItemClick;
				BarCheckItem.IsChecked = false;
				BarCheckItem.AllowUncheckInGroup = true;
				BarCheckItem.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
				if (ScreenLine.Direction == Directions.Northbound) { BarCheckItem.Glyph = Ribbon.B1.Glyph; BarCheckItem.LargeGlyph = Ribbon.B1.LargeGlyph; } else { BarCheckItem.Glyph = Ribbon.B2.Glyph; BarCheckItem.LargeGlyph = Ribbon.B2.LargeGlyph; }
				BarCheckItem.GlyphAlignment = System.Windows.Controls.Dock.Bottom;
				BarCheckItem.GlyphSize = GlyphSize.Large;
				String ID;
				BarCheckItem.Content = ID = String.Format("{0}:{1}", ScreenLine.ID, ScreenLine.Name);
				BarCheckItem.ToolTip = String.Format("{0}:{1}[{2}]", ScreenLine.ID, ScreenLine.Name, ScreenLine.Direction.ToString());
				if (ScreenLine.Direction == Directions.Northbound) { Ribbon.US75NorthboundRibbonPageGroup.Items.Add(BarCheckItem); } else { Ribbon.US75SouthboundRibbonPageGroup.Items.Add(BarCheckItem); }


				Chart ScreenLine_Chart = new Chart() { Visibility = Visibility.Hidden, ScreenLine = ScreenLine, Name = String.Format("_{0}", ScreenLine.ID) };
				ChartsPage.Layout.Children.Add(ScreenLine_Chart);
				ScreenLine_Chart.SetValue(Grid.RowProperty, 1);
				ScreenLine_Chart.SetValue(Grid.ColumnProperty, 1);
				ChartScreens.Add((String)BarCheckItem.Content, ScreenLine_Chart);
				ScreenLine_Charts.Add((String)BarCheckItem.Content, ScreenLine_Chart);
				ScreenLine_Chart.SetData(Data, Begin, End);


				foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
				{
					ScreenLine_Chart.DoNothingLineSeries[OperationalConditions.ID].Visible = false;
				}
				ScreenLine_Chart.SummaryTable.Columns.Clear();
				ScreenLine_Chart.SummaryTable.Columns.Add("Name", typeof(String));
				ScreenLine_Chart.SummaryTable.Columns.Add("Total", typeof(String));

				ScreenLine_Chart.YAxisTitle.Content = "Number of Vehicles";
			}
			String Content = String.Empty;
			foreach (RibbonPageGroup _RibbonPageGroup in Ribbon.RibbonPage.ActualGroups)
			{
				foreach (BarCheckItem BarCheckItem in _RibbonPageGroup.Items)
				{
					if (!BarCheckItem.Name.Equals("B1") && !BarCheckItem.Name.Equals("B2")) { ChartButtons.Add(BarCheckItem); BarCheckItem.ItemClick += Visibility_ItemClick; }
				}
			}

			ChartsPage.CarbonDioxide_Chart.SetData(Data, Begin, End);
			ChartsPage.FuelConsumption_Chart.SetData(Data, Begin, End);
			ChartsPage.NitrogenOxide_Chart.SetData(Data, Begin, End);

			ChartsPage.TravelTime__EntireSystem_Chart.SetData(Data, Begin, End);
			ChartsPage.TravelTime__US75Northbound_Chart.SetData(Data, Begin, End);
			ChartsPage.TravelTime__US75Southbound_Chart.SetData(Data, Begin, End);

			foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
			{
				ChartsPage.FuelConsumption_Chart.DoNothingLineSeries[OperationalConditions.ID].Visible = false;
				ChartsPage.CarbonDioxide_Chart.DoNothingLineSeries[OperationalConditions.ID].Visible = false;
				ChartsPage.NitrogenOxide_Chart.DoNothingLineSeries[OperationalConditions.ID].Visible = false;

				//foreach (Chart ScreenLine_Chart in ChartScreens.Values)
				//{
				//    ScreenLine_Chart.DoNothingLineSeries[OperationalConditions.ID].Visible = false;
				//}
			}
		}
		#region UI Events Handlers
		private void Visibility_ItemClick(object sender, ItemClickEventArgs e)
		{
			BarCheckItem BarCheckItem = (BarCheckItem)sender;
			String Name = (String)BarCheckItem.Name;
			if (Name.Equals("")) { Name = (String)BarCheckItem.Content; }
			foreach (BarCheckItem Item in ChartButtons) { Item.IsChecked = false; }
			BarCheckItem.IsChecked = true;
			foreach (String ChartScreen in ChartScreens.Keys)
			{
				if (ChartScreen.Equals(Name))
				{
					ChartScreens[ChartScreen].Visibility = Visibility.Visible;
					ChartsPage.Summary.ItemsSource = ChartScreens[ChartScreen].SummaryTable;
					ChartsPage.CurrentChart = ChartScreens[ChartScreen];
					ChartsPage.Summary.Columns[0].Width = 700;
					ChartsPage.Summary.Columns[1].Width = 200;
					if (ChartsPage.CurrentChart.ScreenLine == null) { ChartsPage.Summary.Columns[2].Width = 200; }
					Filters.RefreshColors(ChartsPage);

				}
				else { ChartScreens[ChartScreen].Visibility = Visibility.Hidden; }
			}
			ChartsPage.Summary.RefreshData();

			ChartsPage.Summary.Columns[0].Width = 700;
			ChartsPage.Summary.Columns[1].Width = 200;
			if (ChartsPage.CurrentChart.ScreenLine == null) { ChartsPage.Summary.Columns[2].Width = 200; }

		}
		#endregion
	}
}
