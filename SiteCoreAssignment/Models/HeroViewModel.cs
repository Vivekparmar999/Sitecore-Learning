using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreAssignment.Models
{
    public class HeroViewModel
    {
        public Item Item { get; set; }
        public string ExternalUrl { get; set; }
    }
}