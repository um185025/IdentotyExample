using AlohaAPIExample.Models;
using AlohaAPIExample.Models.Dto;
using System.Text.Json;

namespace AlohaAPIExample.Helpers
{
    public class MenuHelper
    {
        public static OutRootMenusDTO GetModifiedMenu(int siteId, List<MenuItemOverride> menuItemOverrideList, OutRootMenusDTO rootMenus)
        {
            var allMenuItems = rootMenus.MenuItems;
            foreach (MenuItemOverride menuItemOverride in menuItemOverrideList)
            {
                if (menuItemOverride.SiteId != siteId) continue;
                var newMenuItem = allMenuItems.FirstOrDefault(menuitem => menuitem.MenuItemId == menuItemOverride.MenuItemId);
                if (newMenuItem == null) continue;
                if (menuItemOverride.Name != null) newMenuItem.Name = menuItemOverride.Name;
                if (menuItemOverride.Description != null) newMenuItem.Description = menuItemOverride.Description;
                if (menuItemOverride.ImageName != null) newMenuItem.BaseImageName = menuItemOverride.ImageName;
            }
            return rootMenus;
        }
    }
}
