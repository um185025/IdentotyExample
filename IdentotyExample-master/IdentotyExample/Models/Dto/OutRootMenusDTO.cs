namespace AlohaAPIExample.Models.Dto
{
    public class OutRootMenusDTO
    {
        public List<Menu> Menus { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<SalesItem> SalesItems { get; set; }
    }
}
