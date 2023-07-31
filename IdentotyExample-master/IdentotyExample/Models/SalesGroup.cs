    public class SalesGroup
    {
        public string id { get; set; }
        public int SalesGroupId { get; set; }
        public int MenuItemId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlFragment { get; set; }
        public string LayoutBindingTag { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public bool IsVisible { get; set; }
        public List<int> SalesItemIds { get; set; }
        public int Ranking { get; set; }
        public int DefaultSalesItemId { get; set; }
        public string DisplayName { get; set; }
    }
