using System;
using System.Web.Optimization;

namespace TNTT.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(
                new ScriptBundle("~/scripts/lib/modernizr")
                    .Include("~/scripts/lib/modernizr-{version}.js"));

            bundles.Add(
              new ScriptBundle("~/scripts/lib/vendor")
                .Include("~/scripts/lib/jquery-2.0.3.min.js")
                .Include("~/scripts/lib/bootstrap.js")
                .Include("~/scripts/lib/angular.min.js")
                .Include("~/scripts/lib/toastr.min.js")
                .Include("~/scripts/lib/angular-google-maps.js")
              );

            bundles.Add(new ScriptBundle("~/scripts/lib/app")
                .Include("~/scripts/app/app.js")
                .Include("~/scripts/app/home.js")
                .Include("~/scripts/app/filters.js")
                .Include("~/scripts/app/services/MemberData.js")
                .Include("~/scripts/app/services/DoanData.js")
                .Include("~/scripts/app/services/MienData.js")
                .Include("~/scripts/app/services/TrungUongData.js")
                .Include("~/scripts/app/controllers/HomeController.js")
                .Include("~/scripts/app/controllers/MemberListController.js")
                .Include("~/scripts/app/controllers/AddMemberController.js")
                .Include("~/scripts/app/controllers/EditMemberController.js")
                .Include("~/scripts/app/controllers/DoanListController.js")
                .Include("~/scripts/app/controllers/MienListController.js")
                .Include("~/scripts/app/controllers/TrungUongListController.js")
                .Include("~/scripts/app/controllers/LocationController.js")
                );

            bundles.Add(
             new StyleBundle("~/Content/css")
                .Include("~/Content/ie10mobile.css") // Must be first. IE10 mobile viewport fix
                .Include("~/Content/bootstrap/bootstrap.css")
                .Include("~/Content/bootstrap/bootstrap-responsive.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/toastr.min.css")
                .Include("~/Content/styles.css")
             );
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            //ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}