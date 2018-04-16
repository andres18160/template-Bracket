using System.Web;
using System.Web.Optimization;

namespace webMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bracket/js").Include(
                      "~/Content/bracket/js/jquery-1.10.2.min.js",
                      "~/Content/bracket/js/jquery-migrate-1.2.1.min.js",
                      "~/Content/bracket/js/jquery-ui-1.10.3.min.js",
                      "~/Content/bracket/js/bootstrap.min.js",
                      "~/Content/bracket/js/modernizr.min.js",
                      "~/Content/bracket/js/jquery.sparkline.min.js",
                      "~/Content/bracket/js/toggles.min.js",
                      "~/Content/bracket/js/retina.min.js",
                      "~/Content/bracket/js/jquery.cookies.js",
                      "~/Content/bracket/js/jquery.gritter.min.js",
                      "~/Content/bracket/js/jquery.autogrow-textarea.js",
                      "~/Content/bracket/js/jquery.datatables.min.js",
                      "~/Content/bracket/js/jquery.maskedinput.min.js",
                      "~/Content/bracket/js/jquery.tagsinput.min.js",
                      "~/Content/bracket/js/jquery.mousewheel.js",
                      "~/Content/bracket/js/chosen.jquery.min.js",
                      "~/Content/bracket/js/bootstrap-timepicker.min.js",
                      "~/Content/bracket/js/dropzone.min.js",
                      "~/Content/bracket/js/jquery.validate.min.js",
                      "~/Content/bracket/js/custom.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/app/Modulo.js",
                      "~/Scripts/app/Servicios.js",
                      "~/Scripts/app/ControladorClientes.js",
                      "~/Scripts/app/ControladorFacturas.js"));

             bundles.Add(new StyleBundle("~/bracket/css").Include(
                        "~/Content/bracket/css/style.default.css",
                        "~/Content/bracket/css/jquery.gritter.css",
                        "~/Content/bracket/css/jquery.datatables.css",
                        "~/Content/bracket/css/bootstrap-timepicker.min.css",
                        "~/Content/bracket/css/jquery.tagsinput.css",
                        "~/Content/bracket/css/colorpicker.css",
                       "~/Content/bracket/css/dropzone.css"));
        }
    }
}
