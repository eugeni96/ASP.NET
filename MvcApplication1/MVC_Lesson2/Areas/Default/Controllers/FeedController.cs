using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using MVC_Lesson2.Global;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class FeedController : DefaultController
    {
        //
        // GET: /Default/Feed/

        public ActionResult Index()
        {
            var host = Request.Url;
            var feed =
               new SyndicationFeed("Site RSS",
                                   "",
                                   new Uri(host.AbsoluteUri + "/Feed"));

            var items = new List<SyndicationItem>();

            var item = new SyndicationItem(
               "Title",
               "content",
               new Uri("http://" + host + "/some-link-url"),
               "Title",
               DateTime.Now
               );
            items.Add(item);
            feed.Items = items;

            return new RssActionResult { Feed = feed };
        }


    }
}
