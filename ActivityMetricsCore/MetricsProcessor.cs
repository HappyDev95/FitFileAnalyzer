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
            List<decimal> retVal = new List<decimal>();

            if (option == SortOption.Week)
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
                        retVal.Add(total);
                        //Console.WriteLine($"Weekly Total = {total}\n");

                        total = 0;
                        week = currentWeek;
                    }
                    total += activity.Distance;
                }
            }
            //TODO: add in other options

            return retVal;
        }

        public List<decimal> DistanceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            List<ActivityModel> tempList = new List<ActivityModel>();
            foreach (var activity in list)
            {
                var activityDate = DateUtil.GetDateFromString(activity.Date);

                if ((activityDate >= startDate) && (activityDate <= endDate))
                {
                    tempList.Add(activity);
                }
            }

            if (option == SortOption.Week)
            {
                return DistanceTrend(tempList);
            }
            //TODO: add in other options

            return null;
        }

        public List<decimal> GetLikeActivitesByDistance(List<ActivityModel> list, decimal minDistance, decimal maxDistance)
        {
            List<decimal> retVal = new List<decimal>();

            foreach (var activity in list)
            {
                if (activity.Distance >= minDistance && activity.Distance <= maxDistance)
                {
                    retVal.Add(activity.Distance);
                }
            }
            return retVal;
        }

        public List<ActivityModel> GetLikeActivitesByPace(List<ActivityModel> list, TimeSpan minPace, TimeSpan maxPace)
        {
            List<ActivityModel> retVal = new List<ActivityModel>();

            foreach (var activity in list)
            {
                if (activity.Pace <= minPace && activity.Pace >= maxPace)
                {
                    retVal.Add(activity);
                }
            }
            return retVal;
        }

        public List<int> HeartRateTrend(List<ActivityModel> list, SortOption option = SortOption.Week)
        {
            List<int> retVal = new List<int>();

            if (option == SortOption.Week)
            {
                var cultureInfo = new CultureInfo("en-US");
                var calendar = cultureInfo.Calendar;
                var calendarRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
                var dowRule = cultureInfo.DateTimeFormat.FirstDayOfWeek;

                var week = calendar.GetWeekOfYear(DateUtil.GetDateFromString(list[0].Date), calendarRule, dowRule);
                int heartRateTotal = 0;
                int counter = 0;

                foreach (var activity in list)
                {
                    var currentWeek = calendar.GetWeekOfYear(DateUtil.GetDateFromString(activity.Date), calendarRule, dowRule);
                    if (week != currentWeek)
                    {
                        retVal.Add(heartRateTotal / counter);
                        heartRateTotal = 0;
                        counter = 0;
                        week = currentWeek;
                    }
                    heartRateTotal += activity.AverageHeartRate;
                    counter += 1;
                }
            }
            //TODO: add in other options

            return retVal;
        }

        public List<int> HeartRateTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            List<ActivityModel> tempList = new List<ActivityModel>();

            foreach (var activity in list)
            {
                var activityDate = DateUtil.GetDateFromString(activity.Date);

                if ((activityDate >= startDate) && (activityDate <= endDate))
                {
                    tempList.Add(activity);
                }
            }

            if (option == SortOption.Week)
            {
                return HeartRateTrend(tempList);
            }

            //TODO: add in other options

            return null;
        }

        public List<TimeSpan> PaceTrend(List<ActivityModel> list, SortOption option = SortOption.Week)
        {
            List<TimeSpan> retVal = new List<TimeSpan>();

            if (option == SortOption.Week)
            {
                var cultureInfo = new CultureInfo("en-US");
                var calendar = cultureInfo.Calendar;
                var calendarRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
                var dowRule = cultureInfo.DateTimeFormat.FirstDayOfWeek;

                var week = calendar.GetWeekOfYear(DateUtil.GetDateFromString(list[0].Date), calendarRule, dowRule);
                TimeSpan total = new TimeSpan();
                int counter = 0;

                foreach (var activity in list)
                {
                    var currentWeek = calendar.GetWeekOfYear(DateUtil.GetDateFromString(activity.Date), calendarRule, dowRule);
                    if (week != currentWeek)
                    {
                        retVal.Add(total.Divide(counter));
                        total = new TimeSpan();
                        week = currentWeek;
                        counter = 0;
                    }
                    total += activity.Pace;
                    counter += 1;
                }
            }
            //TODO: add in other options

            return retVal;
        }

        public List<TimeSpan> PaceTrend(List<ActivityModel> list, DateTime startDate, DateTime endDate, SortOption option = SortOption.Week)
        {
            List<ActivityModel> tempList = new List<ActivityModel>();

            foreach (var activity in list)
            {
                var activityDate = DateUtil.GetDateFromString(activity.Date);

                if ((activityDate >= startDate) && (activityDate <= endDate))
                {
                    tempList.Add(activity);
                }
            }

            if (option == SortOption.Week)
            {
                return PaceTrend(tempList);
            }

            //TODO: add in other options

            return null;
        }
    }
}
