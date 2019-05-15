using ReaderRaport.Handlers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
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
            ViewBag.Title = "Generate Reader Raport!";
            return View();
        }

        public ActionResult YourDigitalLibrary() {

            LubimyCzytacScraper scraper = new LubimyCzytacScraper();
            string bookName = "harry potter";
            string imageUrl = scraper.GetCover(bookName, out string msg);
            ViewBag.coverUrl = imageUrl;

            ViewBag.Title = "Libka";
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


        public ActionResult Change(string ln, string source) {
            if (ln != null) {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ln);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(ln);
            }

            HttpCookie cookie = new HttpCookie("Language") {
                Value = ln
            };

            Response.Cookies.Add(cookie);

            return RedirectToAction(source);
        }
    }

}