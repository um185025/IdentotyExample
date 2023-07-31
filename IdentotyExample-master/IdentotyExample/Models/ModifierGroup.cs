    public class ModifierGroup
    {
        public string id { get; set; }
        public int ModifierGroupId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int ModifierActionGroupId { get; set; }
        public string LayoutBindingTag { get; set; }
        public string BaseImageName { get; set; }
        public int MinimumItems { get; set; }
        public int MaximumItems { get; set; }
        public int PerOptionMaximum { get; set; }
        public int PerOptionMinimum { get; set; }
        public int MaxDistinctOptions { get; set; }
        public string ValidQuantities { get; set; }
        public int SourceModifierGroupId { get; set; }
        public bool IsFolder { get; set; }
        public List<int> Modifiers { get; set; }
        public bool IsVisible { get; set; }
        public int FreeModifiers { get; set; }
        public string CaloricServingUnit { get; set; }
        public List<CustomField> CustomFields { get; set; }
    }
