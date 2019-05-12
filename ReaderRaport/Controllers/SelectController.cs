using ReaderRaport.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ReaderRaport.Handlers.LubimyCzytacScraper;

namespace ReaderRaport.Controllers
{
    public class SelectController : Controller
    {
        // GET: Select
        public ActionResult Index()
        {
            LubimyCzytacScraper scraper = new LubimyCzytacScraper();

            string bookName = "Przebudzenie Króla Lisza";
            string imageUrl = scraper.GetCover(bookName, out string msg);
            ViewBag.coverUrl = imageUrl;

            return Content(msg);
            //return View();
        }
    }
}