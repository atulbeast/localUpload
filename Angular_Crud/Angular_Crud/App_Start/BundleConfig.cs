using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Angular_Crud.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        
                        "~/Scripts/bootstrap-datepicker.js",
                       "~/Scripts/Linq.js"
                      
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/angular-material.css",
                      "~/Content/toaster.css",
                      "~/Content/angular-screenshot.min.css",
                      "~/Content/bootstrap-datepicker.css"));

            bundles.Add(new ScriptBundle("~/AngularJS").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-animate.js",
                       "~/Scripts/angular-aria/angular-aria.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-material/angular-material.js",
                      "~/Scripts/toaster.js",
                       "~/Scripts/ng-file-upload.min.js",
                       "~/Scripts/angular-screenshot.min.js"

                       ));

            bundles.Add(new ScriptBundle("~/MyLibs").Include(
                "~/App/MyApp.js",
                "~/App/Controller/StudentCtrl.js",
                  "~/App/Controller/CreateCtrl.js",
                   "~/App/Controller/EditCtrl.js",
                  "~/App/Services/StudentService.js",
                "~/App/Services/CreateService.js",
                "~/App/Services/EditService.js",
                 "~/App/Services/ajaxService.js"
                
                  ));
        }
    }
}