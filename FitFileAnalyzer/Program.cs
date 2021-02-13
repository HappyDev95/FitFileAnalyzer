using System;
using System.Configuration;
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

            foreach(var kvp in dataMapping)
            {
                ActivityUtil.DisplayActivity(kvp.Value);
            }
        }
    }
}
