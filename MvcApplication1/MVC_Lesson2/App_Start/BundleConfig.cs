using System.Web.Optimization;

namespace MVC_Lesson2
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap*"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/site.css")
                    .Include("~/Content/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                       "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css/jqueryui")
                    .Include("~/Content/jquery-ui*"));
        }
    }
}