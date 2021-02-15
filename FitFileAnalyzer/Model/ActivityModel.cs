using System;

namespace FitFileAnalyzer.Model
{
    public class ActivityModel
    {

        public string Date { get; }
        public decimal Distance { get; }
        public int AverageHeartRate { get; }
        public TimeSpan TotalActivityTime { get; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public TimeSpan Pace { get; }

        public ActivityModel(string date, decimal distance, TimeSpan time, int avghr)
        {
            this.Date = date;
            this.Distance = distance;
            this.TotalActivityTime = time;
            this.AverageHeartRate = avghr;
            this.Hours = time.Hours;
            this.Minutes = time.Minutes;
            this.Seconds = time.Seconds;
            if(this.Distance != 0)
            {
                this.Pace = CalculatePace(this.TotalActivityTime, this.Distance);
            }
        }

        public override string ToString()
        {
            var totTime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", this.Hours, this.Minutes, this.Seconds);
            var pace = string.Format("{0:D2}m:{1:D2}s", this.Pace.Minutes, this.Pace.Seconds);
            return $"Date: {this.Date}\n\tDistance: {this.Distance:#.##} mi\n\tElapsed Time: {totTime}\n\tAverage Heart Rate: {this.AverageHeartRate}\n\tPace: {pace}";
        }

        public static TimeSpan CalculatePace(TimeSpan time, decimal distance)
        {
            var unfilteredPace = (decimal)time.TotalMinutes / distance;
            var leftOfDecimal = Math.Floor(unfilteredPace);
            var rightOfDecimal = unfilteredPace - leftOfDecimal;
            var seconds = rightOfDecimal * 60;

            return new TimeSpan(0, (int)leftOfDecimal, (int)seconds);
        }

    }
}
