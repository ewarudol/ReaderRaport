using CsvHelper;
using ReaderRaport.Handlers;
using ReaderRaport.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

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


            return View();
        }

        /* save posted file code
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
        */

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileData) {
            try {
                if (fileData != null) {

                    //Specify here model for your CSV
                    CSVHandler<RawBook> cSVHandler = new CSVHandler<RawBook>();

                    string fileName = cSVHandler.GetFileName(fileData);
                    List<RawBook> bookList = cSVHandler.SaveWebCSV(fileData);

                    Session["library"] = new Library(bookList, fileName);

                    return Json(Resources.PageText.msgCSVSuccses);
                }
            } catch(HeaderValidationException){
                return Json(Resources.PageText.msgCSVFormat);
            } catch {
                return Json(Resources.PageText.msgCSV);
            }
            return Json(Resources.PageText.msgCSV);
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