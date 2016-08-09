using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class DemandPredictionAccurcy
    {
        public bool ErrorInDemandPrediction_Negative_10_Percent { get; set; }
        public bool ErrorInDemandPrediction_Negative_05_Percent { get; set; }
        public bool ErrorInDemandPrediction__________00_Percent { get; set; }
        public bool ErrorInDemandPrediction_Positive_05_Percent { get; set; }
        public bool ErrorInDemandPrediction_Positive_10_Percent { get; set; }

        public DemandPredictionAccurcy(bool ErrorInDemandPrediction_Negative_10_Percent = false, bool ErrorInDemandPrediction_Negative_05_Percent = false, bool ErrorInDemandPrediction__________00_Percent = true, bool ErrorInDemandPrediction_Positive_05_Percent = false, bool ErrorInDemandPrediction_Positive_10_Percent = false)
        {
            this.ErrorInDemandPrediction_Negative_10_Percent = ErrorInDemandPrediction_Negative_10_Percent;
            this.ErrorInDemandPrediction_Negative_05_Percent = ErrorInDemandPrediction_Negative_05_Percent;
            this.ErrorInDemandPrediction__________00_Percent = ErrorInDemandPrediction__________00_Percent;
            this.ErrorInDemandPrediction_Positive_05_Percent = ErrorInDemandPrediction_Positive_05_Percent;
            this.ErrorInDemandPrediction_Positive_10_Percent = ErrorInDemandPrediction_Positive_10_Percent;
        }
        public String Value { get { return (ErrorInDemandPrediction_Negative_10_Percent ? "-10 %" : ErrorInDemandPrediction_Negative_05_Percent ? "-05 %" : ErrorInDemandPrediction_Positive_05_Percent ? "05 %" : ErrorInDemandPrediction_Positive_10_Percent ? "10 %" : "00 %"); } set { } }
        public override String ToString() { return Value; }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {
            bool ErrorInDemandPrediction_Negative_10_Percent_Filter = Filters["ErrorInDemandPrediction_Negative_10_Percent"].IsChecked == true; ErrorInDemandPrediction_Negative_10_Percent_Filter = ErrorInDemandPrediction_Negative_10_Percent_Filter && ErrorInDemandPrediction_Negative_10_Percent;
            bool ErrorInDemandPrediction_Negative_05_Percent_Filter = Filters["ErrorInDemandPrediction_Negative_05_Percent"].IsChecked == true; ErrorInDemandPrediction_Negative_05_Percent_Filter = ErrorInDemandPrediction_Negative_05_Percent_Filter && ErrorInDemandPrediction_Negative_05_Percent;
            bool ErrorInDemandPrediction__________00_Percent_Filter = Filters["ErrorInDemandPrediction__________00_Percent"].IsChecked == true; ErrorInDemandPrediction__________00_Percent_Filter = ErrorInDemandPrediction__________00_Percent_Filter && ErrorInDemandPrediction__________00_Percent;
            bool ErrorInDemandPrediction_Positive_05_Percent_Filter = Filters["ErrorInDemandPrediction_Positive_05_Percent"].IsChecked == true; ErrorInDemandPrediction_Positive_05_Percent_Filter = ErrorInDemandPrediction_Positive_05_Percent_Filter && ErrorInDemandPrediction_Positive_05_Percent;
            bool ErrorInDemandPrediction_Positive_10_Percent_Filter = Filters["ErrorInDemandPrediction_Positive_10_Percent"].IsChecked == true; ErrorInDemandPrediction_Positive_10_Percent_Filter = ErrorInDemandPrediction_Positive_10_Percent_Filter && ErrorInDemandPrediction_Positive_10_Percent;

            ScenarioItem.Visibility = (ErrorInDemandPrediction_Negative_10_Percent_Filter || ErrorInDemandPrediction_Negative_05_Percent_Filter || ErrorInDemandPrediction__________00_Percent_Filter || ErrorInDemandPrediction_Positive_05_Percent_Filter || ErrorInDemandPrediction_Positive_10_Percent_Filter) ? Visibility.Visible : Visibility.Collapsed;

            //if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }

            // ErrorInDemandPrediction_Negative_10_Percent_Filter = Filters["ErrorInDemandPrediction_Negative_10_Percent"].IsChecked == false; ErrorInDemandPrediction_Negative_10_Percent_Filter = ErrorInDemandPrediction_Negative_10_Percent_Filter ^ ErrorInDemandPrediction_Negative_10_Percent;
            // ErrorInDemandPrediction_Negative_05_Percent_Filter = Filters["ErrorInDemandPrediction_Negative_05_Percent"].IsChecked == false; ErrorInDemandPrediction_Negative_05_Percent_Filter = ErrorInDemandPrediction_Negative_05_Percent_Filter ^ ErrorInDemandPrediction_Negative_05_Percent;
            // ErrorInDemandPrediction__________00_Percent_Filter = Filters["ErrorInDemandPrediction__________00_Percent"].IsChecked == false; ErrorInDemandPrediction__________00_Percent_Filter = ErrorInDemandPrediction__________00_Percent_Filter ^ ErrorInDemandPrediction__________00_Percent;
            // ErrorInDemandPrediction_Positive_05_Percent_Filter = Filters["ErrorInDemandPrediction_Positive_05_Percent"].IsChecked == false; ErrorInDemandPrediction_Positive_05_Percent_Filter = ErrorInDemandPrediction_Positive_05_Percent_Filter ^ ErrorInDemandPrediction_Positive_05_Percent;
            // ErrorInDemandPrediction_Positive_10_Percent_Filter = Filters["ErrorInDemandPrediction_Positive_10_Percent"].IsChecked == false; ErrorInDemandPrediction_Positive_10_Percent_Filter = ErrorInDemandPrediction_Positive_10_Percent_Filter ^ ErrorInDemandPrediction_Positive_10_Percent;

            //ScenarioItem.Visibility = (ErrorInDemandPrediction_Negative_10_Percent_Filter && ErrorInDemandPrediction_Negative_05_Percent_Filter && ErrorInDemandPrediction__________00_Percent_Filter && ErrorInDemandPrediction_Positive_05_Percent_Filter && ErrorInDemandPrediction_Positive_10_Percent_Filter) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
