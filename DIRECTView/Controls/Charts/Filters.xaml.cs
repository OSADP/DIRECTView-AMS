using DevExpress.Xpf.Editors;
using DevExpress.Xpf.LayoutControl;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DIRECTView.Controls.Charts
{
	/// <summary>
	/// Interaction logic for Filters.xaml
	/// </summary>
	public partial class Filters : UserControl
	{
		private SortedList<String, CheckEdit> FiltersList = new SortedList<String, CheckEdit>();
		public Filters()
		{
			InitializeComponent();
            FiltersList.Add("Filters", this._Filters);

            FiltersList.Add(this.OC_1.Name, this.OC_1);
			FiltersList.Add(this.OC_2.Name, this.OC_2);
			FiltersList.Add(this.OC_3.Name, this.OC_3);
			FiltersList.Add(this.OC_4.Name, this.OC_4);

			FiltersList.Add(this.DynamicShoulderLanes.Name, this.DynamicShoulderLanes);
			FiltersList.Add(this.AdaptiveRampMetering.Name, this.AdaptiveRampMetering);
			FiltersList.Add(this.DynamicSignalTiming.Name, this.DynamicSignalTiming);
			FiltersList.Add(this.DynamicRouting.Name, this.DynamicRouting);
			FiltersList.Add(this.DynamicallyPricedParking.Name, this.DynamicallyPricedParking);


			FiltersList.Add(this.ErrorInDemandPrediction_Negative_10_Percent.Name, this.ErrorInDemandPrediction_Negative_10_Percent);
			FiltersList.Add(this.ErrorInDemandPrediction_Negative_05_Percent.Name, this.ErrorInDemandPrediction_Negative_05_Percent);
			FiltersList.Add(this.ErrorInDemandPrediction__________00_Percent.Name, this.ErrorInDemandPrediction__________00_Percent);
			FiltersList.Add(this.ErrorInDemandPrediction_Positive_05_Percent.Name, this.ErrorInDemandPrediction_Positive_05_Percent);
			FiltersList.Add(this.ErrorInDemandPrediction_Positive_10_Percent.Name, this.ErrorInDemandPrediction_Positive_10_Percent);


			FiltersList.Add(this.TrafficManagementLatency_00_Minutes.Name, this.TrafficManagementLatency_00_Minutes);
			FiltersList.Add(this.TrafficManagementLatency_05_Minutes.Name, this.TrafficManagementLatency_05_Minutes);
			FiltersList.Add(this.TrafficManagementLatency_10_Minutes.Name, this.TrafficManagementLatency_10_Minutes);


			FiltersList.Add(this.PredictionHorizon_15_Minutes.Name, this.PredictionHorizon_15_Minutes);
			FiltersList.Add(this.PredictionHorizon_30_Minutes.Name, this.PredictionHorizon_30_Minutes);
			FiltersList.Add(this.PredictionHorizon_60_Minutes.Name, this.PredictionHorizon_60_Minutes);

			FiltersList.Add(this.CoverageExtentVariation_02_Miles.Name, this.CoverageExtentVariation_02_Miles);
			FiltersList.Add(this.CoverageExtentVariation_03_Miles.Name, this.CoverageExtentVariation_03_Miles);
			FiltersList.Add(this.CoverageExtentVariation_04_Miles.Name, this.CoverageExtentVariation_04_Miles);

		}
		public Filters(MainWindow MainWindow)
		{
			InitializeComponent();

			DeSelctAllItem.Click += MainWindow.ChartsPage.RefreshViews_Click;
		}
		public void CheckEdit_StatusChanged()
		{
			foreach (ScenarioItem ScenarioItem in OC_1_Group.Children) { ScenarioItem.Scenario.CheckFilters(FiltersList, ScenarioItem); }
			foreach (ScenarioItem ScenarioItem in OC_2_Group.Children) { ScenarioItem.Scenario.CheckFilters(FiltersList, ScenarioItem); }
			foreach (ScenarioItem ScenarioItem in OC_3_Group.Children) { ScenarioItem.Scenario.CheckFilters(FiltersList, ScenarioItem); }
			foreach (ScenarioItem ScenarioItem in OC_4_Group.Children) { ScenarioItem.Scenario.CheckFilters(FiltersList, ScenarioItem); }
		}


		private void SetScenarioItemColors(ScenarioItem ScenarioItem, Color Color)
		{
			ScenarioItem.Group.BorderBrush = (Color == Colors.Transparent) ? ScenarioItem.DefaultBorderBrush : new SolidColorBrush(Color);
			ScenarioItem.Group.State = (Color == Colors.Transparent) ? GroupBoxState.Minimized : GroupBoxState.Normal;

			// ScenarioItem.Group.TitleForeground = (Color == Colors.Transparent) ? new SolidColorBrush(Colors.Black) : ScenarioItem.Group.BorderBrush;
		}
		private void CheckEdit_StatusChanged(object sender, RoutedEventArgs e) { CheckEdit_StatusChanged(); }
		Thickness _0Thickness = new Thickness(0);
		Thickness _3Thickness = new Thickness(3);
		internal void RefreshColors(ChartsPage ChartsPage)
		{
			Color Color = Colors.Transparent;
			foreach (ScenarioItem ScenarioItem in OC_1_Group.Children) { SetScenarioItemColors(ScenarioItem, ChartsPage.GetSeriesColor(ScenarioItem.Scenario.Folder)); }
			foreach (ScenarioItem ScenarioItem in OC_2_Group.Children) { SetScenarioItemColors(ScenarioItem, ChartsPage.GetSeriesColor(ScenarioItem.Scenario.Folder)); }
			foreach (ScenarioItem ScenarioItem in OC_3_Group.Children) { SetScenarioItemColors(ScenarioItem, ChartsPage.GetSeriesColor(ScenarioItem.Scenario.Folder)); }
			foreach (ScenarioItem ScenarioItem in OC_4_Group.Children) { SetScenarioItemColors(ScenarioItem, ChartsPage.GetSeriesColor(ScenarioItem.Scenario.Folder)); }


		}
	}
}
