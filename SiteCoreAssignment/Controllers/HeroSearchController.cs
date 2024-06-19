using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using SiteCoreAssignment.Helper;
using SiteCoreAssignment.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.ContentSearch;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.SearchTypes;

namespace SiteCoreAssignment.Controllers
{
    public class HeroSearchController : Controller
    {
        // GET: Hero
        public ActionResult Index()
        {
            List<HeroViewModels> heroList = new List<HeroViewModels>();
            var searchindex = ContentSearchManager.GetIndex("sitecore_web_index");

            var queryable = searchindex.CreateSearchContext().GetQueryable<SearchHeroModel>();

            var queryStringValueFromUrl = System.Web.HttpContext.Current.Request.QueryString["search"];

            if (queryStringValueFromUrl != null)
            {
                var q = queryable.Where(i => i.Template == "29254ec3fa3f4aeda48147de20b7dae3")?.Where(h => h.HeroTitle.StartsWith(queryStringValueFromUrl))?.ToList();

                if (q != null)
                {
                    foreach (var hero in q)
                    {

                        HeroViewModels heroVM = new HeroViewModels() { Title = hero.HeroTitle };
                        heroList.Add(heroVM);
                    }
                }
            }

            HeroBannerSearchList heroBannerSearchList = new HeroBannerSearchList()
            {
                HeroBannerList = heroList
            };

            return View(heroBannerSearchList);
        }
    }

    public class HeroBannerSearchList
    {
        public List<HeroViewModels> HeroBannerList { get; set; }
    }
    public class HeroViewModels
    {
        public Item Item { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ExternalUrl { get; set; }
    }
    public class SearchHeroModel : SearchResultItem
    {

        [IndexField("title_t")]
        public virtual string HeroTitle { get; set; }

        [IndexField("_template")]
        public virtual string Template { get; set; }

    }
}