using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Clientes()
        {
            ViewBag.Title = "Clientes";
            ViewBag.ContentTitle = "Administración de clientes";
            return View();
        }
        public ActionResult Facturas()
        {
            ViewBag.Title = "Facturas";
            ViewBag.ContentTitle = "Administración de facturas";
            return View();
        }

    }
}
