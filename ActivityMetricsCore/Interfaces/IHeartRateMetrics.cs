using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IHeartRateMetrics
    {
        List<int> HeartRateTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        List<int> HeartRateTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);
    }
}
