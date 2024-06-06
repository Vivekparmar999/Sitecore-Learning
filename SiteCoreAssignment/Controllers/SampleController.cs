using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using SiteCoreAssignment.Models;
using System.Web.Mvc;

namespace SiteCoreAssignment.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            string temp;
            List<string> sampleList = new List<string>();

            var dataSource = RenderingContext.Current?.Rendering.Item;
            Sitecore.Data.Fields.MultilistField multiselectField = dataSource.Fields["SampleList"];

            Sitecore.Data.Items.Item[] items = multiselectField.GetItems();


            //Iterate through each item
            if (items != null && items.Length > 0)
            {
                for (int i = 0; i < items.Length; i++)
                {

                    Sitecore.Data.Items.Item sampleItem = items[i];
                    temp = FieldRenderer.Render(sampleItem, "Title");

                    sampleList.Add(temp);
                }
            }


            return View(sampleList);
        }
    }
}