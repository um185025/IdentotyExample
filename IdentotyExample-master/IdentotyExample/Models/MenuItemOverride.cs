using System;
using System.Collections.Generic;

namespace AlohaAPIExample.Models;

public partial class MenuItemOverride
{
    public int SiteId { get; set; }

    public int MenuId { get; set; }

    public int MenuItemId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageName { get; set; }
}
