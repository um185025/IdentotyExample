    public class Hour
    {
        public string id { get; set; }
        public int DayOfWeek { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public bool IsClosed { get; set; }
        public bool IsClosedForDelivery { get; set; }
        public DateTime? Delivery1Start { get; set; }
        public DateTime? Delivery1End { get; set; }
        public DateTime? Delivery2Start { get; set; }
        public DateTime? Delivery2End { get; set; }
    }
