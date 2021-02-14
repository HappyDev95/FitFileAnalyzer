using System;
using System.Collections.Generic;
using System.Text;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IDistanceMetrics
    {
        void DistanceTrend(List<ActivityModel> list);
        void DistanceTrend(List<ActivityModel> list, string startDate, string endDate);
        void GetLikeActivitesByDistance(List<ActivityModel> list, decimal fastPace, decimal slowPace);
    }
}
