using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IHeartRateMetrics
    {
        void HeartRateTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        void HeartRateTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);
    }
}
