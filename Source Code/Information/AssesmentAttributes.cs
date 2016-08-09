using DevExpress.Xpf.Editors;
using DIRECTView.Controls.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIRECTView.Information
{
    public class AssesmentAttributes
    {
        public DemandPredictionAccurcy DemandPredictionAccurcy { get; set; }
        public TrafficManagementLatency TrafficManagementLatency { get; set; }
        public PredictionHorizon PredictionHorizon { get; set; }
        public CoverageExtentVariation CoverageExtentVariation { get; set; }
        public AssesmentAttributes()
        {
            DemandPredictionAccurcy = new DemandPredictionAccurcy();
            TrafficManagementLatency = new TrafficManagementLatency();
            PredictionHorizon = new PredictionHorizon();
            CoverageExtentVariation = new CoverageExtentVariation();
        }
        public AssesmentAttributes(DemandPredictionAccurcy DemandPredictionAccurcy, TrafficManagementLatency TrafficManagementLatency, PredictionHorizon PredictionHorizon, CoverageExtentVariation CoverageExtentVariation)
        {
            this.DemandPredictionAccurcy = DemandPredictionAccurcy;
            this.TrafficManagementLatency = TrafficManagementLatency;
            this.PredictionHorizon = PredictionHorizon;
            this.CoverageExtentVariation = CoverageExtentVariation;
        }
        public void CheckFilters(SortedList<String, CheckEdit> Filters, ScenarioItem ScenarioItem)
        {

            DemandPredictionAccurcy.CheckFilters(Filters, ScenarioItem); if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }
            TrafficManagementLatency.CheckFilters(Filters, ScenarioItem); if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }
            PredictionHorizon.CheckFilters(Filters, ScenarioItem); if (ScenarioItem.Visibility == Visibility.Collapsed) { return; }
            CoverageExtentVariation.CheckFilters(Filters, ScenarioItem);
        }

    }
}
