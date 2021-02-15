using System;
using System.Collections.Generic;
using System.Configuration;
using FitFileAnalyzer.Model;
using FitFileAnalyzer.Util;
using ActivityMetricsCore;

namespace AnalyzerDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Reading data from -> {args[0]}");
          //FitFileUtil.ReadActivityFiles(args[0], bool.Parse(ConfigurationManager.AppSettings.Get("RecurseDirectories")));

            Console.WriteLine("Extracting data from CSV's");
            var dataMapping = CsvFileUtil.ParseFitFileCsv(ConfigurationManager.AppSettings.Get("DesinationDirectory"));

            List<ActivityModel> activites = new List<ActivityModel>();
            foreach (var kvp in dataMapping)
            {
                activites.Add(DatapointUtil.CreateActivity(kvp.Key, kvp.Value));
            }

            MetricsProcessor mp = new MetricsProcessor();

            DistanceSuite(activites, mp);
            PaceSuite(activites, mp);
            HeartRateSuite(activites, mp);

        }

        public static void DistanceSuite(List<ActivityModel> activites, MetricsProcessor mp)
        {
            var dt = mp.DistanceTrend(activites, ActivityMetricsCore.Enums.SortOption.Week);
            var dt1 = mp.DistanceTrend(activites, DateTime.Parse("07-01-2020"), DateTime.Parse("08-20-2020"), ActivityMetricsCore.Enums.SortOption.Week);
            var dt2 = mp.GetLikeActivitesByDistance(activites, 10, 50);

            foreach (var val in dt2)
            {
                Console.WriteLine($"Distance: {val}");
            }

        }

        public static void PaceSuite(List<ActivityModel> activites, MetricsProcessor mp)
        {
            var p1 = mp.GetLikeActivitesByPace(activites, new TimeSpan(0, 8, 0), new TimeSpan(0, 6, 0));
            var p2 = mp.PaceTrend(activites, ActivityMetricsCore.Enums.SortOption.Week);
            var p3 = mp.PaceTrend(activites, DateTime.Parse("07-01-2020"), DateTime.Parse("08-20-2020"), ActivityMetricsCore.Enums.SortOption.Week);

            foreach(var val in p1)
            {
                Console.WriteLine($"{val}");
            }
        }

        public static void HeartRateSuite(List<ActivityModel> activities, MetricsProcessor mp)
        {
            var h1 = mp.HeartRateTrend(activities);
            foreach(var val in h1)
            {
                Console.WriteLine($"Heart Rate: {val}");
            }

            Console.WriteLine("--------------------------------------------------");

            var h2 = mp.HeartRateTrend(activities, DateTime.Parse("07-01-2020"), DateTime.Parse("08-20-2021"), ActivityMetricsCore.Enums.SortOption.Week);
            foreach(var val in h2)
            {
                Console.WriteLine($"Heart Rate: {val}");
            }

        }

    }
}
