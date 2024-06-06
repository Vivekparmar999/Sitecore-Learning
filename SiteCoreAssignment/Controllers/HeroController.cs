using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using SiteCoreAssignment.Helper;
using SiteCoreAssignment.Models;
using System.Web.Mvc;

namespace SiteCoreAssignment.Controllers
{
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult Index()
        {

            var dataSourceId = RenderingContext.Current?.Rendering.DataSource;
            var item = ID.IsID(dataSourceId) ? Context.Database.GetItem(dataSourceId) : null;
                 
            var model = new HeroViewModel() { Item=item,ExternalUrl= GetLinkFieldValue.MyFormattedLink(item) };

            return View(model);
        }
    }
}