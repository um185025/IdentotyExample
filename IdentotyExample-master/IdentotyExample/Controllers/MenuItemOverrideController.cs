using AlohaAPIExample.Models;
using IdentotyExample.Data;
using IdentotyExample.Models.Dto;
using IdentotyExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IdentotyExample.Enums.Enums;
using AlohaAPIExample.Helpers;
using System.Diagnostics;

namespace AlohaAPIExample.Controllers
{
    public class MenuItemOverrideController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly AlohaAPIClient _client;

        public MenuItemOverrideController(DataContext context, AlohaAPIClient client)
        {
            _context = context;
            _client = client;
        }


        [HttpGet]
        [Route("GetMenuItemsOverride")]
        public async Task<IActionResult> GetMenuItemsOverride()
        {
            try
            {
                var response = await _context.MenuItemOverrides.ToListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddOrUpdateMenuItemOverride")]
        public async Task<ActionResult> AddOrUpdateMenuItemOverride(MenuItemOverride menuItemOverride)
        {
            try
            {
                var itemFromDb = await _context.MenuItemOverrides.FindAsync(menuItemOverride.SiteId, menuItemOverride.MenuId, menuItemOverride.MenuItemId);
                
                List<MenuItemOverride> menuItemOverrideList = await _context.MenuItemOverrides.ToListAsync();
                OrderModeType anyOrderModeType = OrderModeType.Pickup | OrderModeType.DriveThru | OrderModeType.Delivery | OrderModeType.CurbSide | OrderModeType.WalkIn | OrderModeType.DineIn | OrderModeType.SVCDeposit | OrderModeType.Undefined;
                var menus = await _client.GetMenus(menuItemOverrideList, menuItemOverride.SiteId, new DateTime(), anyOrderModeType, false);
                bool foundInAloha = false;

                foreach (var menu in menus.Menus)
                {
                    if (menu.MenuId != menuItemOverride.MenuId) continue;
                    var submenusInt = menu.SubMenus.ToList();
                    var allSubMenus = menus.SubMenus;
                    foreach (int subMenuId in submenusInt)
                    {
                        var newSubMenu = allSubMenus.FirstOrDefault(submenu => submenu.SubMenuId == subMenuId);
                        if (newSubMenu == null) continue;
                        var menuItemsInt = newSubMenu.MenuItems.ToList();
                        var allMenuItems = menus.MenuItems;
                        foreach (int menuItemId in menuItemsInt)
                        {
                            var newMenuItem = allMenuItems.FirstOrDefault(menuitem => menuitem.MenuItemId == menuItemId);
                            if (newMenuItem == null || newMenuItem.MenuItemId != menuItemOverride.MenuItemId) continue;
                            foundInAloha = true;
                            break;
                        }
                        if (foundInAloha) break;
                    }
                    if (foundInAloha) break;
                }
                if (!foundInAloha) {
                    return NotFound("Please provide valid values for SiteId, MenuId, and MenuItemId."); }

                if (itemFromDb == null)
                {
                    _context.MenuItemOverrides.Add(menuItemOverride);
                }
                else
                {
                    itemFromDb.Name = menuItemOverride.Name;
                    itemFromDb.Description = menuItemOverride.Description;
                    itemFromDb.ImageName = menuItemOverride.ImageName;
                    _context.MenuItemOverrides.Update(itemFromDb);
                }
                await _context.SaveChangesAsync();
                return Ok(menuItemOverride);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteMenuItemOverride")]
        public async Task<ActionResult> DeleteMenuItemOverride(MenuItemOverride menuItemOverride)
        {
            try
            {
                var itemFromDb = await _context.MenuItemOverrides.FindAsync(menuItemOverride.SiteId, menuItemOverride.MenuId, menuItemOverride.MenuItemId);
                if (itemFromDb != null)
                {
                    _context.MenuItemOverrides.Remove(itemFromDb);
                    await _context.SaveChangesAsync();
                    return Ok("Deleted");
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
