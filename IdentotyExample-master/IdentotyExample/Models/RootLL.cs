    public class RootLL
    {
        //public string? id { get; set; }
        public Site Site { get; set; }
        public decimal Distance { get; set; }
        public bool? InDeliveryZone { get; set; }
        public string? SpecialEventReasons { get; set; }
        public List<Attribute>? Attributes { get; set; }
        public List<SiteSetting>? SiteSettings { get; set; }
        public List<Daypart>? Dayparts { get; set; }
        public List<ManualDaypart>? ManualDayparts { get; set; }
    }
