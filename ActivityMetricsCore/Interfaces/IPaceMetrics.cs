using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IPaceMetrics
    {
        void PaceTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        void PaceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);
        void GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan fastPace, TimeSpan slowPace, SortOption option = SortOption.Week);
    }
}
