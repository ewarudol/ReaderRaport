using ReaderRaport.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ReaderRaport.Handlers.Scraper;

namespace ReaderRaport.Controllers
{
    public class SelectController : Controller
    {
        // GET: Select
        public ActionResult Index()
        {
            string url = BookNameSearchUrl("Przebudzenie Króla Lisza");
            List<string> imagesUrls = GetHrefs(url);
            ViewBag.coversUrls = imagesUrls;

            return View();
        }
    }
}