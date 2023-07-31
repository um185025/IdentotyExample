    public class MenuItem
    {
        public string id { get; set; }
        public int MenuItemId { get; set; }
        public string Type { get; set; }
        public int? ExternalReferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefaultItemId { get; set; }
        public int ItemOrderingMode { get; set; }
        public string DisplayName { get; set; }
        public string BaseImageName { get; set; }
        public string ListImageName { get; set; }
        public List<int> SalesItemIds { get; set; }
        public List<SalesGroup> SalesGroups { get; set; }
        public int PromoId { get; set; }
        public bool IsVisible { get; set; }
        public double Price { get; set; }
        public PriceChanges PriceChanges { get; set; }
        public List<int> DaysOfWeekAvailable { get; set; }
        public string CaloricServingUnit { get; set; }
        public List<string> Icons { get; set; }
        public int? CaloricValue { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public List<int> SupportedOrderModes { get; set; }
    }
