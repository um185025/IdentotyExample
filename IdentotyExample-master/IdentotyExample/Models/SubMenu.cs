    public class SubMenu
    {
        public string id { get; set; }
        public int SubMenuId { get; set; }
        public string Name { get; set; }
        public string HeaderImageName { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsVisible { get; set; }
        public List<Restriction> Restrictions { get; set; }
        public string DisplayName { get; set; }
        public List<int> MenuItems { get; set; }
        public string ExternalId { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public List<int> SupportedOrderModes { get; set; }
    }
