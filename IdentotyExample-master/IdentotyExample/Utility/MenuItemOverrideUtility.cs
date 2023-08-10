using AlohaAPIExample.Models;
using IdentotyExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AlohaAPIExample.Utility
{
    public class MenuItemOverrideUtility
    {
        private readonly DataContext _context;

        public MenuItemOverrideUtility(DataContext context)
        {
            _context = context;
        }


       public async Task<List<MenuItemOverride>> GetMenuItemsOverride()
        {
            return await _context.MenuItemOverrides.ToListAsync();
        }
    }
}
