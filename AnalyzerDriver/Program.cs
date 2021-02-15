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
           // FitFileUtil.ReadActivityFiles(args[0]);

            Console.WriteLine("Extracting data from CSV's");
            var dataMapping = CsvFileUtil.ParseFitFileCsv(ConfigurationManager.AppSettings.Get("DesinationDirectory"));

            List<ActivityModel> activites = new List<ActivityModel>();
            foreach (var kvp in dataMapping)
            {
                activites.Add(DatapointUtil.CreateActivity(kvp.Key, kvp.Value));
            }

            MetricsProcessor mp = new MetricsProcessor();
            var dt = mp.DistanceTrend(activites, ActivityMetricsCore.Enums.SortOption.Week);

            var dt1 = mp.DistanceTrend(activites, DateTime.Parse("07-01-2020"), DateTime.Parse("08-20-2020"), ActivityMetricsCore.Enums.SortOption.Week);

            foreach(var value in dt1)
            {
                Console.WriteLine(value);
            }

        }
    }
}
