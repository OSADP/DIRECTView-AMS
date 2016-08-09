using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class CoverageExtentVariation
    {
        public bool CoverageExtentVariation_02_Miles { get; set; }
        public bool CoverageExtentVariation_03_Miles { get; set; }
        public bool CoverageExtentVariation_04_Miles { get; set; }

        public CoverageExtentVariation(bool _02_Miles = false, bool _03_Miles = true, bool _04_Miles = false)
        {
            this.CoverageExtentVariation_02_Miles = _02_Miles;
            this.CoverageExtentVariation_03_Miles = _03_Miles;
            this.CoverageExtentVariation_04_Miles = _04_Miles;
        }
        public String Value { get { return (CoverageExtentVariation_02_Miles ? "2 Miles" : CoverageExtentVariation_03_Miles ? "3 Miles" : "4 Miles"); } set { } }
        public override String ToString() { return Value; }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {
            bool CoverageExtentVariation_02_Miles_Filter = Filters["CoverageExtentVariation_02_Miles"].IsChecked == true; CoverageExtentVariation_02_Miles_Filter = CoverageExtentVariation_02_Miles_Filter && CoverageExtentVariation_02_Miles;
            bool CoverageExtentVariation_03_Miles_Filter = Filters["CoverageExtentVariation_03_Miles"].IsChecked == true; CoverageExtentVariation_03_Miles_Filter = CoverageExtentVariation_03_Miles_Filter && CoverageExtentVariation_03_Miles;
            bool CoverageExtentVariation_04_Miles_Filter = Filters["CoverageExtentVariation_04_Miles"].IsChecked == true; CoverageExtentVariation_04_Miles_Filter = CoverageExtentVariation_04_Miles_Filter && CoverageExtentVariation_04_Miles;

            ScenarioItem.Visibility = (CoverageExtentVariation_02_Miles_Filter || CoverageExtentVariation_03_Miles_Filter || CoverageExtentVariation_04_Miles_Filter) ? Visibility.Visible : Visibility.Collapsed;

            //if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }

            //CoverageExtentVariation_02_Miles_Filter = Filters["CoverageExtentVariation_02_Miles"].IsChecked == false; CoverageExtentVariation_02_Miles_Filter = CoverageExtentVariation_02_Miles_Filter ^ CoverageExtentVariation_02_Miles;
            //CoverageExtentVariation_03_Miles_Filter = Filters["CoverageExtentVariation_03_Miles"].IsChecked == false; CoverageExtentVariation_03_Miles_Filter = CoverageExtentVariation_03_Miles_Filter ^ CoverageExtentVariation_03_Miles;
            //CoverageExtentVariation_04_Miles_Filter = Filters["CoverageExtentVariation_04_Miles"].IsChecked == false; CoverageExtentVariation_04_Miles_Filter = CoverageExtentVariation_04_Miles_Filter ^ CoverageExtentVariation_04_Miles;

            //ScenarioItem.Visibility = (CoverageExtentVariation_02_Miles_Filter && CoverageExtentVariation_03_Miles_Filter && CoverageExtentVariation_04_Miles_Filter) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
