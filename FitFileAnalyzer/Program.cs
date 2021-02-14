using System;
using System.Collections.Generic;
using System.Configuration;
using FitFileAnalyzer.Model;
using FitFileAnalyzer.Util;

namespace FitFileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Reading data from -> {args[0]}");
            //FitFileUtil.ReadActivityFiles(args[0]);

            Console.WriteLine("Extracting data from CSV's");
            var dataMapping = CsvFileUtil.ParseFitFileCsv(ConfigurationManager.AppSettings.Get("DesinationDirectory"));

            List<ActivityModel> activites = new List<ActivityModel>();

            foreach (var kvp in dataMapping)
            {
                activites.Add(DatapointUtil.CreateActivity(kvp.Key, kvp.Value));
            }

            foreach (var activity in activites)
            {
                Console.WriteLine(activity);
            }
        }
    }



}
