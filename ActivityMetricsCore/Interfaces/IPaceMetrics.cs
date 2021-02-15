using System;
using System.Collections.Generic;
using ActivityMetricsCore.Enums;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore.Interfaces
{
    interface IPaceMetrics
    {
        List<TimeSpan> PaceTrend(List<ActivityModel> list, SortOption option = SortOption.Week);
        List<TimeSpan> PaceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week);

        /// <summary>
        /// Returns a list of ActivityModel objects whose pace is are in between the minPace and maxPace.
        /// <para>The minPace is the SLOWEST pace acceptable. The maxPace is the FASTEST pace acceptable.</para>
        /// </summary>
        /// <param name="list">list of ActivityModel</param>
        /// <param name="minPace">slowest pace acceptable</param>
        /// <param name="maxPace">fastest pace acceptable</param>
        /// <returns></returns>
        List<ActivityModel> GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan minPace, TimeSpan maxPace);
    }
}
