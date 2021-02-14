using System;
using System.Collections.Generic;
using System.Text;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IPaceMetrics
    {
        void PaceTrend(List<ActivityModel> list);
        void PaceTrend(List<ActivityModel> list, string startDate, string endDate);
        void GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan fastPace, TimeSpan slowPace);
    }
}
