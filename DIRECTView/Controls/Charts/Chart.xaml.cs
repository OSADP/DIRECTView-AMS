using DevExpress.Xpf.Charts;
using DIRECTView.Information;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Media;

namespace DIRECTView.Controls.Charts
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : ChartControl
    {
        public SortedList<String, BarSideBySideSeries2D> ChartSeries = new SortedList<string, BarSideBySideSeries2D>();
        public SortedList<String, LineSeries2D> DoNothingLineSeries = new SortedList<String, LineSeries2D>();
        public DataTable SummaryTable = new DataTable();
        public ScreenLine ScreenLine { get; set; }
        public String Format { get; set; }
        public object SecondaryAxesY = null;
        public Chart()
        {
            ScreenLine = null;
            SummaryTable.Columns.Add("Name", typeof(String));
            SummaryTable.Columns.Add("Maximum", typeof(String));
            SummaryTable.Columns.Add("Average", typeof(String));
            SummaryTable.DefaultView.Sort = "Name ASC";

            Format = "{0:#,0}";
            InitializeComponent();

            YAxisLabel.TextPattern = "{V:#,#}";
            SecondaryAxesY = (Diagram as XYDiagram2D).SecondaryAxesY[0];
            (Diagram as XYDiagram2D).SecondaryAxesY[0].Visible = false;
        }

        public void SetData(Data Data, TimeSpan Begin, TimeSpan End)
        {
            DataTable DataTable = new DataTable();
            DataTable.Columns.Add("Name", typeof(String));
            DataTable.Columns.Add("Time", typeof(TimeSpan));
            DataTable.Columns.Add("Car", typeof(double));
            DataTable.DefaultView.Sort = "Name ASC";

            SortedList<String, DataTable> DoNothingDataTables = new SortedList<string, DataTable>();



            foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
            {
                DataTable DoNothingDataTable = new DataTable();
                DoNothingDataTable.Columns.Add("Time", typeof(TimeSpan));
                DoNothingDataTable.Columns.Add("Car", typeof(double));
                foreach (Scenario Scenario in OperationalConditions.Scenarios)
                {
                    if (Scenario == OperationalConditions.DoNothingScenario)
                    {
                        DataSeries DoNothingDataSeries = OperationalConditions.DoNothingScenario.DataSeries[this.Name.Replace("_Chart", "")];

                        foreach (DataItem DataItem in DoNothingDataSeries.Values)
                        {
                            TimeSpan Time = TimeSpan.Parse(DataItem.Time);
                            if (Time < Begin || Time > End) { continue; }
                            DoNothingDataTable.Rows.Add(new object[] { DataItem.Time, DataItem.Car });
                        }
                        continue;
                    }
                    DataSeries DataSeries = Scenario.DataSeries[this.Name.Replace("_Chart", "")];
                    foreach (DataItem DataItem in DataSeries.Values)
                    {
                        TimeSpan Time = TimeSpan.Parse(DataItem.Time);
                        if (Time < Begin || Time > End) { continue; }
                        DataTable.Rows.Add(new object[] { Scenario.Folder, DataItem.Time, DataItem.Car });
                    }
                }
                DoNothingDataTables.Add(OperationalConditions.ID, DoNothingDataTable);
            }
            DataSource = DataTable;

            foreach (OperationalConditions OperationalConditions in Data.OperationalConditionsList.Values)
            {
                LineSeries2D LineSeries2D = new LineSeries2D() { DisplayName = OperationalConditions.ID };

                DoNothingLineSeries.Add(OperationalConditions.ID, LineSeries2D);
                Diagram.Series.Add(LineSeries2D);
                SecondaryAxisY2D YSecondaryAxis = ((XYDiagram2D)Diagram).SecondaryAxesY[0];
                XYDiagram2D.SetSeriesAxisY(LineSeries2D, YSecondaryAxis);
                LineSeries2D.DataSource = DoNothingDataTables[OperationalConditions.ID];
                LineSeries2D.LineStyle = new LineStyle();
                LineSeries2D.LineStyle.Thickness = 5;
                // LineSeries2D.Brush = new SolidColorBrush(Colors.DarkRed);

                LineSeries2D.ArgumentDataMember = "Time";
                LineSeries2D.ValueDataMember = "Car";

            }

            BeginInit();


            BarSideBySideSeries2D SeriesTemplate = new BarSideBySideSeries2D();
            XYDiagram2D.SeriesTemplate = SeriesTemplate;
            SeriesTemplate.ArgumentDataMember = "Time";
            SeriesTemplate.ValueDataMember = "Car";
            EndInit();


            foreach (Series Series in XYDiagram2D.Series)
            {
                if (Series is BarSideBySideSeries2D)
                {
                    BarSideBySideSeries2D BarSideBySideSeries2D = (BarSideBySideSeries2D)Series;
                    BarSideBySideSeries2D.Visible = false;
                    ChartSeries.Add(BarSideBySideSeries2D.DisplayName, BarSideBySideSeries2D);
                }
            }

            foreach (LineSeries2D LineSeries2D in DoNothingLineSeries.Values)
            {
                LineSeries2D.Visible = false;
            }
        }

        public void RefreshView(string Name, bool Visibility, DataSeries DataSeries)
        {
            //DateTime StartUpdate = DateTime.Now;
            this.BeginInit();

            if (ChartSeries.ContainsKey(Name))
            {
                ChartSeries[Name].Visible = Visibility;
                if (ChartSeries[Name].Visible)
                {
                    if (ScreenLine == null)
                    {
                        String Maximum = String.Format(Format, DataSeries.Maximum);
                        String Average = String.Format(Format, DataSeries.Average);
                        SummaryTable.Rows.Add(new object[] { Name, Maximum, Average });
                    }
                    else
                    {
                        String Total = String.Format(Format, ((ScreenLine)DataSeries).Total);
                        SummaryTable.Rows.Add(new object[] { Name, Total });
                    }
                }
                else { foreach (DataRow DataRow in SummaryTable.Rows) { if (DataRow["Name"].ToString().Equals(Name)) { DataRow.Delete(); break; } } }

            }
            SummaryTable.DefaultView.Sort = "Name";
            this.EndInit();
            //DateTime EndUpdate = DateTime.Now;
            //TimeSpan RefreshTime = EndUpdate - StartUpdate;
            //Console.WriteLine(String.Format("Chart [{0}]: Updating Time = {1}", this.Name, RefreshTime.ToString()));

        }

    }
}
