using ReaderRaport.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
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
            string bookName = "harry potter";
            string imageUrl = scraper.GetCover(bookName, out string msg);
            ViewBag.coverUrl = imageUrl;

            ViewBag.Title = "Generate Reader Raport!";
            return View();
        }

        [HttpPost]
        public ActionResult Upload(List<HttpPostedFileBase> fileData) {
            try {
                string path = Server.MapPath("~/Uploaded/");
                foreach (HttpPostedFileBase postedFile in fileData) {
                    if (postedFile != null) {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(path + fileName);
                    }
                }
                return Json("Success!");
            } catch {
                return Json("Oh no, something went wrong. Check if your file doesn't consist strange characters or extention.");
            }
        }
    }

}