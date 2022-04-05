using System.Web.Mvc;

namespace JC_PARK.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "JCarvalho TI.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tecnologia em Informática.";

            return View();
        }

        public ActionResult Construcao()
        {
            ViewBag.Message = "Breve em funcionamento.";

            return View();
        }
    }
}