namespace FitFileAnalyzer.Model
{
    public class DatapointModel
    {
        public int Seconds { get; set; }
        public long Timestamp { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public decimal Distance { get; set; }
        public decimal EnhancedSpeed { get; set; }
        public decimal EnhancedAltitude { get; set; }
        public int HeartRate { get; set; }
        public int Cadence { get; set; }
        public decimal FractionalCadence { get; set; }
    }
}
