using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiFileUpload.WebClient.Controllers
{
    public class FileClientController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            return View();
        }

        public ActionResult Client()
        {
            ViewBag.Title = "Ex Client";

            return View();
        }

        public ActionResult MultiClient()
        {
            ViewBag.Title = "Ex MultiClient";

            return View();
        }
    }
}