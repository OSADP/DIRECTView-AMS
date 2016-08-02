using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class ATDMStrategies
    {
        public bool DynamicShoulderLanes { get; set; }
        public bool AdaptiveRampMetering { get; set; }
        public bool DynamicSignalTiming { get; set; }
        public bool DynamicRouting { get; set; }
        public bool DynamicallyPricedParking { get; set; }

        public ATDMStrategies(bool DynamicShoulderLanes = false, bool AdaptiveRampMetering = false, bool DynamicSignalTiming = false, bool DynamicRouting = false, bool DynamicallyPricedParking = false)
        {
            this.DynamicShoulderLanes = DynamicShoulderLanes;
            this.AdaptiveRampMetering = AdaptiveRampMetering;
            this.DynamicSignalTiming = DynamicSignalTiming;
            this.DynamicRouting = DynamicRouting;
            this.DynamicallyPricedParking = DynamicallyPricedParking;
        }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {

            bool DynamicShoulderLanes_Filter = Filters["DynamicShoulderLanes"].IsChecked == true; DynamicShoulderLanes_Filter = DynamicShoulderLanes_Filter && DynamicShoulderLanes;
            bool AdaptiveRampMetering_Filter = Filters["AdaptiveRampMetering"].IsChecked == true; AdaptiveRampMetering_Filter = AdaptiveRampMetering_Filter && AdaptiveRampMetering;
            bool DynamicSignalTiming_Filter = Filters["DynamicSignalTiming"].IsChecked == true; DynamicSignalTiming_Filter = DynamicSignalTiming_Filter && DynamicSignalTiming;
            bool DynamicRouting_Filter = Filters["DynamicRouting"].IsChecked == true; DynamicRouting_Filter = DynamicRouting_Filter && DynamicRouting;
            bool DynamicallyPricedParking_Filter = Filters["DynamicallyPricedParking"].IsChecked == true; DynamicallyPricedParking_Filter = DynamicallyPricedParking_Filter && DynamicallyPricedParking;


            ScenarioItem.Visibility = (DynamicShoulderLanes_Filter || AdaptiveRampMetering_Filter || DynamicSignalTiming_Filter || DynamicRouting_Filter || DynamicallyPricedParking_Filter) ? Visibility.Visible : Visibility.Collapsed;
            if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }

            DynamicShoulderLanes_Filter = Filters["DynamicShoulderLanes"].IsChecked == false; DynamicShoulderLanes_Filter = DynamicShoulderLanes_Filter ^ DynamicShoulderLanes;
            AdaptiveRampMetering_Filter = Filters["AdaptiveRampMetering"].IsChecked == false; AdaptiveRampMetering_Filter = AdaptiveRampMetering_Filter ^ AdaptiveRampMetering;
            DynamicSignalTiming_Filter = Filters["DynamicSignalTiming"].IsChecked == false; DynamicSignalTiming_Filter = DynamicSignalTiming_Filter ^ DynamicSignalTiming;
            DynamicRouting_Filter = Filters["DynamicRouting"].IsChecked == false; DynamicRouting_Filter = DynamicRouting_Filter ^ DynamicRouting;
            DynamicallyPricedParking_Filter = Filters["DynamicallyPricedParking"].IsChecked == false; DynamicallyPricedParking_Filter = DynamicallyPricedParking_Filter ^ DynamicallyPricedParking;


            ScenarioItem.Visibility = (DynamicShoulderLanes_Filter && AdaptiveRampMetering_Filter && DynamicSignalTiming_Filter && DynamicRouting_Filter && DynamicallyPricedParking_Filter) ? Visibility.Visible : Visibility.Collapsed;

        }

    }
}
