using Sitecore.Mvc.Presentation;
using SiteCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCoreAssignment.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;
            var model = new AboutViewModel()
            {
                Item = datasourceItem
            };


            return View(model);
        }
    }
}