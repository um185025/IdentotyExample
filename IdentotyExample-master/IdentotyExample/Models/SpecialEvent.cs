    public class SpecialEvent
    {
        public string id { get; set; }
        public int SpecialEventId { get; set; }
        public DateTime SpecialEventStartDate { get; set; }
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public bool IsClosed { get; set; }
        public bool IsClosedDelivery { get; set; }
        public DateTime SpecialEventEndDate { get; set; }
        public bool IsCompanyWide { get; set; }
        public DateTime Delivery1Start { get; set; }
        public DateTime Delivery1End { get; set; }
        public DateTime Delivery2Start { get; set; }
        public DateTime Delivery2End { get; set; }
        public string SpecialEventPurpose { get; set; }
    }
