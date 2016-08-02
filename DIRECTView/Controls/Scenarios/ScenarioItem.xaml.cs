using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.LayoutControl;
using DIRECTView.Information;
using System;
using System.Collections.Generic;
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

namespace DIRECTView.Controls.Scenarios
{
    /// <summary>
    /// Interaction logic for ScenarioItem.xaml
    /// </summary>
    public partial class ScenarioItem : UserControl
    {
        public Scenario Scenario { get; set; }
        public MainWindow MainWindow { get; set; }
        public Brush DefaultBorderBrush { get; set; }
        private bool IsChecked { get; set; }
        public bool IsSelected { get; set; }
        public ScenarioItem()
        {
            IsSelected = false;
            InitializeComponent();
            DefaultBorderBrush = Group.BorderBrush;
            GroupBoxButton GroupBoxButton = (GroupBoxButton)Group.Template.FindName("MaximizeElement", Group);
            GroupBoxButton.Click += MaximizeElement_Click;
        }
        public ScenarioItem(Scenario Scenario, MainWindow MainWindow)
        {
            this.Scenario = Scenario;
            this.MainWindow = MainWindow;
            InitializeComponent();
            this.Group.Header = String.Format("Scenario {0}", Scenario.ID);
            this.ATDMStrategies.Text = String.Empty;
            this.ATDMStrategies.Text = String.Format("{0}{1}", this.ATDMStrategies.Text, Scenario.ATDMStrategies.DynamicShoulderLanes ? "Dynamic Shoulder Lanes," : "");
            this.ATDMStrategies.Text = String.Format("{0}{1}", this.ATDMStrategies.Text, Scenario.ATDMStrategies.AdaptiveRampMetering ? " Adaptive Ramp Metering," : "");
            this.ATDMStrategies.Text = String.Format("{0}{1}", this.ATDMStrategies.Text, Scenario.ATDMStrategies.DynamicSignalTiming ? " Dynamic Signal Timing," : "");
            this.ATDMStrategies.Text = String.Format("{0}{1}", this.ATDMStrategies.Text, Scenario.ATDMStrategies.DynamicRouting ? " Dynamic Routing," : "");
            this.ATDMStrategies.Text = String.Format("{0}{1}", this.ATDMStrategies.Text, Scenario.ATDMStrategies.DynamicallyPricedParking ? " Dynamic Parking Pricing" : "");
            this.ATDMStrategies.Text = this.ATDMStrategies.Text.Trim();
            if (this.ATDMStrategies.Text.EndsWith(",")) { this.ATDMStrategies.Text = this.ATDMStrategies.Text.Substring(0, this.ATDMStrategies.Text.Length - 1); }
            this.DemandPredictionAccurcy.Content = Scenario.AssesmentAttributes.DemandPredictionAccurcy.Value;
            this.TrafficManagementLatency.Content = Scenario.AssesmentAttributes.TrafficManagementLatency.Value;
            this.CoverageExtentVariation.Content = Scenario.AssesmentAttributes.CoverageExtentVariation.Value;
            this.PredictionHorizon.Content = Scenario.AssesmentAttributes.PredictionHorizon.Value;
            Group.SetValue(DevExpress.Xpf.LayoutControl.GroupBox.ToolTipProperty, Scenario.Folder);
            this.ClusterDescription.Text = String.Format("{0}: {1}", Scenario.OperationalConditions.ToString().Replace("_","-"),  MainWindow.Data.OperationalConditionsList[Scenario.OperationalConditions].Description);
            ;
        }
        private void MaximizeElement_Click(object sender, RoutedEventArgs e)
        {
            IsChecked = (IsChecked) ? false : true;
            MainWindow.ChartsPage.RefreshViews(Scenario, IsChecked);
            MainWindow.Filters.RefreshColors(MainWindow.ChartsPage);
            Group.State = (IsChecked) ? GroupBoxState.Normal : GroupBoxState.Minimized;
            if (IsChecked) { IsSelected = true; MainWindow.SelectedScenarios.Add(Scenario.Folder, Scenario.Folder); }
            else { IsSelected = false; MainWindow.SelectedScenarios.Remove(Scenario.Folder); MainWindow.Filters.CheckEdit_StatusChanged(); }
        }
    }
}
