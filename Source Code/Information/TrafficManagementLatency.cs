using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class TrafficManagementLatency
    {
        public bool TrafficManagementLatency_00_Minutes { get; set; }
        public bool TrafficManagementLatency_05_Minutes { get; set; }
        public bool TrafficManagementLatency_10_Minutes { get; set; }

        public TrafficManagementLatency(bool _00_Minutes = true, bool _05_Minutes = false, bool _10_Minutes = false)
        {
            this.TrafficManagementLatency_00_Minutes = _00_Minutes;
            this.TrafficManagementLatency_05_Minutes = _05_Minutes;
            this.TrafficManagementLatency_10_Minutes = _10_Minutes;
        }
        public String Value { get { return (TrafficManagementLatency_00_Minutes ? "00 Minutes" : TrafficManagementLatency_05_Minutes ? "05 Minutes" : "10 Minutes"); } set { } }
        public override String ToString() { return Value; }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {
            bool TrafficManagementLatency_00_Minutes_Filter = Filters["TrafficManagementLatency_00_Minutes"].IsChecked == true; TrafficManagementLatency_00_Minutes_Filter = TrafficManagementLatency_00_Minutes_Filter && TrafficManagementLatency_00_Minutes;
            bool TrafficManagementLatency_05_Minutes_Filter = Filters["TrafficManagementLatency_05_Minutes"].IsChecked == true; TrafficManagementLatency_05_Minutes_Filter = TrafficManagementLatency_05_Minutes_Filter && TrafficManagementLatency_05_Minutes;
            bool TrafficManagementLatency_10_Minutes_Filter = Filters["TrafficManagementLatency_10_Minutes"].IsChecked == true; TrafficManagementLatency_10_Minutes_Filter = TrafficManagementLatency_10_Minutes_Filter && TrafficManagementLatency_10_Minutes;

            ScenarioItem.Visibility = (TrafficManagementLatency_00_Minutes_Filter || TrafficManagementLatency_05_Minutes_Filter || TrafficManagementLatency_10_Minutes_Filter) ? Visibility.Visible : Visibility.Collapsed;

            //if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }

            //TrafficManagementLatency_00_Minutes_Filter = Filters["TrafficManagementLatency_00_Minutes"].IsChecked == false; TrafficManagementLatency_00_Minutes_Filter = TrafficManagementLatency_00_Minutes_Filter ^ TrafficManagementLatency_00_Minutes;
            //TrafficManagementLatency_05_Minutes_Filter = Filters["TrafficManagementLatency_05_Minutes"].IsChecked == false; TrafficManagementLatency_05_Minutes_Filter = TrafficManagementLatency_05_Minutes_Filter ^ TrafficManagementLatency_05_Minutes;
            //TrafficManagementLatency_10_Minutes_Filter = Filters["TrafficManagementLatency_10_Minutes"].IsChecked == false; TrafficManagementLatency_10_Minutes_Filter = TrafficManagementLatency_10_Minutes_Filter ^ TrafficManagementLatency_10_Minutes;

            //ScenarioItem.Visibility = (TrafficManagementLatency_00_Minutes_Filter && TrafficManagementLatency_05_Minutes_Filter && TrafficManagementLatency_10_Minutes_Filter ) ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}
