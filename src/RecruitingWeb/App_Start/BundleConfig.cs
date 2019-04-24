using System.Web.Optimization;

namespace RecruitingWeb
{
    public static class BundleConfig
    {
        public const string RutaBundlesBase = "~/bundles/base";
        public const string RutaBundlesPlugins = "~/bundles/plugins";
        public const string RutaBundlesJointJs = "~/bundles/jointJsAndDependencies";
        public const string RutaBundlesRecruiting = "~/bundles/recruiting";
        public const string RutaBundlesInitJs = "~/bundles/initJs";
        public const string RutaBundlesCss = "~/Content/css";

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            //<summary> JS </summary>

            bundles.Add(new ScriptBundle(RutaBundlesBase).Include(
                        "~/Scripts/base/jquery-1.12.4.min.js",
                        "~/Scripts/base/jquery-ui-1.10.4.min.js",
                        "~/Scripts/base/jquery.cookie-1.4.1.min.js",
                        "~/Scripts/base/bootstrap.js",
                        "~/Scripts/base/respond.js",
                        "~/Scripts/base/bootstrap-dialog.js",
                        "~/Scripts/base/bootstrap-toggle.js"));

            bundles.Add(new ScriptBundle(RutaBundlesPlugins).Include(
                          "~/Scripts/plugins/autoNumeric.js"
                        , "~/Scripts/plugins/parsley.js"
                        , "~/Scripts/plugins/parsley.remote.js"
                        , "~/Scripts/plugins/jquery.dataTables.js"
                        , "~/Scripts/plugins/moment.min.js"
                        , "~/Scripts/plugins/fullcalendar.min.js"
                        , "~/Scripts/plugins/summernote.js"
                        , "~/Scripts/plugins/TweenMax.min.js"
                        ,"~/Scripts/plugins/Moment.js"
                        , "~/Scripts/plugins/jquery-ui-sliderAccess.js"
                        , "~/Scripts/plugins/jquery-ui-timepicker-addon.js"
                        , "~/Scripts/plugins/loadingoverlay.js"
                        ));

            bundles.Add(new ScriptBundle(RutaBundlesJointJs).Include(
                          "~/Scripts/jointJsAndDependencies/underscore.js"
                        , "~/Scripts/jointJsAndDependencies/backbone.js"
                        , "~/Scripts/jointJsAndDependencies/dagre.js"
                        , "~/Scripts/jointJsAndDependencies/graphlib.js"
                        , "~/Scripts/jointJsAndDependencies/lodash.js"
                        , "~/Scripts/jointJsAndDependencies/joint.js"));

            bundles.Add(new ScriptBundle(RutaBundlesRecruiting).Include(
                          "~/Scripts/recruiting/plugins.js"
                        , "~/Scripts/recruiting/framework.js"
                        , "~/Scripts/recruiting/menu.js"
                        , "~/Scripts/recruiting/init.js"));


            bundles.Add(new ScriptBundle(RutaBundlesInitJs).Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/plugins/Chart.js"));

            //<summary> CSS </summary>

            bundles.Add(new StyleBundle(RutaBundlesCss).Include(
                      "~/Content/bootstrap/bootstrap.css"
                      , "~/Content/themes/base/core.css"
                      , "~/Content/themes/base/theme.css"
                      , "~/Content/themes/base/datepicker.css"
                      , "~/Content/themes/base/jquery-ui-timepicker-addon.css"
                      , "~/Content/themes/base/jquery-ui.css"
                      , "~/Content/ie.css"
                      , "~/Content/reset.css"
                      , "~/Content/app/table.css"
                      , "~/Content/app/menu.css"
                      , "~/Content/app/notification.css"
                      , "~/Content/style.css"
                      , "~/Content/bootstrapDialog/bootstrap-dialog.css"
                      , "~/Content/bootstrap-toggle.css"
                      , "~/Content/bootstrapWysiwyg/style.css"
                      , "~/Content/app/form.css"
                      , "~/Content/calendar/fullcalendar.css"
                      , "~/Content/font-awesome.min.css"
                      , "~/Content/error.css"
                      , "~/Content/jointJs/joint.css"
                      , "~/Content/summernote/summernote.css"                      
                      ));
        }
    }
}
