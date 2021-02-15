using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IDistanceMetrics
    {
        List<decimal> DistanceTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        void DistanceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);
        void GetLikeActivitesByDistance(List<ActivityModel> list, decimal fastPace, decimal slowPace, SortOption option = SortOption.Week);
    }
}
