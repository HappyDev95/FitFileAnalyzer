using System;
using System.Collections.Generic;
using System.Text;
using ActivityMetricsCore.Interfaces;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore
{
    class MetricsProcessor : IPaceMetrics, IDistanceMetrics, IHeartRateMetrics
    {
        public void DistanceTrend(List<ActivityModel> list)
        {
            throw new NotImplementedException();
        }

        public void DistanceTrend(List<ActivityModel> list, string startDate, string endDate)
        {
            throw new NotImplementedException();
        }

        public void GetLikeActivitesByDistance(List<ActivityModel> list, decimal fastPace, decimal slowPace)
        {
            throw new NotImplementedException();
        }

        public void GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan fastPace, TimeSpan slowPace)
        {
            throw new NotImplementedException();
        }

        public void HeartRateTrend(List<ActivityModel> list)
        {
            throw new NotImplementedException();
        }

        public void HeartRateTrend(List<ActivityModel> list, string startDate, string endDate)
        {
            throw new NotImplementedException();
        }

        public void PaceTrend(List<ActivityModel> list)
        {
            throw new NotImplementedException();
        }

        public void PaceTrend(List<ActivityModel> list, string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}
