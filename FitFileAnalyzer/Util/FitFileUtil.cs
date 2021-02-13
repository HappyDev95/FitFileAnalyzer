using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Dynastream.Fit;
using Extensions;

namespace FitFileAnalyzer.Util
{
    public static class FitFileUtil
    {
        private static readonly string DESTINATION_DIR = ConfigurationManager.AppSettings.Get("DesinationDirectory");
        private static readonly string FILENAME = "FitFile";

        public static void ReadActivityFiles(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new ApplicationException($"The supplied directory: {directory}, does not exist");
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                FileStream fstream = new FileStream(file, FileMode.Open);
                FitDecoder fitDecoder = new FitDecoder(fstream, Dynastream.Fit.File.Activity);

                // Decode the FIT file
                try
                {
                    Console.WriteLine("Decoding...");
                    fitDecoder.Decode();
                }
                catch (FileTypeException ex)
                {
                    Console.WriteLine("DecodeDemo caught FileTypeException: " + ex.Message);
                    return;
                }
                catch (FitException ex)
                {
                    Console.WriteLine("DecodeDemo caught FitException: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DecodeDemo caught Exception: " + ex.Message);
                }
                finally
                {
                    fstream.Close();
                }

                var timezoneOffset = fitDecoder.Messages.Activity.TimezoneOffset();
                Console.WriteLine($"The timezone offset for this activity file is {timezoneOffset?.TotalHours ?? 0} hours.");

                // Create the Activity Parser and group the messages into individual sessions.
                ActivityParser activityParser = new ActivityParser(fitDecoder.Messages);
                var sessions = activityParser.ParseSessions();
                ExportToCsv(sessions);

            }


        }

        public static void ExportToCsv(List<SessionMessages> sessions)
        {
            // Export a CSV file for each Activity Session
            foreach (SessionMessages session in sessions)
            {
                if (session.Records.Count > 0)
                {
                    var recordsCSV = Export.RecordsToCSV(session);

                    var recordsPath = Path.Combine(
                        Path.GetDirectoryName(DESTINATION_DIR),
                        $"{FILENAME}_{session.Session.GetStartTime().GetDateTime().ToString("MM-dd-yyyy")}_{session.Session.GetSport()}_Records.csv");

                    if (System.IO.File.Exists(recordsPath))
                    {
                        continue;
                    }

                    using (StreamWriter outputFile = new StreamWriter(recordsPath))
                    {
                        outputFile.WriteLine(recordsCSV);
                    }

                    Console.WriteLine($"The file {recordsPath} has been saved.");
                }

                if (session.Session.GetSport() == Sport.Swimming && session.Session.GetSubSport() == SubSport.LapSwimming && session.Lengths.Count > 0)
                {
                    var lengthsCSV = Export.LengthsToCSV(session);

                    var lengthsPath = Path.Combine(
                        Path.GetDirectoryName(DESTINATION_DIR),
                        $"{FILENAME}_{session.Session.GetStartTime().GetDateTime().ToString("yyyyMMddHHmmss")}_{session.Session.GetSport()}_Lengths.csv"
                        );

                    using (StreamWriter outputFile = new StreamWriter(lengthsPath))
                    {
                        outputFile.WriteLine(lengthsCSV);
                    }

                    Console.WriteLine($"The file {lengthsPath} has been saved.");
                }
            }
        }
    }
}
