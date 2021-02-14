using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitFileAnalyzer.Model;

namespace FitFileAnalyzer.Util
{
    public static class DatapointUtil
    {
        /// <summary>
        /// Given a list of DatapointModels this method will use the datapoints to create an Activity
        /// </summary>
        /// <param name="dplist"></param>
        /// <returns>ActivityModel</returns>
        public static ActivityModel CreateActivity(string date, List<DatapointModel> dplist)
        {
            var dist = CalculateDistance(dplist);
            var time = TotalActivityTime(dplist);
            var avgHr = AverageHeartRate(dplist);

            return new ActivityModel(date, dist, time, avgHr);
        }

        /// <summary>
        /// Returns the total distance in miles
        /// </summary>
        /// <param name="dplist"></param>
        /// <returns>decimal holding the distance in miles</returns>
        public static decimal CalculateDistance(List<DatapointModel> dplist)
        {
            var totalDistance = dplist[dplist.Count - 1].Distance;
            var miles = totalDistance * (decimal)0.00062137;
            return miles;
        }

        public static TimeSpan TotalActivityTime(List<DatapointModel> dplist)
        {
            double elapsedTime = dplist[dplist.Count - 1].Timestamp - dplist[0].Timestamp;
            TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
            return time;
        }

        public static int AverageHeartRate(List<DatapointModel> dplist)
        {
            var sum = 0;
            foreach (var dp in dplist)
            {
                sum += dp.HeartRate;
            }

            return sum / dplist.Count;
        }

    }
}
