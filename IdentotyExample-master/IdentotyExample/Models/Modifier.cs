    public class Modifier
    {
        public string id { get; set; }
        public int ModifierId { get; set; }
        public int POSItemId { get; set; }
        public int? ExternalReferenceId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string BaseImageName { get; set; }
        public List<ModifierModifierGroup> ModifierModifierGroups { get; set; }
        public List<ItemModifier> ItemModifiers { get; set; }
        public bool IsVisible { get; set; }
        public bool IsAvailable { get; set; }
        public List<DefaultOption> DefaultOptions { get; set; }
        public List<CustomField> CustomFields { get; set; }
    }
