using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageViewer.Web.Services;
using System.Threading.Tasks;

namespace ImageViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            var service = new ImageListService();
            return View(await service.List());
        }
    }
}
