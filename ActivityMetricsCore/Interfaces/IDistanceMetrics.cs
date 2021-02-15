using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IDistanceMetrics
    {
        List<decimal> DistanceTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        List<decimal> DistanceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);
        List<decimal> GetLikeActivitesByDistance(List<ActivityModel> list, decimal minDistance, decimal maxDistance);
    }
}
