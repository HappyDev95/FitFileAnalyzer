using System;
using System.Collections.Generic;
using System.Text;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IHeartRateMetrics
    {
        void HeartRateTrend(List<ActivityModel> list);
        void HeartRateTrend(List<ActivityModel> list, string startDate, string endDate);
    }
}
