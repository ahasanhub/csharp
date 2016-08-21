using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        }
        //GET:  /HelloWorld/Welcome?name=Scott&numtimes=4
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = name;
            ViewBag.NumTimes = numTimes;
            return View();
        }
    }
}