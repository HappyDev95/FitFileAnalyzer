using System;
using System.Collections.Generic;
using System.IO;
using FitFileAnalyzer.Model;

namespace FitFileAnalyzer.Util
{
    enum FieldHeaderOutdoors
    {
        Seconds = 0,
        Timestamp = 1,
        Latitude = 2,
        Longitude = 3,
        Distance = 4,
        EnhancedSpeed = 5,
        EnhancedAltitude = 6,
        HeartRate = 7,
        Cadence = 8,
        FractionalCadence = 9
    }

    enum FieldHeaderIndoors
    {
        Seconds = 0,
        Timestamp = 1,
        Distance = 2,
        EnhancedSpeed = 3,
        HeartRate = 4,
        Cadence = 5,
        FractionalCadence = 6
    }

    public static class CsvFileUtil
    {
        public static Dictionary<string, List<DatapointModel>> ParseFitFileCsv(string pathToCsvDir)
        {
            if (!Directory.Exists(pathToCsvDir))
            {
                throw new ApplicationException($"The provided file {pathToCsvDir}, does not exist.");
            }

            Dictionary<string, List<DatapointModel>> fileDataMap = new Dictionary<string, List<DatapointModel>>();

            foreach (var file in Directory.EnumerateFiles(pathToCsvDir))
            {
                string filename = ExtractDateTimeFromPath(file);
                Console.WriteLine(filename);

                if (!fileDataMap.ContainsKey(filename))
                {
                    fileDataMap.Add(filename, ParseFile(file));
                }
                else
                {

                }
            }
            return fileDataMap;
        }

        public static List<DatapointModel> ParseFile(string pathToFile)
        {
            List<DatapointModel> datapointList = new List<DatapointModel>();

            using (var reader = new StreamReader(pathToFile))
            {
                int lineNum = 0;
                List<string> categories = new List<string>();

                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(',');
                    if (lineNum == 1)
                    {
                        categories.AddRange(ParseHeader(line));
                    }
                    if (lineNum > 1)
                    {
                        var dp = ExtractDatapoint(line, categories);
                        if (dp != null)
                        {
                            datapointList.Add(dp);
                        }
                    }
                    lineNum++;
                }
            }
            return datapointList;
        }

        public static string ExtractDateTimeFromPath(string path)
        {
            string fname = Path.GetFileName(path);
            return fname.Substring(8, 17);
        }

        public static DatapointModel ExtractDatapoint(string[] line, List<string> categories)
        {
            DatapointModel dp = new DatapointModel();
            for (int j = 0; j < line.Length; j++)
            {

                //
                if (categories[j].Equals("TimerEvent") || categories[j].Equals("Lap") && line[j].Equals(string.Empty))
                {
                    continue;
                }

                if (line[j].Equals(string.Empty))
                    return null;

                switch (categories[j])
                {
                    case "Seconds":
                        dp.Seconds = Int32.Parse(line[j]);
                        break;
                    case "Timestamp":
                        dp.Timestamp = double.Parse(line[j]);
                        break;
                    case "PositionLat":
                        dp.Latitude = long.Parse(line[j]);
                        break;
                    case "PositionLong":
                        dp.Longitude = long.Parse(line[j]);
                        break;
                    case "Distance":
                        dp.Distance = decimal.Parse(line[j]);
                        break;
                    case "EnhancedSpeed":
                        dp.EnhancedSpeed = decimal.Parse(line[j]);
                        break;
                    case "EnhancedAltitude":
                        dp.EnhancedAltitude = decimal.Parse(line[j]);
                        break;
                    case "HeartRate":
                        dp.HeartRate = Int32.Parse(line[j]);
                        break;
                    case "Cadence":
                        dp.Cadence = Int32.Parse(line[j]);
                        break;
                    case "FractionalCadence":
                        dp.FractionalCadence = decimal.Parse(line[j]);
                        break;
                    default:
                        break;
                }

            }
            return dp;
        }

        public static string[] ParseHeader(string[] categories)
        {
            var result = new string[categories.Length];
            for (int i = 0; i < categories.Length; i++)
            {
                switch (categories[i])
                {
                    case "Seconds":
                        result[i] = "Seconds";
                        break;
                    case "Timestamp":
                        result[i] = "Timestamp";
                        break;
                    case "PositionLat":
                        result[i] = "PositionLat";
                        break;
                    case "PositionLong":
                        result[i] = "PositionLong";
                        break;
                    case "Distance":
                        result[i] = "Distance";
                        break;
                    case "EnhancedSpeed":
                        result[i] = "EnhancedSpeed";
                        break;
                    case "EnhancedAltitude":
                        result[i] = "EnhancedAltitude";
                        break;
                    case "HeartRate":
                        result[i] = "HeartRate";
                        break;
                    case "Cadence":
                        result[i] = "Cadence";
                        break;
                    case "FractionalCadence":
                        result[i] = "FractionalCadence";
                        break;
                    case "TimerEvent":
                        result[i] = "TimerEvent";
                        break;
                    case "Lap":
                        result[i] = "Lap";
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

    }
}
