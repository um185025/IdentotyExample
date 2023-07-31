    public class Menu
    {
        public string id { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MenuType { get; set; }
        public string ExternalId { get; set; }
        public int SupportedOrderModes { get; set; }
        public bool IsVisible { get; set; }
        public int MenuAttribute { get; set; }
        public string DisplayName { get; set; }
        public List<int> SubMenus { get; set; }
    }
