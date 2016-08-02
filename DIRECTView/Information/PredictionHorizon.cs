using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class PredictionHorizon
    {
        public bool PredictionHorizon_15_Minutes { get; set; }
        public bool PredictionHorizon_30_Minutes { get; set; }
        public bool PredictionHorizon_60_Minutes { get; set; }

        public PredictionHorizon(bool _15_Minutes = false, bool _30_Minutes = true, bool _60_Minutes = false)
        {
            this.PredictionHorizon_15_Minutes = _15_Minutes;
            this.PredictionHorizon_30_Minutes = _30_Minutes;
            this.PredictionHorizon_60_Minutes = _60_Minutes;
        }
        public String Value { get { return (PredictionHorizon_15_Minutes ? "15 Minutes" : PredictionHorizon_30_Minutes ? "30 Minutes" : "60 Minutes"); } set { } }
        public override String ToString() { return Value; }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {
            bool PredictionHorizon_15_Minutes_Filter = Filters["PredictionHorizon_15_Minutes"].IsChecked == true; PredictionHorizon_15_Minutes_Filter = PredictionHorizon_15_Minutes_Filter && PredictionHorizon_15_Minutes;
            bool PredictionHorizon_30_Minutes_Filter = Filters["PredictionHorizon_30_Minutes"].IsChecked == true; PredictionHorizon_30_Minutes_Filter = PredictionHorizon_30_Minutes_Filter && PredictionHorizon_30_Minutes;
            bool PredictionHorizon_60_Minutes_Filter = Filters["PredictionHorizon_60_Minutes"].IsChecked == true; PredictionHorizon_60_Minutes_Filter = PredictionHorizon_60_Minutes_Filter && PredictionHorizon_60_Minutes;

            ScenarioItem.Visibility = (PredictionHorizon_15_Minutes_Filter || PredictionHorizon_30_Minutes_Filter || PredictionHorizon_60_Minutes_Filter) ? Visibility.Visible : Visibility.Collapsed;

            //if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }

            //PredictionHorizon_15_Minutes_Filter = Filters["PredictionHorizon_15_Minutes"].IsChecked == false; PredictionHorizon_15_Minutes_Filter = PredictionHorizon_15_Minutes_Filter ^ PredictionHorizon_15_Minutes;
            //PredictionHorizon_30_Minutes_Filter = Filters["PredictionHorizon_30_Minutes"].IsChecked == false; PredictionHorizon_30_Minutes_Filter = PredictionHorizon_30_Minutes_Filter ^ PredictionHorizon_30_Minutes;
            //PredictionHorizon_60_Minutes_Filter = Filters["PredictionHorizon_60_Minutes"].IsChecked == false; PredictionHorizon_60_Minutes_Filter = PredictionHorizon_60_Minutes_Filter ^ PredictionHorizon_60_Minutes;

            //ScenarioItem.Visibility = (PredictionHorizon_15_Minutes_Filter && PredictionHorizon_30_Minutes_Filter && PredictionHorizon_60_Minutes_Filter) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
