using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamicRow.Models;

namespace DinamicRow.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        [HttpGet]
        public ActionResult Index()
        {
            List<Gift> initialData = new List<Gift>
            {
                new Gift {Name = "Tall Hat", Price = 39.95},
                new Gift {Name = "Long Cloak", Price = 120.00}
            };

            return View(initialData);
        }
        [HttpPost]
        public string Index(IEnumerable<Gift> gifts)
        {
            // To do: do whatever you want with the data
            return "ok";
        }
        public PartialViewResult BlankEditorRow()
        {
            return PartialView("GiftEditorRow", new Gift());
        }
    }
}