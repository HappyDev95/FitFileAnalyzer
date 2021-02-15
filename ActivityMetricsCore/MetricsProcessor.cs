using System;
using System.Collections.Generic;
using System.Globalization;
using ActivityMetricsCore.Enums;
using ActivityMetricsCore.Interfaces;
using ActivityMetricsCore.Util;
using FitFileAnalyzer.Model;

namespace ActivityMetricsCore
{

    public class MetricsProcessor : IPaceMetrics, IDistanceMetrics, IHeartRateMetrics
    {
        public List<decimal> DistanceTrend(List<ActivityModel> list, SortOption option = SortOption.Week)
        {
            List<decimal> distanceList = new List<decimal>();

            if(option == SortOption.Week)
            {
                var cultureInfo = new CultureInfo("en-US");
                var calendar = cultureInfo.Calendar;
                var calendarRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
                var dowRule = cultureInfo.DateTimeFormat.FirstDayOfWeek;

                var week = calendar.GetWeekOfYear(DateUtil.GetDateFromString(list[0].Date), calendarRule, dowRule);
                decimal total = 0;

                foreach (var activity in list)
                {
                    //Console.WriteLine($"Date = {activity.Date}, Distance = {activity.Distance}, DayOfWeek = {DateUtil.GetDateFromString(activity.Date).ToString("dddd")}");
                    
                    var currentWeek = calendar.GetWeekOfYear(DateUtil.GetDateFromString(activity.Date), calendarRule, dowRule);
                    if (week != currentWeek)
                    {
                        distanceList.Add(total);
                        //Console.WriteLine($"Weekly Total = {total}\n");

                        total = 0;
                        week = currentWeek;
                    }
                    total += activity.Distance;
                }
            }
            return distanceList;
        }

        public void DistanceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            foreach (var activity in list)
            {
                if ((DateTime.Parse(activity.Date) >= startDate) && (DateTime.Parse(activity.Date) <= endDate))
                {
                    //TODO: stuff
                }
            }
        }

        public void GetLikeActivitesByDistance(List<ActivityModel> list, decimal fastPace, decimal slowPace, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }

        public void GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan fastPace, TimeSpan slowPace, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }

        public void HeartRateTrend(List<ActivityModel> list, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }

        public void HeartRateTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }

        public void PaceTrend(List<ActivityModel> list, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }

        public void PaceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            throw new NotImplementedException();
        }
    }
}
