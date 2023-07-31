    public class SalesItem
    {
        public string id { get; set; }
        public int SalesItemId { get; set; }
        public int POSItemId { get; set; }
        public int? ExternalReferenceId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string GroupDetailName { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public PriceChanges PriceChanges { get; set; }
        public int ItemOptionSetId { get; set; }
        public string BaseImageName { get; set; }
        public List<int> ModifierGroups { get; set; }
        public List<DefaultOption> DefaultOptions { get; set; }
        public bool IsVisible { get; set; }
        public bool CanBeOrderedAsIs { get; set; }
        public int IncludedModifierCount { get; set; }
        public double? DiscountPrice { get; set; }
        public int? FreeModifierCount { get; set; }
        public string DiscountName { get; set; }
        public int? CaloricValue { get; set; }
        public bool IsAvailable { get; set; }
        public List<CustomField> CustomFields { get; set; }
    }
