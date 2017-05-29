namespace PVT.Q1._2017.Shop
{
    using System.Web.Optimization;

    /// <summary>
    /// 
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                                                        "~/Scripts/jquery.validate*",
                                                                        "~/Scripts/validator.configuration.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/inputmask").Include(
                    "~/Scripts/jquery.inputmask/inputmask.js",
                    "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                    "~/Scripts/jquery.inputmask/inputmask.extensions.js",
                    "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
                    "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/content-management-scripts").Include(
                                                                                         "~/Scripts/file-change.js",
                                                                                         "~/Scripts/numeric_input.min.js",
                                                                                         "~/Scripts/price.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));

            bundles.Add(
                new StyleBundle("~/bundles/cssTracks").Include(
                    "~/Content/tracks.css",
                    "~/Content/ratingStars.css",
                    "~/Content/font-awesome.min.css"));
        }
    }
}