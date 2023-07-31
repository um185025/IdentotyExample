using static IdentotyExample.Enums.Enums;

public class Site
    {
        //public string? id { get; set; }
        public int SiteId { get; set; }
        public string ExternalId { get; set; }
        public string EnterpriseUnitId { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string VoicePhone { get; set; }
        public string FAXPhone { get; set; }
        public int WebDesignId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLoyaltyEnabled { get; set; }
        public bool IsStoredValueCardEnabled { get; set; }
        public int TimeOffsetHours { get; set; }
        public int TimeOffsetMinutes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? LastModifiedTimestamp { get; set; }
        public string CateringBCCEmailList { get; set; }
        public string RetailBCCEmailList { get; set; }
        public bool IsMobileEnabled { get; set; }
        public CreditProcessingMode CreditProcessingMode { get; set; }
        public int? SiteStatus { get; set; }
        public OrderModeType? SupportedOrderModes { get; set; }
        public int? SupportedDeliveryModes { get; set; }
        public double? DeliveryRange { get; set; }
        public List<Hour>? Hours { get; set; }
        public List<SpecialEvent>? SpecialEvents { get; set; }
        public int? StoreIdentifier { get; set; }
        public List<int>? AvailableProducts { get; set; }
        public int? OrderingState { get; set; }
        public int? Locator { get; set; }
        public bool? RequireTableNumber { get; set; }
        public bool? OpenCheckEnabled { get; set; }
        public bool? StartTabEnabled { get; set; }
        public bool? OpenCheckAutoCloseEnabled { get; set; }
    }
