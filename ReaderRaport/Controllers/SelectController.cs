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
        public ActionResult Upload(HttpPostedFileBase fileData) {
            string statusMsg = "Oh no, something went wrong. Check if your file doesn't consist strange characters or extention.";
            try {
                string path = Server.MapPath("~/Uploaded/");
                if (fileData != null) {
                    string fileName = Path.GetFileName(fileData.FileName);
                    fileData.SaveAs(path + fileName);
                    statusMsg = "Success!";
                    return Json(statusMsg);
                }
            } catch {
                return Json(statusMsg);
            } 
            return Json(statusMsg);
    }
    }

}