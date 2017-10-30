using System.Web;
using System.Web.Optimization;

namespace DesafioJogos
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/Js/bootstrap.js",
                        "~/Scripts/Js/bootstrap.min.js",
                        "~/Scripts/Sistema/javascript.js",
                        "~/Scripts/datatables/jquery.dataTables.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.css",
                       "~/Content/css/bootstrap.css.map",
                       "~/Content/css/bootstrap.min.css",
                       "~/Content/css/bootstrap-theme.css",
                       "~/Content/css/bootstrap-theme.css.map",
                       "~/Content/css/bootstrap-theme.min.css",
                       "~/Content/site.css"
                       ));
        }
    }
}