using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace SiteCoreAssignment.Helper
{
    
    public static class GetLinkFieldValue
    {
        public static String MyFormattedLink(Item currentItem) 
        {
            //Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
            //Sitecore.Data.Items.Item home = master.GetItem("/sitecore/content/home");
            Sitecore.Data.Fields.LinkField linkField = currentItem.Fields["LearnMore"];

            string url = String.Empty;

            switch (linkField.LinkType)
            {
                case "internal":
                case "external":
                    url = linkField.GetFriendlyUrl();
                    break;
                case "mailto":
                case "anchor":
                case "javascript":
                    url = linkField.Url;
                    break;
                case "media":
                    Sitecore.Data.Items.MediaItem media = new Sitecore.Data.Items.MediaItem(linkField.TargetItem);
                    url = Sitecore.StringUtil.EnsurePrefix('/',
                    Sitecore.Resources.Media.MediaManager.GetMediaUrl(media));
                    break;
                case "":
                    break;
                default:
                    string message = "Invalid Url";//String.Format("{0} : Unknown link type {1} in {2}", this.GetType(), linkField.LinkType, home.Paths.FullPath); Sitecore.Diagnostics.Log.Error(message, this);
                    break;
            }

            return url;
        }
    }
}