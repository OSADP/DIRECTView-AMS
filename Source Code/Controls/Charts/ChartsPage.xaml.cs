using System;
using System.Windows.Controls;
using DevExpress.Xpf.NavBar;
using DIRECTView.Information;
using System.Windows.Media;
using DevExpress.Charts.Model;
using DevExpress.Xpf.Charts;
using System.Windows.Data;

namespace DIRECTView.Controls.Charts
{
    /// <summary>
    /// Interaction logic for ChartsPage.xaml
    /// </summary>
    public partial class ChartsPage : UserControl
    {
        public Data Data = null;
        public MainWindow MainWindow = null;
        public Chart CurrentChart { get; set; }

        public ChartsPage()
        {
            InitializeComponent();


            RowStyleConverter RowStyleConverter = (RowStyleConverter)Resources["RowStyleConverter"];
            RowStyleConverter.ChartsPage = this;
            this.TravelTime__EntireSystem_Chart.YAxisTitle.Content = "Percentage Saving in Total Travel Time";
            this.TravelTime__US75Northbound_Chart.YAxisTitle.Content = "Percentage Saving in Total Travel Time";
            this.TravelTime__US75Southbound_Chart.YAxisTitle.Content = "Percentage Saving in Total Travel Time";

            //this.TravelTime__EntireSystem__Chart.XYDiagram2D.Series.Add(this.TravelTime__EntireSystem__Chart.DoNothingLineSeries);
            //this.TravelTime__US75Northbound__Chart.XYDiagram2D.Series.Add(this.TravelTime__US75Northbound__Chart.DoNothingLineSeries);
            //this.TravelTime__US75Southbound__Chart.XYDiagram2D.Series.Add(this.TravelTime__US75Southbound__Chart.DoNothingLineSeries);


            this.TravelTime__EntireSystem_Chart.Format = "{0:P2}";
            this.TravelTime__US75Northbound_Chart.Format = "{0:P2}";
            this.TravelTime__US75Southbound_Chart.Format = "{0:P2}";

            this.TravelTime__EntireSystem_Chart.YAxisLabel.TextPattern = "{V:0.00%}";
            this.TravelTime__US75Northbound_Chart.YAxisLabel.TextPattern = "{V:0.00%}";
            this.TravelTime__US75Southbound_Chart.YAxisLabel.TextPattern = "{V:0.00%}";


            (TravelTime__EntireSystem_Chart.Diagram as XYDiagram2D).SecondaryAxesY[0].Visible = true;
            (TravelTime__US75Northbound_Chart.Diagram as XYDiagram2D).SecondaryAxesY[0].Visible = true;
            (TravelTime__US75Southbound_Chart.Diagram as XYDiagram2D).SecondaryAxesY[0].Visible = true;


            this.FuelConsumption_Chart.YAxisTitle.Content = "Saving in Fuel Consumption (Gallons)";
            this.CarbonDioxide_Chart.YAxisTitle.Content = "Saving Carbon Dioxide Emissions (Grams)";
            this.NitrogenOxide_Chart.YAxisTitle.Content = "Saving inNitrogen Oxide Emissions (Grams)";




            CurrentChart = TravelTime__EntireSystem_Chart;



        }
        public void RefreshViews_Click(object sender, EventArgs e)
        {

            DateTime StartUpdate = DateTime.Now;

            NavBarItem NavBarItem = (NavBarItem)sender;
            if ("Deselect All Scenarios".Equals((String)NavBarItem.Content))
            {
                foreach (String Scenario in MainWindow.SelectedScenarios.Values)
                {
                    //CarbonDioxide_Chart.RefreshView(Scenario, false, Data.CarbonDioxideDataCollection[Scenario]);
                    //FuelConsumption_Chart.RefreshView(Scenario, false, Data.FuelConsumptionDataCollection[Scenario]);
                    //NitrogenOxide_Chart.RefreshView(Scenario, false, Data.CarbonDioxideDataCollection[Scenario]);
                    //TravelTime__EntireSystem__Chart.RefreshView(Scenario, false, Data.TravelTimeDataCollection["Entire System"][Scenario]);
                    //TravelTime__US75Northbound__Chart.RefreshView(Scenario, false, Data.TravelTimeDataCollection["US 75 Northbound"][Scenario]);
                    //TravelTime__US75Southbound__Chart.RefreshView(Scenario, false, Data.TravelTimeDataCollection["US 75 Southbound"][Scenario]);
                    //foreach (Chart ScreenLine_Chart in MainWindow.ScreenLine_Charts.Values)
                    //{
                    //	if (Data.ScreenLines.ContainsKey(ScreenLine_Chart.ScreenLine.ID.ToString()) && Data.ScreenLines[ScreenLine_Chart.ScreenLine.ID.ToString()].ContainsKey(Scenario))
                    //	{ ScreenLine_Chart.RefreshView(Scenario, false, Data.ScreenLines[ScreenLine_Chart.ScreenLine.ID.ToString()][Scenario]); }
                    //}

                    MainWindow.AllScenarios[Scenario].IsSelected = false;
                }
                //foreach (NavBarItem _NavBarItem in MainWindow.Filters.OC_1.)
                //{
                //    _NavBarItem.ImageSource = MainWindow.Filters.UnSelctedItem.ImageSource;
                //}
                MainWindow.SelectedScenarios.Clear();
                MainWindow.Filters.RefreshColors(this);
                return;
            }
            String Name = String.Format("{0}{1}", (String)((NavBarGroup)NavBarItem.Parent).Header, (String)NavBarItem.Content);
            bool IsChecked = (MainWindow.SelectedScenarios.ContainsKey(Name)) ? false : true;
            if (MainWindow.SelectedScenarios.ContainsKey(Name)) { MainWindow.SelectedScenarios.Remove(Name); } else { MainWindow.SelectedScenarios.Add(Name, Name); }

            //NavBarItem.ImageSource = (IsChecked) ? MainWindow.Filters.SelctedItem.ImageSource : MainWindow.Filters.UnSelctedItem.ImageSource;

            //CarbonDioxide_Chart.RefreshView(Name, IsChecked, Data.CarbonDioxideDataCollection[Name]);
            //FuelConsumption_Chart.RefreshView(Name, IsChecked, Data.FuelConsumptionDataCollection[Name]);
            //NitrogenOxide_Chart.RefreshView(Name, IsChecked, Data.CarbonDioxideDataCollection[Name]);
            //TravelTime__EntireSystem__Chart.RefreshView(Name, IsChecked, Data.TravelTimeDataCollection["Entire System"][Name]);
            //TravelTime__US75Northbound__Chart.RefreshView(Name, IsChecked, Data.TravelTimeDataCollection["US 75 Northbound"][Name]);
            //TravelTime__US75Southbound__Chart.RefreshView(Name, IsChecked, Data.TravelTimeDataCollection["US 75 Southbound"][Name]);
            //foreach (Chart ScreenLine_Chart in MainWindow.ScreenLine_Charts.Values)
            //{
            //	if (Data.ScreenLines.ContainsKey(ScreenLine_Chart.ScreenLine.ID.ToString()) && Data.ScreenLines[ScreenLine_Chart.ScreenLine.ID.ToString()].ContainsKey(Name))
            //	{ ScreenLine_Chart.RefreshView(Name, IsChecked, Data.ScreenLines[ScreenLine_Chart.ScreenLine.ID.ToString()][Name]); }
            //}

            DateTime EndUpdate = DateTime.Now;
            TimeSpan RefreshTime = EndUpdate - StartUpdate;
            Console.WriteLine("=================================================================================");
            Console.WriteLine(String.Format("Execution Time To Update All Charts = {0}", RefreshTime.ToString()));
            Console.WriteLine("=================================================================================");
        }
        public Color GetSeriesColor(String SeriesName)
        {
            DevExpress.Xpf.Charts.Palette Palette = CarbonDioxide_Chart.Palette;
            if (CurrentChart.ChartSeries.ContainsKey(SeriesName) && CurrentChart.ChartSeries[SeriesName].Visible == true)
            {
                int summaryFindRowByValue = Summary.FindRowByValue("Name", SeriesName);
                int SeriesIndex = Convert.ToInt16(summaryFindRowByValue);
                Color SeriesColor = Palette[SeriesIndex];
                return SeriesColor;
            }
            return Colors.Transparent;
        }
        internal void RefreshViews(Scenario Scenario, bool IsChecked)
        {
            //DateTime StartUpdate = DateTime.Now;
            CarbonDioxide_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.FuelConsumption);
            FuelConsumption_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.FuelConsumption);
            NitrogenOxide_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.NitrogenOxide);
            TravelTime__EntireSystem_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.TravelTime_EntireSystem);
            TravelTime__US75Northbound_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.TravelTime_US75_NB);
            TravelTime__US75Southbound_Chart.RefreshView(Scenario.Folder, IsChecked, Scenario.TravelTime_US75_SB);

            if (IsChecked)
            {
                Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems++;
                Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems = (Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems < 0) ? 0 : Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems;
            }
            else
            {
                Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems--;
                if (Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems < 0)
                {
                    Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems = 0;
                }
            }
            if (Data.OperationalConditionsList[Scenario.OperationalConditions].VisibleItems == 0)
            {
                TravelTime__EntireSystem_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = false;
                TravelTime__US75Northbound_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = false;
                TravelTime__US75Southbound_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = false;
            }
            else
            {
                TravelTime__EntireSystem_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = true;
                TravelTime__US75Northbound_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = true;
                TravelTime__US75Southbound_Chart.DoNothingLineSeries[Scenario.OperationalConditions].Visible = true;
            }

                foreach (Chart ScreenLine_Chart in MainWindow.ScreenLine_Charts.Values)
            {
                // if (Data.ScreenLines.ContainsKey(ScreenLine_Chart.ScreenLine.ID.ToString()) && Data.ScreenLines[ScreenLine_Chart.ScreenLine.ID.ToString()].ContainsKey(Scenario.Folder))
                ScreenLine ScreenLine = Scenario.ScreenLines[String.Format("_{0}",ScreenLine_Chart.ScreenLine.ID)];
                { ScreenLine_Chart.RefreshView(Scenario.Folder, IsChecked, ScreenLine); }
            }
            Summary.ItemsSource = CurrentChart.SummaryTable;
            Summary.RefreshData();
            Summary.Columns[0].Width = 700;
            Summary.Columns[1].Width = 200;
            if (CurrentChart.ScreenLine == null) { Summary.Columns[2].Width = 200; }

            //DateTime EndUpdate = DateTime.Now;
            //TimeSpan RefreshTime = EndUpdate - StartUpdate;
            //Console.WriteLine("=================================================================================");
            //Console.WriteLine(String.Format("Execution Time To Update All Charts = {0}", RefreshTime.ToString()));
            //Console.WriteLine("=================================================================================");

        }
    }
    public class RowStyleConverter : IValueConverter
    {
        public ChartsPage ChartsPage = null;
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            Color Color = (ChartsPage != null) ? ChartsPage.GetSeriesColor(value.ToString()) : Colors.White;

            return new SolidColorBrush(Color);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

}
